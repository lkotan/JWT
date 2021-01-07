using Jwt.Core.Repositories;
using Jwt.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Business.Abstract
{
    public interface IProductService:IServiceRepository<ProductModel>
    {
        Task<IEnumerable<ProductListModel>> GetAllAsync();
    }
}
