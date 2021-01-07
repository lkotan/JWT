﻿using Jwt.Core.Signatures;
using Jwt.Utilities.Results.DataResult;
using Jwt.Utilities.Results.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class,IBaseEntity,new()
    {
        #region Properties
        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<TEntity> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<TEntity> TableNoTracking { get; }
        #endregion

        #region Methods

        /// <summary>
        /// Get entity by Expression Filter
        /// </summary>
        /// <param name="filter">Expression Filter</param>
        /// <returns>Entity</returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        Task<TEntity> GetAsync(int id);

        /// <summary>
        /// Get entity by Expression Filter
        /// </summary>
        /// <param name="filter">Expression Filter</param>
        /// <returns>bool</returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>bool</returns>
        Task<bool> AnyAsync(int id);



        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Identifier Id</returns>
        Task<IDataResponse<int>> InsertAsync(TEntity entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Response Message</returns>
        Task<IResponse> UpdateAsync(TEntity entity);
        //Task<IResponse> UpdateAsync(TEntity entity,bool isModified);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Response Message</returns>
        Task<IDataResponse<int>> DeleteAsync(TEntity entity);

        IEnumerable<TEntity> GetSql(string sql);
        #endregion
    }
}
