// See https://aka.ms/new-console-template for more information
using ATDDotNetTrainingBatch2.ConsoleApp;
using Microsoft.Data.SqlClient;
using System.Data;

Console.WriteLine("Hello, World!");

//AdoDoNetExample adoDoNetExample = new AdoDoNetExample();
//adoDoNetExample.Read();
//adoDoNetExample.Edit();
//adoDoNetExample.Create();
//adoDoNetExample.Update();
//adoDoNetExample.Delete();

DapperExample dapperExample=new DapperExample();
//dapperExample.Read();
//dapperExample.Edit();
//dapperExample.Create();
//dapperExample.Update();
dapperExample.Delete();

Console.ReadKey();

