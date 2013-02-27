using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlAutomapper.Core
{
    public interface ITreeNode<T>
    {
        T Data { get; set; }

        ITreeNode<T> Parent { get; set; }

        ICollection<ITreeNode<T>> Children { get; set; } 
    }
}
