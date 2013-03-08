using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoSqlAutomapper.Metadata;

namespace NoSqlAutomapper.Test.Domain.ECommerce
{
    public class Product: EntityBase
    {
        public String Title { get; set; }

        public String Description { get; set; }

        public String ShortDescription { get; set; }

        public IList<ProductImageInfo> Images { get; set; }

        [ReferenceTo(typeof(Shop))]
        public String ShopId { get; set; }

        [ReferenceTo(typeof(ProductCategory))]
        public ICollection<ProductCategory> CategoriesIds { get; set; } 
    }
}
