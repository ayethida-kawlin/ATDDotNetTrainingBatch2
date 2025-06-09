// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using System.Data;

Console.WriteLine("Hello, World!");

SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.DataSource = ".";
//sqlConnectionStringBuilder.DataSource = "(local)";
//sqlConnectionStringBuilder.DataSource = "LAPTOP-EFKNUCJD";
sqlConnectionStringBuilder.InitialCatalog = "DotNetTrainingBatch2";
sqlConnectionStringBuilder.UserID = "sa";
sqlConnectionStringBuilder.Password = "sasa@123";
sqlConnectionStringBuilder.TrustServerCertificate = true;

SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
Console.WriteLine("connnection opening");
connection.Open();
Console.WriteLine("connnection open...");

string query = "select * from Tbl_Student ";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable(); // fill to Data table
adapter.Fill(dt); // Execute

// Data Set : more than one query
for (int i = 0; i < dt.Rows.Count; i++)
{
    DataRow row=dt.Rows[i];
    Console.WriteLine(i);
    Console.WriteLine(row["StudentId"]);
    Console.WriteLine(row["StudentNo"]);
    Console.WriteLine(row["StudentName"]);
}


Console.WriteLine("connnection closing");
connection.Close();
Console.WriteLine("connnection close...");


Console.ReadKey();

