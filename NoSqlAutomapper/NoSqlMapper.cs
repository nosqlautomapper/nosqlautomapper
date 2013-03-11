using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using NoSqlAutomapper.Core;
using NoSqlAutomapper.Exceptions;

namespace NoSqlAutomapper
{
    public static class NoSqlMapper
    {
        private static bool initialized;

        private static IDBAdapter adapter;

        private static MappingInfoCache cache;

        private static TypeResolver typeResolver;

        private static Object syncRoot = new Object();

        public static void Init(IDBAdapter adapter)
        {
            lock (syncRoot)
            {
                if (initialized)
                {
                    throw new InitializationException("NoSqlAutompper is already initialized");
                }

                NoSqlMapper.adapter = adapter;
                NoSqlMapper.cache = new MappingInfoCache();
                NoSqlMapper.typeResolver = new TypeResolver();
                initialized = true;
            }
        }

        public static TModel GetModelAndMapFromEntity<TEntity, TModel>(String id)
        {
            CheckInitialized();
            var info = cache.GetMappingInfo<TEntity, TModel>();
            var entity = adapter.LoadWithIncludes(id, info);
            if (entity == null)
            {
                return default(TModel);
            }

            var entityRef = typeResolver.CreateEntityRef(entity);

            return Mapper.Map<TModel>(entityRef);
        }

        public static TEntity GetEntityAndMapFromModel<TEntity, TModel>(String id, TModel model)
        {
            CheckInitialized();
            var info = cache.GetMappingInfo<TEntity, TModel>();
            var entity = adapter.LoadWithIncludes(id, info);
            if (entity == null)
            {
                return entity;
            }

            var entityRef = typeResolver.CreateEntityRef(entity);

            Mapper.Map(model, entityRef);

            return entity;
        }

        public static TEntity LoadEntity<TEntity>(String id)
        {
            return default(TEntity);
        }

        public static IEnumerable<TEntity> LoadEntityCollection<TEntity>(IEnumerable<String> id)
        {
            return new List<TEntity>();
        }

        public static IQueryable<TModel> Query<TEntity, TModel>()
        {
            CheckInitialized();
            var info = cache.GetMappingInfo<TEntity, TModel>();
            var query = adapter.Query(info);

            return query.Project().To<TModel>();
        }

        private static void CheckInitialized()
        {
            if (!initialized)
            {
                throw new InitializationException("NoSqlAutompper is not initialized, you should call method Init() first.");
            }
        }
    }
}
