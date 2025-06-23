using System;
using System.Collections.Generic;
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

            Console.Write("Enter Invoice No: ");
            string invoice = Console.ReadLine()!;

            AppDbContext db = new AppDbContext();
            var invoiceNo = db.TblSaleSummaries.FirstOrDefault(x => x.InvoiceNo == invoice);
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
                SaleId = SaleId,
                Date = DateInput,
                Total= PriceInput

            };

            AppDbContext db = new AppDbContext();
            db.TblSaleSummaries.Add(saleSummary);
            int result = db.SaveChanges();

        }

    }
}
