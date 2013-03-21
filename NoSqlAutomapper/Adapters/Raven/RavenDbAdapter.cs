using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoSqlAutomapper.Core;
using Raven.Abstractions.Extensions;
using Raven.Client;
using Raven.Client.Document;

namespace NoSqlAutomapper.Adapters.Raven
{
    public class RavenDbAdapter: IDBAdapter
    {
        private IDocumentStore documentStore;

        private Func<IDocumentSession> session { get; set; }

        private Object indexCreationLock = new Object();

        private IList<String> existedIndexes = new List<String>();

        public RavenDbAdapter(Func<IDocumentSession> session, IDocumentStore documentStore)
        {
            this.session = session;
            this.documentStore = documentStore;
        }

        public TEntity LoadWithIncludes<TEntity, TModel>(String id, MappingInfo<TEntity, TModel> mappingInfo)
        {
            ILoaderWithInclude<Object> loader = null;

            foreach (var info in mappingInfo.TransitionNodes.Where(x => x.ParentNode == null))
            {
                if (loader == null)
                {
                    loader = session().Include(info.PropertyIdPath);
                }
                else
                {
                    loader = loader.Include(info.PropertyIdPath);
                }
            }

            if (loader == null)
            {
                return session().Load<TEntity>(id);
            }

            return loader.Load<TEntity>(id);
        }

        public TEntity Load<TEntity>(String id)
        {
            return session().Load<TEntity>(id);
        }

        public IEnumerable<TEntity> Load<TEntity>(IEnumerable<string> ids)
        {
            return session().Load<TEntity>(ids);
        }

        public IQueryable<dynamic> Query<TEntity, TModel>(MappingInfo<TEntity, TModel> mappingInfo)
        {
            var builder = new IndexBuilder<TEntity, TModel>();

            if (!existedIndexes.Contains(builder.IndexName))
            {
                lock (indexCreationLock)
                {
                    if (!existedIndexes.Contains(builder.IndexName))
                    {
                        documentStore.DatabaseCommands.PutIndex(builder.IndexName, builder.BuildIndex(mappingInfo), true);
                        existedIndexes.Add(builder.IndexName);
                    }
                }
            }

            return session().Query<dynamic>(builder.IndexName);
        }
    }
}
