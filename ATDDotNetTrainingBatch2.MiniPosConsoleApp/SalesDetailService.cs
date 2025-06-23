using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ATDDotNetTrainingBatch2.MiniPOS.Database.AppDbContextModels;

namespace ATDDotNetTrainingBatch2.MiniPosConsoleApp
{
    public class SalesDetailService
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            var saleListing = db.TblSaleDetails.ToList();

            foreach (var item in saleListing)
            {
                Console.WriteLine("SaleDetailId => " + item.SaleDetailId);
                Console.WriteLine("ProductCode => " + item.ProductCode);
                Console.WriteLine("ProductName => " + item.ProductName);
                Console.WriteLine("Qty => " + item.Qty);
                Console.WriteLine("Price => " + item.Price);
                Console.WriteLine("Date => " + item.Date);
            }
        }

        public void Edit()
        {
            Console.Write("Enter Sale id: ");
            string input = Console.ReadLine()!;

            bool isInt = int.TryParse(input, out int Id);
            if (!isInt) return;

            AppDbContext db = new AppDbContext();
            var saleIdInput = db.TblSaleDetails.FirstOrDefault(x => x.SaleId == Id);
            if (saleIdInput is null)
            {
                return;
            }
            Console.WriteLine("SaleDetailId => " + saleIdInput.SaleDetailId);
            Console.WriteLine("ProductCode => " + saleIdInput.ProductCode);
            Console.WriteLine("ProductName => " + saleIdInput.ProductName);
            Console.WriteLine("Qty => " + saleIdInput.Qty);
            Console.WriteLine("Price => " + saleIdInput.Price);
            Console.WriteLine("Date => " + saleIdInput.Date);
        }

        public void Create()
        {
            Console.Write("Enter Sale Detail Id: ");
            string saleDetailId= Console.ReadLine()!;
            Console.Write("Enter ProductCode: ");
            string ProductCode = Console.ReadLine()!;
            Console.Write("Enter ProductName: ");
            string ProductName = Console.ReadLine()!;

        QtyInput:
            Console.Write("Enter Product Qty: ");
            var ProductQty = Console.ReadLine()!;
            bool isInt = int.TryParse(ProductQty, out int QtyInput);
            if (!isInt)
            {
                goto QtyInput;
            }
                   
        PriceInput:
            Console.Write("Enter Product Price: ");
            var Productprice = Console.ReadLine()!;
            bool IsDecimal = decimal.TryParse(Productprice, out decimal PriceInput);
            if (!IsDecimal)
            {
                goto PriceInput;
            }

        DateInput:
            Console.Write("Enter Date: ");
            var date = Console.ReadLine()!;
            bool isDate = DateTime.TryParse(date, out DateTime DateInput);
            if (!IsDecimal)
            {
                goto DateInput;
            }

            var saleListing = new TblSaleDetail()
            {
                SaleDetailId = saleDetailId,
                ProductCode= ProductCode,
                ProductName= ProductName,
                Qty = QtyInput,
                Price = PriceInput,
                Date = DateInput,
            };

            AppDbContext db = new AppDbContext();
            db.TblSaleDetails.Add(saleListing);
           int result = db.SaveChanges();


        }
    }
}
