using Jwt.Core.Repositories;
using Jwt.Core.Models.UserRole;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Business.Abstract
{
    public interface IUserRoleService:IServiceRepository<UserRoleModel>
    {
        Task<IEnumerable<UserRoleListModel>> GetAllAsync();
    }
}
