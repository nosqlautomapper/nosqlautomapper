using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoSqlAutomapper.Metadata;
using NoSqlAutomapper.Test.Domain;
using NoSqlAutomapper.Test.Domain.Content.Pages;

namespace NoSqlAutomapper.Test.Domain.Content
{
    //menu item can be either simple menu item that pints to some static page or item that points to some CMSPage
    public class MenuItem: EntityBase
    {
        public String Title { get; set; }

        public String Url { get; set; }

        [ReferenceTo(typeof(CMSPage))]
        public String CMSPageId { get; set; }

        [ReferenceTo(typeof(MenuItem), ReferencePropertyName = "ChildItems")]
        public ICollection<MenuItem> ChildMenuItemIds { get; set; }
    }
}
