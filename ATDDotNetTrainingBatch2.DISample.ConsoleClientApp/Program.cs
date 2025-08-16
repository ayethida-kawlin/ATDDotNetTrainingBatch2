// See https://aka.ms/new-console-template for more information
using ATDDotNetTrainingBatch2.DISample.ConsoleClientApp;

Console.WriteLine("Hello, World!");

HttpClientService service = new HttpClientService();
await service.RunAsync();
Console.ReadKey();