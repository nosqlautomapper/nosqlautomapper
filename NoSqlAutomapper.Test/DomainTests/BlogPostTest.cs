using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainReference.Content;
using DomainReference.Content.Blogs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoSqlAutomapper.Test.Domain.Content;
using NoSqlAutomapper.Test.Domain.Content.Blogs;
using NoSqlAutomapper.Test.Domain.Users;
using Raven.Abstractions.Linq;
using Raven.Client;
using Raven.Client.Linq;

namespace NoSqlAutomapper.Test.DomainTests
{
    [TestClass]
    public class BlogPostTest: DomainTestBase
    {
        private class BlogPostDTO
        {
            public String Title { get; set; }

            public String Content { get; set; }

            public String[] Tags { get; set; }

            public String AuthorName { get; set; }

            public IList<CommentDTO> Comments { get; set; }  
        }

        private class CommentDTO
        {
            public String Content { get; set; }

            public DateTimeOffset CreatedAt { get; set; }

            public String UserName { get; set; }
        }

        public class UserDto
        {
            public String Login { get; set; }

            public String Email1 { get; set; }

            public String Hash { get; set; }

            public String Salt { get; set; }
        }

        [TestMethod]
        public void MapBlogPosts()
        {
            var user1 = new User() {Login = "user1", Email = "teset@test.com"};
            var user2 = new User() {Login = "user2", Email = "teset@test.com"};
            var user3 = new User() {Login = "user3", Email = "teset@test.com"};

            Session.Store(user1);
            Session.Store(user2);
            Session.Store(user3);

            var comment1 = new Comment() {Content = "CommentContent1", UserId = user2.Id};
            var comment2 = new Comment() {Content = "CommentContent2", UserId = user3.Id};

            Session.Store(comment1);
            Session.Store(comment2);

            var post1 = new BlogPost() {AuthorId = user1.Id, Content = "Content1", Title = "Title1", CommentsIds = new List<String>(){comment1.Id, comment2.Id}};

            Session.Store(post1);
            Session.SaveChanges();

            Configuration.CreateMap<BlogPostRef, BlogPostDTO>()
                         .ForMember(x => x.AuthorName, opt => opt.MapFrom(x => x.Author.Login));

            Configuration.CreateMap<CommentRef, CommentDTO>()
                         .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.User.Login));

            var postDto = NoSqlMapper.GetModelAndMapFromEntity<BlogPost, BlogPostDTO>(post1.Id);

            Assert.AreEqual(postDto.Content, post1.Content);
            Assert.AreEqual(postDto.Title, post1.Title);
            Assert.AreEqual(postDto.AuthorName, user1.Login);
            Assert.AreEqual(postDto.Comments.Count, 2);
            Assert.AreEqual(postDto.Comments[0].Content, comment1.Content);
            Assert.AreEqual(postDto.Comments[0].UserName, user2.Login);
        }
    }
}
