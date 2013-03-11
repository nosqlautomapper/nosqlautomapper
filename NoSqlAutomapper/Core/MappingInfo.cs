﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlAutomapper.Core
{
    public class MappingInfo<TEntity, TModel>
    {
        public Type ReferenceType { get; set; }

        public ITreeNode<SourceTreeNodeData> SourceTree { get; set; }

        public IList<RelatedCollectionInfo> RelatedCollections { get; set; } 
    }
}
