using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlAutomapper.Core
{
    public interface ITreeNodeVisitor<T>
    {
        T VisitComplexProperty(PropertyInfo property);

        T VisitSimpleProperty(PropertyInfo property);

        T VisitCollection(PropertyInfo property);

        T VisitCollectionComplexItem(PropertyInfo property, Type itemType);

        T VisitCollectionSimpleItem(PropertyInfo property, Type itemType);
    }
}
