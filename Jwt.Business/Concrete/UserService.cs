using AutoMapper;
using Jwt.Business.Abstract;
using Jwt.Core.Helpers;
using Jwt.Core.Repositories;
using Jwt.Entities;
using Jwt.Models.User;
using Jwt.Utilities.Results.DataResult;
using Jwt.Utilities.Results.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IDataAccessRepository<User> _dal;
        private readonly IMapper _mapper;
        public UserService(IDataAccessRepository<User> dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }

        public async Task<IDataResponse<int>> DeleteAsync(int id)
        {
            var entity = await _dal.GetAsync(id);
            return await _dal.DeleteAsync(entity);
        }

        public async Task<IEnumerable<IDataResponse<int>>> DeleteRangeAsync(IEnumerable<int> list)
        {
            var result = new List<IDataResponse<int>>();
            foreach (var item in list)
            {
                result.Add(await DeleteAsync(item));
            }
            return result;
        }

        public async Task<IEnumerable<UserListModel>> GetAllAsync()
        {
            return _mapper.Map<List<UserListModel>>(await _dal.TableNoTracking.ToListAsync());
        }

        public async Task<UserModel> GetAsync(int id)
        {
            return _mapper.Map<UserModel>(await _dal.TableNoTracking.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<IDataResponse<int>> InsertAsync(UserModel model)
        {
            var entity = _mapper.Map<User>(model);
            HashingHelper.CreatePasswordHash(model.Password, out var passwordHash, out var passwordSalt);
            entity.PasswordSalt = passwordSalt;
            entity.PasswordHash = passwordHash;
            entity.RefreshToken = Helper.CreateToken();
            entity.RefreshTokenExpiredDate = DateTime.Now.AddDays(-1);
            return await _dal.InsertAsync(entity);
        }

        public async Task<IResponse> UpdateAsync(UserModel model)
        {
            return await _dal.UpdateAsync(_mapper.Map<User>(model));
        }
    }
}
