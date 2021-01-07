using Jwt.Core.Repositories;
using Jwt.Entities;
using Jwt.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Business.Abstract
{
    public interface IUserService:IServiceRepository<UserModel>
    {
        Task<IEnumerable<UserListModel>> GetAllAsync();
    }
}
