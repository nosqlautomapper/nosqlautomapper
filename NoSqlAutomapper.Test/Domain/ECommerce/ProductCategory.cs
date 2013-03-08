using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoSqlAutomapper.Metadata;
using NoSqlAutomapper.Test.Domain.Localization;

namespace NoSqlAutomapper.Test.Domain.ECommerce
{
    public class ProductCategory: EntityBase
    {
        public String Title { get; set; }

        [ReferenceTo(typeof(Language))]
        public String LanguageId { get; set; }
    }
}
