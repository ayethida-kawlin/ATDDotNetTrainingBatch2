using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ATDDotNetTrainingBatch2.ConsoleApp
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<BlogModel> lst = db.Blogs
                .Where(x => x.IsDelete == false)
                .OrderByDescending(x => x.BlogId)
                .ToList();
            foreach (var item in lst)
            {
                Console.WriteLine("BlogId => " + item.BlogId);
                Console.WriteLine("BlotTitle => " + item.BlogTitle);
                Console.WriteLine("BlogAuthor => " + item.BlogAuthor);
                Console.WriteLine("BlogContent => " + item.BlogContent);
            }
        }

        public void Edit()
        {
            Console.Write("Enter Id: ");
            string result=Console.ReadLine()!;

            bool isInt = int.TryParse(result, out int id);
            if (!isInt) return;

            AppDbContext db = new AppDbContext();
            var item = db.Blogs
                .Where(x => x.IsDelete == false)
                .FirstOrDefault(x => x.BlogId == id); // Top 2
            if (item is null)
            {
                return;
            }

            Console.WriteLine("BlogId => " + item.BlogId);
            Console.WriteLine("BlotTitle => " + item.BlogTitle);
            Console.WriteLine("BlogAuthor => " + item.BlogAuthor);
            Console.WriteLine("BlogContent => " + item.BlogContent);


            //foreach (var x in db.Blogs)
            //{
            //    if(x.BlogId == id)
            //    {
            //        return x;
            //    }
            //}
        }

        public void Create()
        {
            Console.Write("Enter Title: ");
            string title= Console.ReadLine()!;
            Console.Write("Enter Author: ");
            string author= Console.ReadLine()!;
            Console.Write("Enter Content: ");
            string content= Console.ReadLine()!;

            BlogModel blog = new BlogModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
                IsDelete = false
            };

            AppDbContext db = new AppDbContext();
            db.Blogs.Add(blog);
            int result= db.SaveChanges();

            Console.WriteLine(result > 0 ? "String Successful" : " Saving Fail");
        }

        public void Update()
        {
            //Import Id
            Console.Write("Enter Id: ");
            string input = Console.ReadLine()!;

            bool isInt = int.TryParse(input, out int id);
            if (!isInt) return;

            // Read Import Data from Console
            Console.Write("Modify Title: ");
            string title = Console.ReadLine()!;
            Console.Write("Modify Author: ");
            string author = Console.ReadLine()!;
            Console.Write("Modify Content: ");
            string content = Console.ReadLine()!;

            // Find Blog id
            bool isExit = IsExitBlog(id);
            if(!isExit)  return;

            // Update Process
            AppDbContext db = new AppDbContext();
            var item = db.Blogs
                .Where(x => x.IsDelete == false)
                .FirstOrDefault(x => x.BlogId == id);
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;
            var result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Update Successful" : " Updating Fail");


        }
        public void Delete()
        {
            //Import Id
            Console.Write("Enter Id: ");
            string input = Console.ReadLine()!;

            bool isInt = int.TryParse(input, out int id);
            if (!isInt) return;

            // Find Blof Id
            bool isExit = IsExitBlog(id);
            if (!isExit) return;

            // Delete Process
            AppDbContext db = new AppDbContext();   
            var item = db.Blogs.FirstOrDefault( x => x.BlogId == id);
            //db.Blogs.Remove(item);
            item.IsDelete = true;
            var result = db.SaveChanges();
            Console.WriteLine(result > 0 ? "Delete Successful" : " Deleting Fail");

        }

        private bool IsExitBlog(int id)
        {
            
            AppDbContext db = new AppDbContext();
            var item = db.Blogs
                .Where(x => x.IsDelete == false)
                .FirstOrDefault(x => x.BlogId == id); // Top 2
            //return item ==null ? true : false;
            //return item == null;
            return item != null;
        }
    }
}
