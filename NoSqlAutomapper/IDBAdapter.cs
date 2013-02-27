using System;
using System.Collections.Generic;
using System.Linq;
using NoSqlAutomapper.Core;

namespace NoSqlAutomapper
{
    public interface IDBAdapter
    {
        TEntity LoadWithIncludes<TEntity, TModel>(String id, MappingInfo<TEntity, TModel> mappingInfo);

        IQueryable<Object> Query<TEntity, TModel>(MappingInfo<TEntity, TModel> mappingInfo);
    }
}
