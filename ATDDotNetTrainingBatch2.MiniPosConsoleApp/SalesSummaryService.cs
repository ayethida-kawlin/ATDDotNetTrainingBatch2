using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ATDDotNetTrainingBatch2.MiniPOS.Database.AppDbContextModels;

namespace ATDDotNetTrainingBatch2.MiniPosConsoleApp
{
    public class SalesSummaryService
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            var saleSummary = db.TblSaleSummaries.ToList();

            foreach (var item in saleSummary)
            {
                Console.WriteLine("InvoiceNo => " + item.InvoiceNo);
                Console.WriteLine("SaleId => " + item.SaleId);
                Console.WriteLine("Date => " + item.Date);
                Console.WriteLine("Total => " + item.Total);
              
            }
        }

        public void Edit()
        {

            Console.Write("Enter Id: ");
            string inputId = Console.ReadLine()!;
            bool isInt = int.TryParse(inputId, out int Id);
            if (!isInt) return;

            AppDbContext db = new AppDbContext();
            var invoiceNo = db.TblSaleSummaries.FirstOrDefault(x => x.InvoiceNo == inputId);
            if (invoiceNo is null)
            {
                return;
            }
            Console.WriteLine("InvoiceNo => " + invoiceNo.InvoiceNo);
            Console.WriteLine("SaleId => " + invoiceNo.SaleId);
            Console.WriteLine("Date => " + invoiceNo.Date);
            Console.WriteLine("Total => " + invoiceNo.Total);
        }

        public void Create()
        {
            Console.Write("Enter Invoice No: ");
            string invoiceNo = Console.ReadLine()!;
            Console.Write("Enter SaleId: ");
            string SaleId = Console.ReadLine()!;
            var salesId = Convert.ToInt32(SaleId);
        DateInput:
            Console.Write("Enter Date: ");
            var date = Console.ReadLine()!;
            bool isDate = DateTime.TryParse(date, out DateTime DateInput);
            if (!isDate)
            {
                goto DateInput;
            }

        PriceTotalInput:
            Console.Write("Enter sale Total: ");
            var total = Console.ReadLine()!;
            bool IsDecimal = decimal.TryParse(total, out decimal PriceInput);
            if (!IsDecimal)
            {
                goto PriceTotalInput;
            }

            var saleSummary = new TblSaleSummary()
            {   
                InvoiceNo= invoiceNo,
                SaleId = salesId,
                Date = DateInput,
                Total= PriceInput

            };

            AppDbContext db = new AppDbContext();
            db.TblSaleSummaries.Add(saleSummary);
            int result = db.SaveChanges();

        }

        public void Execute()
        {
        Result:
            Console.WriteLine("Sale Summary Service Menu");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. Sale Summary Listing ");
            Console.WriteLine("2. Create Sale Summary ");
            Console.WriteLine("3. Exit");
            Console.WriteLine("----------------------------");

            Console.Write("Choose Menu:");
            string result = Console.ReadLine()!;
            bool isInt = int.TryParse(result, out int no);
            if (!isInt)
            {
                goto Result;
            }

            EnumSaleSummaryMenu menu = (EnumSaleSummaryMenu)no;
            switch (menu)
            {
                case EnumSaleSummaryMenu.SaleSummaryListing:
                    Read();
                    Edit();
                    break;
                case EnumSaleSummaryMenu.CreateSaleSummary:
                    Create();
                    break;
                case EnumSaleSummaryMenu.Exit:
                    goto End;
                case EnumSaleSummaryMenu.None:
                default:
                    Console.WriteLine("Invalid Product Menu, Please choose 1 to 3");
                    goto Result;
            }
            Console.WriteLine(" ----------------------");
            goto Result;

        End:
            Console.WriteLine("Sale Summary Exiting.......");

        }

    }

    public enum EnumSaleSummaryMenu
    {
        None,
        SaleSummaryListing,
        CreateSaleSummary,
        Exit
    }
}
