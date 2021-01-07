using Jwt.Core.Helpers;
using Jwt.Core.Messages;
using Jwt.Core.Plugins.Authentication;
using Jwt.Core.Plugins.Authentication.Jwt;
using Jwt.Core.Repositories;
using Jwt.Entities;
using Jwt.Models.Login;
using Jwt.Core.Models.UserRole;
using Jwt.Utilities.Results.DataResult;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Jwt.Business.Abstract;
using Jwt.Core.Exceptions;
using Jwt.Utilities.Results.Result;
using Jwt.Core.Plugins.Authentication.Models;
using Jwt.Core.Aspects.Security;

namespace Jwt.Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IDataAccessRepository<User> _dalUser;
        private readonly IDataAccessRepository<UserRole> _dalUserRole;

        private readonly ITokenHelper _tokenHelper;
        private readonly IActiveUserService _activeUserService;
        private readonly LoggedInUsers _loggedInUsers;
        private readonly JwtOptions _jwtOptions;

        public AuthService(IDataAccessRepository<User> dalUser, IDataAccessRepository<UserRole> dalUserRole,ITokenHelper tokenHelper, IActiveUserService activeUserService, LoggedInUsers loggedInUsers, JwtOptions jwtOptions)
        {
            _dalUser = dalUser;
            _dalUserRole = dalUserRole;

            _tokenHelper = tokenHelper;
            _activeUserService = activeUserService;
            _loggedInUsers = loggedInUsers;
            _jwtOptions = jwtOptions;
        }

        private async Task<IDataResponse<LoginResultModel>> LoginAsync(User user,bool isRefreshLogin = false)
        {
            var roles = await _dalUserRole.TableNoTracking
                .Include(x => x.Role)
                .Include(x => x.User)
                .Where(x => x.UserId == user.Id)
                .Select(x=>new UserRoleModel
                {
                    Id=x.Id,
                    UserId=x.UserId,
                    RoleId=x.RoleId,
                    RoleName=x.Role.Name
                })
                .ToListAsync();
            var accessToken = _tokenHelper.CreateToken(user.Id,roles);
            var tokenOptions = _jwtOptions;

            var userInfo = new UserInfo
            {
                UserId = user.Id,
                FullName = $"{user.FirstName} {user.LastName}",
            };

            var u = await _dalUser.TableNoTracking.FirstOrDefaultAsync(x => x.Id == user.Id);
            u.RefreshToken = accessToken.RefreshToken;
            u.RefreshTokenExpiredDate = DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration + 30);
            await _dalUser.UpdateAsync(u);

            _loggedInUsers.UserInfo= _loggedInUsers.UserInfo.Where(x => x.UserId == u.Id).ToList();
            _loggedInUsers.UserInfo.Add(userInfo);

            var result = new LoginResultModel
            {
                UserId = user.Id,
                FullName = $"{user.FirstName} {user.LastName}",
                Token = accessToken.Token,
                RefreshToken = accessToken.RefreshToken,
                TokenExpiration = DateTime.Now,
                UserRoles = roles
            };
            return new SuccessDataResponse<LoginResultModel>(result);
        }

        public async Task<IDataResponse<LoginResultModel>> LoginAsync(LoginModel loginModel)
        {
            var user = await _dalUser.TableNoTracking.FirstOrDefaultAsync(x => x.Email == loginModel.Email);
            if (user == null) return new ErrorDataResponse<LoginResultModel>(UserMessage.UserNotFound);

            if (HashingHelper.VerifyPasswordHash(loginModel.Password, user.PasswordHash, user.PasswordSalt))
                return await LoginAsync(user);

            return new ErrorDataResponse<LoginResultModel>(UserMessage.PasswordWrong);
        }

        public async Task<IDataResponse<LoginResultModel>> LoginByRefreshTokenAsync(RefreshTokenModel model)
        {
            var user = await _dalUser.TableNoTracking.FirstOrDefaultAsync(x => x.RefreshToken == model.Token);
            if (user == null)
                throw new AuthenticationException(UserMessage.AuthenticationError);
            if (!string.IsNullOrEmpty(user.RefreshToken) && user.RefreshTokenExpiredDate > DateTime.Now)
                return await LoginAsync(user, true);

            throw new AuthenticationException(UserMessage.AuthenticationError);
        }


        [SecurityAspect]
        public async Task<IResponse> LogoutAsync()
        {
            var user = await _dalUser.GetAsync(x => x.Id == _activeUserService.UserId);

            user.RefreshTokenExpiredDate = DateTime.Now.AddMinutes(-30);
            await _dalUser.UpdateAsync(user);

            _loggedInUsers.UserInfo = _loggedInUsers.UserInfo.Where(x => x.UserId !=user.Id).ToList();
            return new SuccessResponse(UserMessage.LogoutSuccessful);
        }
    }
}
