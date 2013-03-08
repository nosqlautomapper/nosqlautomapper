using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlAutomapper.Test.Domain.Content.Pages
{
    public class PageMetadata
    {
        public String MetaTitle { get; set; }

        public String MetaDescription { get; set; }

        public String Author { get; set; }

        public String[] MetaKeywords { get; set; }
    }
}
