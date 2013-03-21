using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NoSqlAutomapper.Core;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace NoSqlAutomapper.Adapters.Raven
{
    public class IndexBuilder<TEntity, TModel>
    {
        private const String VariablePrefix = "this_";

        public String IndexName
        {
            get { return typeof (TEntity).Name + "By" + typeof (TModel).Name; }            
        }

        public IndexDefinition BuildIndex(MappingInfo<TEntity, TModel> mappingInfo)
        {
            var index = new IndexDefinition();

            index.Map = BuildMap(mappingInfo);

            return index;
        }

        private String BuildMap(MappingInfo<TEntity, TModel> mappingInfo)
        {
            var sb = new StringBuilder();

            var index = 0;
            sb.AppendLine(String.Format("from {0}{1} in docs.{2} ", VariablePrefix, index));

            foreach (var node in mappingInfo.TransitionNodes)
            {
                index++;
                sb.AppendLine(String.Format("let {0}{1} = {2}.Select(id => LoadDocument(id))", VariablePrefix, index,
                                                GetPropertyExpression(node.PropertyIdPath, 0)));
            }

            sb.AppendFormat("select {0}", GetSelectExpression(mappingInfo.ModelProperties, mappingInfo.TransitionNodes));

            return sb.ToString();
        }

        private String GetPropertyExpression(String propertyPath, int level)
        {
            if (propertyPath.Contains(Constants.PropertyPathCollectionSeparator))
            {
                var parts = propertyPath.Split(new[] {Constants.PropertyPathCollectionSeparator},
                                               StringSplitOptions.None);

                return String.Format("{0}.SelectMany(x{1} => x{1}.{2})", parts[0], level,
                                     GetPropertyExpression(
                                         String.Join(Constants.PropertyPathCollectionSeparator, parts.Skip(1)),
                                         level + 1));
            }

            return propertyPath;
        }

        private String GetSelectExpression(IList<TreeNode> nodes, IList<TransitionNodeInfo> transitionNodes)
        {
            var sb = new StringBuilder();
            sb.AppendLine("new {");

            foreach (var treeNode in nodes)
            {
                sb.AppendLine(String.Format("{0} = {1},", treeNode.PropertyName, GetPropertyValueExpression(treeNode, transitionNodes)));
            }

            sb.AppendLine("}");

            return sb.ToString();
        }

        private String GetPropertyValueExpression(TreeNode node, IList<TransitionNodeInfo> transitionNodes)
        {
            if (node.PropertyValue != null)
            {
                return node.PropertyValue.ToString();
            }

            var transitionNodeIndex = node.TransitionNode == null ? 0 : transitionNodes.IndexOf(node.TransitionNode) + 1;

            if (node.Expression != null)
            {
                return String.Format("{0}{1}.{2}", VariablePrefix, transitionNodeIndex, GetExpressionText(node.Expression));
            }

            return GetSelectExpression(node.Children, transitionNodes);
        }

        private String GetExpressionText(LambdaExpression expression)
        {
            var parts = expression.ToString().Split('.');

            return String.Join(".", parts.Skip(1));
        }
    }
}
