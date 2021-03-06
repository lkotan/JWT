﻿using Jwt.Core.Signatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Core.Repositories.EF
{
    public class EfDataAccessRepository<TEntity>:EfRepository<TEntity,DbContext>,IDataAccessRepository<TEntity> where TEntity:class,IBaseEntity,new()
    {
        public EfDataAccessRepository(DbContext context):base(context)
        {

        }
    }
}
