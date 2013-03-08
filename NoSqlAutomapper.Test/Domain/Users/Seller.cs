using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlAutomapper.Test.Domain.Users
{
    public class Seller: User
    {
        public String ShopId { get; set; }

        public String PaymentAccountId { get; set; }
    }
}
