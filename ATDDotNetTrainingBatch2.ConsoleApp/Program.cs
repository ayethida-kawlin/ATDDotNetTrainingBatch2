// See https://aka.ms/new-console-template for more information
using ATDDotNetTrainingBatch2.ConsoleApp;
using ATDDotNetTrainingBatch2.Database;
using ATDDotNetTrainingBatch2.Database.App2DbContextModels;
using Microsoft.Data.SqlClient;
using System.Data;

//using PLM = ATDDotNetTrainingBatch2.Database.AppDbContextModels.AppDbContext //If the same name


Console.WriteLine("Hello, World!");

//AdoDoNetExample adoDoNetExample = new AdoDoNetExample();
//adoDoNetExample.Read();
//adoDoNetExample.Edit();
//adoDoNetExample.Create();
//adoDoNetExample.Update();
//adoDoNetExample.Delete();

//DapperExample dapperExample=new DapperExample();
//dapperExample.Read();
//dapperExample.Edit();
//dapperExample.Create();
//dapperExample.Update();
//dapperExample.Delete();

EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Read();
eFCoreExample.Edit();
//eFCoreExample.Create();
//eFCoreExample.Update();
//eFCoreExample.Delete();

//Class1 class1 = new Class1();
//int result = class1.Method(1, 2);

App2DbContext db = new App2DbContext();
db.TblBlogs.ToList();



Console.ReadKey();

