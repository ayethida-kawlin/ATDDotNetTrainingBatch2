// See https://aka.ms/new-console-template for more information

using ATDDotNetTrainingBatch2.MiniPosConsoleApp;

Console.Write("Welcome, Mini POS");

Result:
Console.WriteLine("Menus");
Console.WriteLine("----------------------");
Console.WriteLine("1. Product");
Console.WriteLine("2. Sales Summary listing ");
Console.WriteLine("3. Sales Detail Listing ");
Console.WriteLine("4. Exit");
Console.WriteLine("----------------------");

Console.Write("Choose Menu: ");
string result = Console.ReadLine()!;
bool isInt = int.TryParse(result, out int no);
if (!isInt)
{
    Console.WriteLine("Invalid Product Menu, Please choose 1 to 4");
    goto Result;
}

EnumMenu menu = (EnumMenu)no;
switch (menu)
{
    
    case EnumMenu.Product:
        ProductService productService = new ProductService();
        productService.Execute();
        goto Result;
    case EnumMenu.SaleSummary:
        SalesSummaryService saleSummary = new SalesSummaryService();
        saleSummary.Execute();
        break;
    case EnumMenu.SaleDetail:
        SalesDetailService saleDetailService =  new SalesDetailService();
        saleDetailService.Execute();
        break;
    case EnumMenu.Exit:
        goto End;
    case EnumMenu.None:
    default:
        Console.WriteLine("Invalid Product Menu, Please choose 1 to 4");
        goto Result;
}

End:
Console.WriteLine("Exiting Mini POS ...");

//ProductService product = new ProductService();
//product.Read();
//product.Edit();
//product.Create();
//product.Update();
//product.Delete();
//product.Execute();

//SalesDetailService saleListing = new SalesDetailService();
//saleListing.Read();
//saleListing.Edit();
//saleListing.Create();

//SalesSummaryService saleSummary = new SalesSummaryService();
//saleSummary.Read();
//saleSummary.Edit();
//saleSummary.Create();

public enum EnumMenu
{
    None,
    Product,
    SaleSummary,
    SaleDetail,
    Exit
}