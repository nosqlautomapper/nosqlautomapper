using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlAutomapper.Core
{
    public class RelatedCollectionInfo
    {
        public Type ContainingEntityType { get; set; }

        public String PropertyName { get; set; }
    }
}
