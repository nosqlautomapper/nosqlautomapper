 
using System.Collections.Generic;
using NoSqlAutomapper;

namespace DomainReference
{
    using NoSqlAutomapper.Test.Domain;
    using DomainReference.ECommerce;
    using DomainReference.Localization;
    using DomainReference.Content;
    using DomainReference.Content.Blogs;
    using DomainReference.Content.Pages;
    using DomainReference.Locations;
    using DomainReference.Users;

    public class EntityBaseRef : EntityBase
    {
    }
}
namespace DomainReference.ECommerce
{
    using DomainReference;
    using NoSqlAutomapper.Test.Domain.ECommerce;
    using DomainReference.Localization;
    using DomainReference.Content;
    using DomainReference.Content.Blogs;
    using DomainReference.Content.Pages;
    using DomainReference.Locations;
    using DomainReference.Users;

    public class ProductCategoryRef : ProductCategory
    {
        public LanguageRef Language 
		{ 
			get { return NoSqlMapper.LoadEntity<LanguageRef>(LanguageId); } 
		}

    }
    public class ShopRef : Shop
    {
        public SellerRef Owner 
		{ 
			get { return NoSqlMapper.LoadEntity<SellerRef>(OwnerId); } 
		}

        public LanguageRef Language 
		{ 
			get { return NoSqlMapper.LoadEntity<LanguageRef>(LanguageId); } 
		}

    }
    public class ProductImageInfoRef : ProductImageInfo
    {
    }
    public class ProductRef : Product
    {
        public ShopRef Shop 
		{ 
			get { return NoSqlMapper.LoadEntity<ShopRef>(ShopId); } 
		}

        public IEnumerable<ProductCategoryRef> Categories 
		{ 
			get { return NoSqlMapper.LoadEntityCollection<ProductCategoryRef>(CategoriesIds); } 
		}

    }
}
namespace DomainReference.Localization
{
    using DomainReference;
    using DomainReference.ECommerce;
    using NoSqlAutomapper.Test.Domain.Localization;
    using DomainReference.Content;
    using DomainReference.Content.Blogs;
    using DomainReference.Content.Pages;
    using DomainReference.Locations;
    using DomainReference.Users;

    public class LanguageRef : Language
    {
    }
}
namespace DomainReference.Content
{
    using DomainReference;
    using DomainReference.ECommerce;
    using DomainReference.Localization;
    using NoSqlAutomapper.Test.Domain.Content;
    using DomainReference.Content.Blogs;
    using DomainReference.Content.Pages;
    using DomainReference.Locations;
    using DomainReference.Users;

    public class MenuItemRef : MenuItem
    {
        public CMSPageRef CMSPage 
		{ 
			get { return NoSqlMapper.LoadEntity<CMSPageRef>(CMSPageId); } 
		}

        public IEnumerable<MenuItemRef> ChildMenuItem 
		{ 
			get { return NoSqlMapper.LoadEntityCollection<MenuItemRef>(ChildMenuItemIds); } 
		}

    }
    public class CommentRef : Comment
    {
        public CommentRef ParentComment 
		{ 
			get { return NoSqlMapper.LoadEntity<CommentRef>(ParentCommentId); } 
		}

        public UserRef User 
		{ 
			get { return NoSqlMapper.LoadEntity<UserRef>(UserId); } 
		}

    }
}
namespace DomainReference.Content.Blogs
{
    using DomainReference;
    using DomainReference.ECommerce;
    using DomainReference.Localization;
    using DomainReference.Content;
    using NoSqlAutomapper.Test.Domain.Content.Blogs;
    using DomainReference.Content.Pages;
    using DomainReference.Locations;
    using DomainReference.Users;

    public class BlogPostRef : BlogPost
    {
        public UserRef Author 
		{ 
			get { return NoSqlMapper.LoadEntity<UserRef>(AuthorId); } 
		}

        public LanguageRef Languige 
		{ 
			get { return NoSqlMapper.LoadEntity<LanguageRef>(LanguigeId); } 
		}

        public IEnumerable<CommentRef> Comments 
		{ 
			get { return NoSqlMapper.LoadEntityCollection<CommentRef>(CommentsIds); } 
		}

    }
}
namespace DomainReference.Content.Pages
{
    using DomainReference;
    using DomainReference.ECommerce;
    using DomainReference.Localization;
    using DomainReference.Content;
    using DomainReference.Content.Blogs;
    using NoSqlAutomapper.Test.Domain.Content.Pages;
    using DomainReference.Locations;
    using DomainReference.Users;

    public class PageMetadataRef : PageMetadata
    {
    }
    public class CMSPageRef : CMSPage
    {
        public LanguageRef Language 
		{ 
			get { return NoSqlMapper.LoadEntity<LanguageRef>(LanguageId); } 
		}

        public IEnumerable<CommentRef> Comments 
		{ 
			get { return NoSqlMapper.LoadEntityCollection<CommentRef>(CommentsIds); } 
		}

    }
}
namespace DomainReference.Locations
{
    using DomainReference;
    using DomainReference.ECommerce;
    using DomainReference.Localization;
    using DomainReference.Content;
    using DomainReference.Content.Blogs;
    using DomainReference.Content.Pages;
    using NoSqlAutomapper.Test.Domain.Locations;
    using DomainReference.Users;

    public class CountryRef : Country
    {
    }
    public class CityRef : City
    {
    }
}
namespace DomainReference.Users
{
    using DomainReference;
    using DomainReference.ECommerce;
    using DomainReference.Localization;
    using DomainReference.Content;
    using DomainReference.Content.Blogs;
    using DomainReference.Content.Pages;
    using DomainReference.Locations;
    using NoSqlAutomapper.Test.Domain.Users;

    public class BuyerRef : Buyer
    {
        public UserProfileRef UserProfile 
		{ 
			get { return NoSqlMapper.LoadEntity<UserProfileRef>(UserProfileId); } 
		}

    }
    public class SellerRef : Seller
    {
    }
    public class AddressInfoRef : AddressInfo
    {
    }
    public class UserProfileRef : UserProfile
    {
    }
    public class UserRef : User
    {
    }
}

