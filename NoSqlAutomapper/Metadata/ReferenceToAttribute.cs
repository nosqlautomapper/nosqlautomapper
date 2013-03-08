using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlAutomapper.Metadata
{
    public class ReferenceToAttribute : Attribute
    {
        public Type Type { get; set; }

        public String ReferencePropertyName { get; set; }

        public ReferenceToAttribute(Type type)
        {
            Type = type;
        }

    }
}
