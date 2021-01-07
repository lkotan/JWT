using Jwt.Models.Login;
using Jwt.Utilities.Results.DataResult;
using Jwt.Utilities.Results.Result;
using System.Threading.Tasks;

namespace Jwt.Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResponse<LoginResultModel>> LoginAsync(LoginModel loginModel);
        Task<IDataResponse<LoginResultModel>> LoginByRefreshTokenAsync(RefreshTokenModel model);
        Task<IResponse> LogoutAsync();
    }
}
