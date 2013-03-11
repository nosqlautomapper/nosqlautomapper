using System;
using System.Collections.Generic;
using System.Linq;
using NoSqlAutomapper.Core;

namespace NoSqlAutomapper
{
    public interface IDBAdapter
    {
        TEntity LoadWithIncludes<TEntity, TModel>(String id, MappingInfo<TEntity, TModel> mappingInfo);

        TEntity Load<TEntity>(String id);

        IEnumerable<TEntity> Load<TEntity>(IEnumerable<String> ids);

        IQueryable<dynamic> Query<TEntity, TModel>(MappingInfo<TEntity, TModel> mappingInfo);
    }
}
