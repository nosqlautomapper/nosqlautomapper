using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlAutomapper.Test.Domain.Locations
{
    public class City: EntityBase
    {
        public String Title { get; set; }

        public String Region { get; set; }

        public String CountryId { get; set; }
    }
}
