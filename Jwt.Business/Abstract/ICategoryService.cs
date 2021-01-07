using Jwt.Core.Repositories;
using Jwt.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Business.Abstract
{
    public interface ICategoryService:IServiceRepository<CategoryModel>
    {
        Task<IEnumerable<CategoryListModel>> GetAllAsync();
    }
}
