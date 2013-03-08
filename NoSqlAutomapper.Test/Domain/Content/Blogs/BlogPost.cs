using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoSqlAutomapper.Metadata;
using NoSqlAutomapper.Test.Domain.Localization;
using NoSqlAutomapper.Test.Domain.Users;

namespace NoSqlAutomapper.Test.Domain.Content.Blogs
{
    public class BlogPost: EntityBase
    {
        public String Title { get; set; }

        public String Content { get; set; }

        public String[] Tags { get; set; }

        [ReferenceTo(typeof(User))]
        public String AuthorId { get; set; }

        [ReferenceTo(typeof(Language))]
        public String LanguigeId { get; set; }

        [ReferenceTo(typeof(Comment))]
        public ICollection<Comment> CommentsIds { get; set; } 
    }
}
