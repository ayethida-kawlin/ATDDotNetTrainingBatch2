using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDDotNetTrainingBatch2.ConsoleApp
{
    public class DapperExample
    {
        //Read
        //Edit
        //Create
        //Update
        //Delete

        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch2",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public void Read()
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                List<BlogDto> lst = db.Query<BlogDto>("select * from Tbl_Blog").ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine("BlogId => " + item.BlogId);
                    Console.WriteLine("BlotTitle => " + item.BlogTitle);
                    Console.WriteLine("BlogAuthor => " + item.BlogAuthor);
                    Console.WriteLine("BlogContent => " + item.BlogContent);
                }
            }

        }
        public void Edit()
        {
        FirstPage:
            //Object a = new{BlogId = 1, BlogTitle="Mg Mg"}; // Anonymous Type
            Console.Write("Enter Id: ");
            string input = Console.ReadLine()!;
            bool isInt = int.TryParse(input, out int id);
            //if (isInt == true)
            if (!isInt)
            {
                Console.WriteLine("Invalid Id. Please enter a valid integer.");
                //return;
                goto FirstPage;

            }

            //int id= Convert.ToInt32();
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                var item = db.QueryFirstOrDefault<BlogDto>("select * from Tbl_Blog where BlogId = @BlogId", new BlogDto { BlogId = id });
                if (item == null)
                {
                    Console.WriteLine("Blog not foung with id : " + id);
                    return;
                }

                Console.WriteLine("BlogId => " + item.BlogId);
                Console.WriteLine("BlotTitle => " + item.BlogTitle);
                Console.WriteLine("BlogAuthor => " + item.BlogAuthor);
                Console.WriteLine("BlogContent => " + item.BlogContent);
            }

        }
        public void Create()
        {
            Console.Write("Blog Title: ");
            string title = Console.ReadLine()!;
            Console.Write("Blog Author: ");
            string author = Console.ReadLine()!;
            Console.Write("Blog Content: ");
            string content = Console.ReadLine()!;

            BlogDto blog = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                       ([BlogTitle]
                       ,[BlogAuthor]
                       ,[BlogContent]
                       ,[IsDelete])
                  VALUES
                       (@BlogTitle
                       ,@BlogAuthor
                       ,@BlogContent
                       ,0)";
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                int result = db.Execute(query, blog);
                Console.WriteLine(result > 0 ? "String Successful" : " Saving Fail");

            }
        }
        public void Update()
        {


        FirstPage:
            Console.Write("BlogID : ");
            string input = Console.ReadLine()!;

            bool isInt = int.TryParse(input, out int id);
            //if (isInt == true)
            if (!isInt)
            {
                Console.WriteLine("Invalid Id. Please enter a valid integer.");
                //return;
                goto FirstPage;

            }

            Console.Write("Modify Blog Title: ");
            string title = Console.ReadLine()!;
            Console.Write("Modify Blog Author: ");
            string author = Console.ReadLine()!;
            Console.Write("Modify Blog Content: ");
            string content = Console.ReadLine()!;

            BlogDto blog = new BlogDto()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string query = @"UPDATE [dbo].[Tbl_Blog]
                           SET [BlogTitle] = @BlogTitle
                              ,[BlogAuthor] = @BlogAuthor
                              ,[BlogContent] = @BlogContent
                              ,[IsDelete] = 0
                         WHERE BlogId = @BlogId";
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                int result = db.Execute(query, blog);
                Console.WriteLine(result > 0 ? "Updating Successful" : " Update Fail");

            }

        }
        public void Delete()
        {
        FirstPage:
            Console.Write("BlogID : ");
            string input = Console.ReadLine()!;

            bool isInt = int.TryParse(input, out int id);
            //if (isInt == true)
            if (!isInt)
            {
                Console.WriteLine("Invalid Id. Please enter a valid integer.");
                //return;
                goto FirstPage;

            }

            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                var item = db.QueryFirstOrDefault<BlogDto>("select * from Tbl_Blog where BlogId = @BlogId", new BlogDto { BlogId = id });
                if (item == null)
                {
                    Console.WriteLine("Blog not foung with id : " + id);
                    return;
                }

                string query = @"delete from tbl_blog where BlogId = @BlogId";

                var result = db.Execute(query, new BlogDto { BlogId = id });
                Console.WriteLine(result > 0 ? "Deleting Successful" : " Delete Fail");


            }

        }
    }
}
