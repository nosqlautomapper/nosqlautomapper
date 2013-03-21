using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlAutomapper.Core
{
    public class TreeNode
    {
        public String PropertyName { get; set; }

        public Object PropertyValue { get; set; }

        public TransitionNodeInfo TransitionNode { get; set; }

        public LambdaExpression Expression { get; set; }

        public IList<TreeNode> Children { get; set; } 
    }
}
