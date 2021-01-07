using Jwt.Core.Repositories;
using Jwt.Models.Role;
using Jwt.Utilities.Results.DataResult;
using Jwt.Utilities.Results.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Business.Abstract
{
    public interface IRoleService : IServiceRepository<RoleModel>
    {
        Task<IEnumerable<RoleListModel>> GetAllAsync();
    }
}
