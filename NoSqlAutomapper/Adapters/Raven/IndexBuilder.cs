using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Indexes;

namespace NoSqlAutomapper.Adapters.Raven
{
    public class IndexBuilder<TEntity, TModel>
    {
        public String IndexName
        {
            get { return typeof (TEntity).Name + "By" + typeof (TModel).Name; }            
        }

        public IndexDefinitionBuilder<TEntity, TModel> BuildIndex()
        {
            return null;
        }
    }
}
