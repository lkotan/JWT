using Jwt.Core.Signatures;
using Jwt.Utilities.Results.DataResult;
using Jwt.Utilities.Results.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Core.Repositories
{
    public interface IServiceRepository<TModel> where TModel : class,IBaseModel,new()
    {
        /// <summary>
        /// Get Entitiy by identifier
        /// </summary>
        /// <param name="id">identifier</param>
        /// <returns>Entity</returns>
        Task<TModel> GetAsync(int id);

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="model">Entity</param>
        /// <returns>Response Message</returns>
        Task<IDataResponse<int>> InsertAsync(TModel model);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="model">Entities</param>
        /// <returns>Response Message</returns>
        Task<IResponse> UpdateAsync(TModel model);

        /// <summary>
        /// Delete entity by identifier
        /// </summary>
        /// <param name="id">identifier</param>
        /// <returns>Response Message</returns>
        Task<IDataResponse<int>> DeleteAsync(int id);

        /// <summary>
        /// Delete entities by identifier
        /// </summary>
        /// <param name="list">Identifier List</param>
        /// <returns>Response Message</returns>
        Task<IEnumerable<IDataResponse<int>>> DeleteRangeAsync(IEnumerable<int> list);

    }
}
