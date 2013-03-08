using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoSqlAutomapper.Metadata;
using NoSqlAutomapper.Test.Domain.Localization;

namespace NoSqlAutomapper.Test.Domain.Content.Pages
{
    public class CMSPage: EntityBase
    {
        public String Title { get; set; }

        public String Content { get; set; }

        public PageStatus Status { get; set; }

        public PageMetadata Metadta { get; set; }

        [ReferenceTo(typeof(Language))]
        public String LanguageId { get; set; }

        [ReferenceTo(typeof(Comment))]
        public ICollection<String> CommentsIds { get; set; } 
    }
}
