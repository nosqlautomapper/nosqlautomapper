using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlAutomapper.Core
{
    public class SourceTreeNodeData
    {
        public Type Type { get; set; }

        public String Name { get; set; }

        public bool IsCollection { get; set; }

        public bool IsComplexObject { get; set; }
    }
}
