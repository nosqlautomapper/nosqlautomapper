using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoSqlAutomapper.Metadata;

namespace NoSqlAutomapper.Test.Domain.Users
{
    public class Buyer: User
    {
        [ReferenceTo(typeof(UserProfile))]
        public String UserProfileId { get; set; }
    }
}
