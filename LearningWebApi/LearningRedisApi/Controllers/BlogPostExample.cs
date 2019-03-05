using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using ServiceStack.Redis;

namespace LearningRedisApi.Controllers
{
    public class BlogPostExample
    {
        readonly RedisClient redis = new RedisClient("localhost");

      
        public void OnBeforeEachTest()
        {
            redis.FlushAll();
            InsertTestData();
        }

        public void InsertTestData()
        {
            var redisUsers = redis.As<User>();
            var redisBlogs = redis.As<Blog>();
            var redisBlogPosts = redis.As<BlogPost>();

            var yangUser = new User { Id = redisUsers.GetNextSequence(), Name = "Eric Yang" };
            var zhangUser = new User { Id = redisUsers.GetNextSequence(), Name = "Fish Zhang" };

            var yangBlog = new Blog
            {
                Id = redisBlogs.GetNextSequence(),
                UserId = yangUser.Id,
                UserName = yangUser.Name,
                Tags = new List<string> { "Architecture", ".NET", "Databases" },
            };

            var zhangBlog = new Blog
            {
                Id = redisBlogs.GetNextSequence(),
                UserId = zhangUser.Id,
                UserName = zhangUser.Name,
                Tags = new List<string> { "Architecture", ".NET", "Databases" },
            };

            var blogPosts = new List<BlogPost>
    {
        new BlogPost
        {
            Id = redisBlogPosts.GetNextSequence(),
            BlogId = yangBlog.Id,
            Title = "Memcache",
            Categories = new List<string> { "NoSQL", "DocumentDB" },
            Tags = new List<string> {"Memcache", "NoSQL", "JSON", ".NET"} ,
            Comments = new List<BlogPostComment>
            {
                new BlogPostComment { Content = "First Comment!", CreatedDate = DateTime.UtcNow,},
                new BlogPostComment { Content = "Second Comment!", CreatedDate = DateTime.UtcNow,},
            }
        },
        new BlogPost
        {
            Id = redisBlogPosts.GetNextSequence(),
            BlogId = zhangBlog.Id,
            Title = "Redis",
            Categories = new List<string> { "NoSQL", "Cache" },
            Tags = new List<string> {"Redis", "NoSQL", "Scalability", "Performance"},
            Comments = new List<BlogPostComment>
            {
                new BlogPostComment { Content = "First Comment!", CreatedDate = DateTime.UtcNow,}
            }
        },
        new BlogPost
        {
            Id = redisBlogPosts.GetNextSequence(),
            BlogId = yangBlog.Id,
            Title = "Cassandra",
            Categories = new List<string> { "NoSQL", "Cluster" },
            Tags = new List<string> {"Cassandra", "NoSQL", "Scalability", "Hashing"},
            Comments = new List<BlogPostComment>
            {
                new BlogPostComment { Content = "First Comment!", CreatedDate = DateTime.UtcNow,}
            }
        },
        new BlogPost
        {
            Id = redisBlogPosts.GetNextSequence(),
            BlogId = zhangBlog.Id,
            Title = "Couch Db",
            Categories = new List<string> { "NoSQL", "DocumentDB" },
            Tags = new List<string> {"CouchDb", "NoSQL", "JSON"},
            Comments = new List<BlogPostComment>
            {
                new BlogPostComment {Content = "First Comment!", CreatedDate = DateTime.UtcNow,}
            }
        },
    };

            

            redisUsers.Store(yangUser);
            redisUsers.Store(zhangUser);
            redisBlogs.StoreAll(new[] { yangBlog, zhangBlog });
            redisBlogPosts.StoreAll(blogPosts);
        }
    }
}
