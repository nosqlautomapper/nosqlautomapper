using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlAutomapper.Core
{
    public class TransitionNodeInfo
    {
        public TransitionNodeInfo ParentNode { get; set; }

        public String PropertyIdPath { get; set; }
    }
}