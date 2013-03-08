using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlAutomapper.Test.Domain.Locations
{
    public class Country: EntityBase
    {
        public String Title { get; set; }

        public ICollection<String> CityIds { get; set; } 
    }
}
