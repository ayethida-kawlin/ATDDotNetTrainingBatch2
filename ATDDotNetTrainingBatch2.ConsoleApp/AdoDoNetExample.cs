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
    internal class AdoDoNetExample
    {
        // Ctrl + R, R 
        SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch2",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public void Read() 
        {
            //SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            //sqlConnectionStringBuilder.DataSource = ".";
            ////sqlConnectionStringBuilder.DataSource = "(local)";
            ////sqlConnectionStringBuilder.DataSource = "LAPTOP-EFKNUCJD";
            //sqlConnectionStringBuilder.InitialCatalog = "DotNetTrainingBatch2";
            //sqlConnectionStringBuilder.UserID = "sa";
            //sqlConnectionStringBuilder.Password = "sasa@123";
            //sqlConnectionStringBuilder.TrustServerCertificate = true;

            

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            Console.WriteLine("connnection opening");
            connection.Open();
            Console.WriteLine("connnection open...");

            string query = "select * from Tbl_Blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); // fill to Data table
            adapter.Fill(dt); // Execute

            connection.Close();
            List<BlogDto> lst = new List<BlogDto>(); // usning Dapper

            // Data Set : more than one query
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine(i);
                Console.WriteLine("BlogId=>" + row["BlogId"]);
                Console.WriteLine("BlogTitle=>" + row["BlogTitle"]);
                Console.WriteLine("BlogAuthor=>" + row["BlogAuthor"]);
                Console.WriteLine("BlogContent=>" + row["BlogContent"]);

                BlogDto blog= new BlogDto();
                blog.BlogId = Convert.ToInt32(row["BlogId"]);
                blog.BlogTitle = Convert.ToString(row["BlogTitle"])!;
                blog.BlogAuthor = Convert.ToString(row["BlogAuthor"])!;
                blog.BlogContent = Convert.ToString(row["BlogContent"])!;
                lst.Add(blog);

               }

            foreach (var item in lst)
            {
                Console.WriteLine("BlogId => " + item.BlogId);
                Console.WriteLine("BlotTitle => " + item.BlogTitle);
                Console.WriteLine("BlogAuthor => " + item.BlogAuthor);
                Console.WriteLine("BlogContent => " + item.BlogContent);
            }


            //Console.WriteLine("connnection closing");

            //connection.Close();
            //Console.WriteLine("connnection close...");
        }

        public void Edit()
        {
            Console.Write("Enter ID: ");
            string blogId = Console.ReadLine()!;

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            Console.WriteLine("connnection opening");
            connection.Open();
            Console.WriteLine("connnection open...");

            string query = $"select * from Tbl_Blog where BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", blogId); // to prevent sql injection

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); // fill to Data table
            adapter.Fill(dt); // Execute

            // Data Set : more than one query
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine(i);
                Console.WriteLine("BlogId=>" + row["BlogId"]);
                Console.WriteLine("BlogTitle=>" + row["BlogTitle"]);
                Console.WriteLine("BlogAuthor=>" + row["BlogAuthor"]);
                Console.WriteLine("BlogContent=>" + row["BlogContent"]);
            }


            Console.WriteLine("connnection closing");
            connection.Close();
            Console.WriteLine("connnection close...");
        }

        public void Create()
        {
            Console.Write("Enter Title: ");
            string title= Console.ReadLine()!; // ! ingore Null

            Console.Write("Enter Author: ");
            string author = Console.ReadLine()!;

            Console.Write("Enter Content: ");
            string content = Console.ReadLine()!;

            //string query = $@"INSERT INTO [dbo].[Tbl_Blog] 
            //      ([BlogTitle]
            //      ,[BlogAuthor]
            //      ,[BlogContent])
            //VALUES
            //      ('{title}'
            //      ,'{author}'
            //      ,'{content}')"; // $ call data as Title, author, content with {}

            string query = $@"INSERT INTO [dbo].[Tbl_Blog] 
                  ([BlogTitle]
                  ,[BlogAuthor]
                  ,[BlogContent])
            VALUES
                  (@Title
                  ,@Author
                  ,@Content)";

            SqlConnection connection= new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Author", author);
            cmd.Parameters.AddWithValue("@Content", content);
            int result = cmd.ExecuteNonQuery();


            connection.Close();
            Console.WriteLine(result > 0 ? "insert Success!" : "Insert Fail!");
        }

        public void Update()
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine()!; 

            Console.Write("Enter Author: ");
            string author = Console.ReadLine()!;

            Console.Write("Enter Content: ");
            string content = Console.ReadLine()!;

            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @Title
      ,[BlogAuthor] = @Author
      ,[BlogContent] = @Content
       WHERE BlogId = 7 ";
            
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Author", author);
            cmd.Parameters.AddWithValue("@Content", content);

            int result = cmd.ExecuteNonQuery();


            connection.Close();
            Console.WriteLine(result > 0 ? "Update Success!" : "Update Fail!");
        }

        public void Delete()
        {

            //      string query = @"DELETE FROM [dbo].[Tbl_Blog]
            //WHERE BlogId = 1 ";

            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET IsDelete=1
 WHERE BlogId=2 ";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();


            connection.Close();
            Console.WriteLine(result > 0 ? "Delete Success!" : "Delete Fail!");
        }
    }
}
