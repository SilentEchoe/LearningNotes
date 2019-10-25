using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazyload
{
    class Program
    {
      
        static void Main(string[] args)
        {
            //Lazy<string> s = new Lazy<string>(TestLazy.GetString);

            //Console.WriteLine(s.IsValueCreated);
            //Console.WriteLine(s.Value);
            //Console.WriteLine(s.IsValueCreated);


            BlogUser blogUser = new BlogUser(1);
            Console.WriteLine("blogUser has been initialized");

            foreach (var article in blogUser.Articles.Value)
            {
                Console.WriteLine(article.Title);
            }

            Console.Read();
        }
    }

    public static class TestLazy
    {
        public static string GetString()
        {
            return DateTime.Now.ToLongDateString();
        }

    }

    public class BlogUser
    {
        public int Id { get; private set; }

        public Lazy<List<Artice>> Articles { get; private set; }

        public BlogUser(int id)
        {
            this.Id = Id;
            Articles = new Lazy<List<Artice>>(()=> ArticleServices.GetArticesByID(id));

        }

    }

    public class Artice
    {
        public int Id { get; set; }

        public string Title { get; set; }


        public DateTime PublishDate { get; set; }
    }


    public class ArticleServices
    {
        public static List<Artice> GetArticesByID(int blogUserID)
        {
            List<Artice> articles = new List<Artice> {
                new Artice{Id=1,Title="Lazy Load",PublishDate=DateTime.Parse("2011-4-20")},
                new Artice{Id=2,Title="Delegate",PublishDate=DateTime.Parse("2011-4-21")},
                new Artice{Id=3,Title="Event",PublishDate=DateTime.Parse("2011-4-22")},
                new Artice{Id=4,Title="Thread",PublishDate=DateTime.Parse("2011-4-23")}
            };
            Console.WriteLine("Artice Initalizer");
            return articles;
        }


    }








}
