using ATDDotNetTrainingBatch2.MiniPOS.Database.AppDbContextModels;
using ATDDotNetTrainingBatch2.MiniPOS.Domain.Features;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDDotNetTrainingBatch2.MiniPosConsoleApp
{
    public class SaleUI
    {
        public void Execute()
        {
        Result:
            Console.WriteLine("Sale Menu");
            Console.WriteLine("----------------------");
            Console.WriteLine("1. New Sale");
            Console.WriteLine("2. Sale Summary List");
            Console.WriteLine("3. Sale Detail List");
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

            Console.WriteLine("----------------------");
            EnumSaleMenu menu = (EnumSaleMenu)no;
            switch (menu)
            {
                
                case EnumSaleMenu.NewSale:
                    NewSale();
                    break;
                case EnumSaleMenu.SaleSummaryListing:
                    SaleSummaryListing();
                    break;
                case EnumSaleMenu.SaleDetailListing:
                    SaleDetailListing();
                    break;
                case EnumSaleMenu.Exit:
                    break;
                case EnumSaleMenu.None:
                default:
                    Console.WriteLine("Invalid Product Menu, Please choose 1 to 4");
                    goto Result;
            }
            Console.WriteLine("----------------------");
            goto Result;

        End:
            Console.WriteLine("Exiting Product Menu....");
        }


        public void NewSale()// UI/ API/ Web
        {
            SaleService saleService = new SaleService(); 
            List<TblSaleDetail> products = new List<TblSaleDetail>();

        FirstPage:
            #region  Prepare Products

            Console.Write("Please enter Product id: ");
            string  id = Console.ReadLine()!;
            bool isInt = int.TryParse(id, out int Id);
            if (!isInt) return;
            //var item = db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            var item = saleService.FindProduct(Id);

            Console.WriteLine($"Product Code:  {item.ProductCode}");
            Console.WriteLine($"Product Name:   {item.ProductItem}");
            Console.WriteLine($"Product Price:  {item.Price}");
            Console.Write("Please enter Product Quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            products.Add(new TblSaleDetail
            {
                ProductCode = item.ProductCode,
                ProductName = item.ProductItem,
                Price = item.Price,
                Qty = quantity,
                Date = DateTime.Now,
                IsDelete = false

            });
            #endregion

            #region Add more product or Continue
            Console.WriteLine("Are you sue want to add more? Y/N ");
            string confirm = Console.ReadLine()!;
            if (confirm == "Y")
            {
                goto FirstPage;
            }
            #endregion

            #region Sale Process

            int result = saleService.Sale(products);
            Console.WriteLine(result > 0 ? "Sale procressing success" : "Failed");

            #endregion

        }
        #region before split with UI and service
        //private TblProduct FindProduct(int id)
        //{
        //    AppDbContext db = new AppDbContext();
        //    var item = db.TblProducts.FirstOrDefault( x => x.ProductId == id);
        //    return item;
        //}

        //public void Sale(List<TblSaleDetail> products)
        //{
        //    AppDbContext db = new AppDbContext();
        //    //List<TblSaleDetail> products = new List<TblSaleDetail>();

        //    #region Generate Sale Summary and create Sale
        //    TblSaleSummary saleSummary = new TblSaleSummary()
        //    {
        //        Total = products.Sum(x => (x.Price * x.Qty)),
        //        IsDelete = false,
        //        Date = DateTime.Now,
        //        InvoiceNo = Guid.NewGuid().ToString()

        //    };

        //    db.TblSaleSummaries.Add(saleSummary);
        //    db.SaveChanges();

        //    #endregion

        //    #region Modify Sale Detail and Create Sale Detail

        //    foreach (var product in products)
        //    {
        //        product.SaleId = saleSummary.SaleId;
        //    }
        //    db.TblSaleDetails.AddRange(products);
        //    db.SaveChanges();

        //    #endregion
        //}
        #endregion

        public void SaleSummaryListing()
        {
            Console.WriteLine("*** Sale Summary Listing ***");

            SaleService saleService = new SaleService();
            var saleSummaryListing = saleService.SaleSummaryListing();

            foreach (var item in saleSummaryListing)
            {
                Console.WriteLine("Invoice   => " + item.InvoiceNo);
                Console.WriteLine("Date  => " + item.Date);
                Console.WriteLine("Total  => " + item.Total);
                Console.WriteLine("Is Delete => " + item.IsDelete);
                Console.WriteLine("---------------------------------");
            }
        }

        public void SaleDetailListing()
        {
            Console.WriteLine("*** Sale Detail Listing ***");
            SaleService saleService = new SaleService();
            var saleDetailListing = saleService.SaleDetailListing();

            foreach (var item in saleDetailListing)
            {
                Console.WriteLine("SaleId  => " + item.SaleId);
                Console.WriteLine("ProductCode => " + item.ProductCode);
                Console.WriteLine("ProductName => " + item.ProductName);
                Console.WriteLine("Qty => " + item.Qty);
                Console.WriteLine("Price => " + item.Price);
                Console.WriteLine("Date => " + item.Date);
                Console.WriteLine("Is Delete => " + item.IsDelete);
                Console.WriteLine("---------------------------------");

            }

        }

        public enum EnumSaleMenu
        {
            None,
            NewSale,
            SaleSummaryListing,
            SaleDetailListing,
            Exit

        }
    }
}
