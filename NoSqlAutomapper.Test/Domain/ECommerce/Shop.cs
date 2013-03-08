using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoSqlAutomapper.Metadata;
using NoSqlAutomapper.Test.Domain.Users;

namespace NoSqlAutomapper.Test.Domain.ECommerce
{
    public class Shop: EntityBase
    {
        [ReferenceTo(typeof(Seller))]
        public String OwnerId { get; set; }
    }
}
