using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlAutomapper.Test.Domain.Users
{
    public class UserProfile: EntityBase
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Avatar { get; set; }

        public String[] Websites { get; set; }

        public AddressInfo ShippingAddress1 { get; set; }

        public AddressInfo ShippingAddress2 { get; set; }

        public AddressInfo BilingAddress { get; set; }
    }
}
