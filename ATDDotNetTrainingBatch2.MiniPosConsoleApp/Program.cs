// See https://aka.ms/new-console-template for more information

using ATDDotNetTrainingBatch2.MiniPOS.Domain.Features;
using ATDDotNetTrainingBatch2.MiniPosConsoleApp;

Console.WriteLine("Welcome, Mini POS");

StaffService staffService = new StaffService();
Console.WriteLine("** Staff List ** ");
Console.WriteLine("---------------------------------");
Console.Write("Enter Staff Code: ");
string staffCode = Console.ReadLine()!;
Console.Write("Enter Staff Name: ");
string staffName = Console.ReadLine()!;
Console.Write("Enter Email Address: ");
string email = Console.ReadLine()!;
Console.Write("Enter Password: ");
string password = Console.ReadLine()!;
Console.Write("Enter Position: ");
string position = Console.ReadLine()!;
Console.Write("Enter Mobile No: ");
string mobile = Console.ReadLine()!;
Console.WriteLine("---------------------------------");
staffService.Register(staffCode, staffName, email, password, position, mobile);


#region Call SaleUI only
//SaleUI saleUI = new SaleUI();
//saleUI.Show();
#endregion

#region Call Both ProductUI and SaleUI
Result:
Console.WriteLine("Menus");
Console.WriteLine("----------------------");
Console.WriteLine("1. Product");
Console.WriteLine("2. New Sales");
Console.WriteLine("3. Sale Summary Listing");
Console.WriteLine("4. Sale Detail Listing");
Console.WriteLine("5. Exit");
Console.WriteLine("----------------------");

Console.Write("Choose Menu: ");
string result = Console.ReadLine()!;
bool isInt = int.TryParse(result, out int no);
if (!isInt)
{
    Console.WriteLine("Invalid Product Menu, Please choose 1 to 5");
    goto Result;
}

EnumMenu menu = (EnumMenu)no;
switch (menu)
{

    case EnumMenu.Product:
        ProductUI productUI = new ProductUI();
        productUI.Execute();
        goto Result;
    case EnumMenu.Sale:
        SaleUI newSale = new SaleUI();
        newSale.NewSale();
        goto Result;
    case EnumMenu.SaleSummary:
        SaleUI saleSummary = new SaleUI();
        saleSummary.SaleSummaryListing();
        goto Result;
    case EnumMenu.SaleDetail:
        SaleUI saleDetail = new SaleUI();
        saleDetail.SaleDetailListing();
        goto Result;
    case EnumMenu.Exit:
        goto End;
    case EnumMenu.None:
    default:
        Console.WriteLine("Invalid Product Menu, Please choose 1 to 3");
        goto Result;
}

End:
Console.WriteLine("Exiting Mini POS ...");
#endregion

#region ProductService CRUD
////ProductService product = new ProductService();
////product.Read();
////product.Edit();
////product.Create();
////product.Update();
////product.Delete();
////product.Execute();
#endregion

#region SalesDetailService CR
////SalesDetailService saleListing = new SalesDetailService();
////saleListing.Read();
////saleListing.Edit();
////saleListing.Create();
#endregion

#region SaleSummaryService CR
////SalesSummaryService saleSummary = new SalesSummaryService();
////saleSummary.Read();
////saleSummary.Edit();
////saleSummary.Create();
#endregion

#region Enum
public enum EnumMenu
{
    None,
    Product,
    Sale,
    SaleSummary,
    SaleDetail,
    Exit
}
#endregion