using Jwt.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Core.Repositories
{
    public interface IDataAccessRepository<TEntity>:IRepository<TEntity> where TEntity : class,IBaseEntity,new()
    {
    }
}
