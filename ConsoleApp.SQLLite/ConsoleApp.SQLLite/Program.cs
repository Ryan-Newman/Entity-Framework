using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp.SQLLite
{
    public class Program
    {
        public static void Main()
        {
            using (var db = new BloggingContext())
            {
                //var ryanBlog = new Blog { Url = "http://ryan.com/blog", Author = "Ryan" };
                //var annaBlog = new Blog { Url = "http://anna.com/blog", Author = "Anna" };
                //db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });

                //db.Blogs.Add(ryanBlog);
                //db.Blogs.Add(annaBlog);
                //var count = db.SaveChanges();

                //Console.WriteLine($"{count} records saved to database");

                //db.Posts.Add(new Post { Blog = ryanBlog, Title = "Blog 1" });
                //db.Posts.Add(new Post { Blog = ryanBlog, Title = "Blog 2" });
                //db.Posts.Add(new Post { Blog = annaBlog, Title = "Blog 1" });
                //db.Posts.Add(new Post { Blog = annaBlog, Title = "Blog 2" });
                //count = db.SaveChanges();

                //Console.WriteLine();
                // select count(*) from Blogs
                var blogCount = db.Blogs.Count();
                

                Console.WriteLine($"{db.Blogs.Count()} Posts saved to the database");

                // select * from Blogs;
                var allBlogs = db.Blogs;
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(" - {0}", blog.Url);
                }
                // select Author from Blogs;
                var blogAuthors = db.Blogs.Select(b => b.Author);

                foreach (var author in db.Blogs)
                {
                    Console.WriteLine($" - {author}");
                }
                //select URL from Blogs where Author = 'Ryan';
                var ryansBlog = db.Blogs
                                        .Where(b => b.Author == "Ryan")
                                        .Select(b => b.Url)
                                        .Single();

                Console.WriteLine($"Ryan's blog Url: {ryansBlog}");

                // select BlogID from Blogs where Author = "Anna"
                // select Title from Posts where BlogID = <subquery>
                //var annasBlogID = db.Blogs.Where(b => b.Author == "Anna")
                //                          .Select(b => b.Url)
                //                          .Single();
                //var AnnasPostTitles = db.Posts.Where(p => p.BlogId = annasBlogID)
                //                              .Select(prop => p.Title);
                //Console.WriteLine("\nAnna's posts");

                //foreach (var title in AnnasPostTitles)
                //{
                //    Console.WriteLine($" - {title}");
                //}

            }
        }
    }

}
