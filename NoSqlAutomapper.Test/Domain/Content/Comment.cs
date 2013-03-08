using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoSqlAutomapper.Metadata;
using NoSqlAutomapper.Test.Domain.Users;

namespace NoSqlAutomapper.Test.Domain.Content
{
    public class Comment: EntityBase
    {
        public String Content { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        [ReferenceTo(typeof(Comment))]
        public String ParentCommentId { get; set; }

        [ReferenceTo(typeof(User))]
        public String UserId { get; set; }
    }
}
