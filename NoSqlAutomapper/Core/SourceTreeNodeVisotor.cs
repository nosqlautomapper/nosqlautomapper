using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlAutomapper.Core
{
    public class SourceTreeNodeVisotor: ITreeNodeVisitor<SourceTreeNodeData>
    {
        public SourceTreeNodeData VisitComplexProperty(PropertyInfo property)
        {
            throw new NotImplementedException();
        }

        public SourceTreeNodeData VisitSimpleProperty(PropertyInfo property)
        {
            throw new NotImplementedException();
        }

        public SourceTreeNodeData VisitCollection(PropertyInfo property)
        {
            throw new NotImplementedException();
        }

        public SourceTreeNodeData VisitCollectionComplexItem(PropertyInfo property, Type itemType)
        {
            throw new NotImplementedException();
        }

        public SourceTreeNodeData VisitCollectionSimpleItem(PropertyInfo property, Type itemType)
        {
            throw new NotImplementedException();
        }
    }
}
