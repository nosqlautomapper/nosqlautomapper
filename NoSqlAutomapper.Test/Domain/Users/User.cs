using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoSqlAutomapper.Metadata;

namespace NoSqlAutomapper.Test.Domain.Users
{
    public class User: EntityBase
    {
        public String Login { get; set; }

        public String Email { get; set; }

        public String Hash { get; set; }

        public String Salt { get; set; }
    }
}
