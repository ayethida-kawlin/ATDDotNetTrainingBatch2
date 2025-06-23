using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ATDDotNetTrainingBatch2.MiniPOS.Database.AppDbContextModels;

namespace ATDDotNetTrainingBatch2.MiniPosConsoleApp
{
    public class ProductService
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<TblProduct> lst =  db.TblProducts.Where(x => x.IsDelete == false).ToList();
            foreach (var item in lst)
            {
                Console.WriteLine("ProductCode => " + item.ProductCode);
                Console.WriteLine("ProductItem => " + item.ProductItem);
                Console.WriteLine("Price => " + item.Price);
                Console.WriteLine("IsDelete => " + item.IsDelete);
            }
        }   

        public void Edit()
        {
            Console.Write("Enter Product id: ");
            string input= Console.ReadLine()!;

            bool isInt=int.TryParse(input, out int Id);
            if (!isInt) return;

            AppDbContext db = new AppDbContext();
            var item = db.TblProducts
                .Where(x => x.IsDelete == false)
                .FirstOrDefault(x => x.ProductId == Id);
            if(item is null)
            {
                return;
            }
            Console.WriteLine("ProductId => " + item.ProductId);
            Console.WriteLine("ProductCode => " + item.ProductCode);
            Console.WriteLine("ProductItem => " + item.ProductItem);
            Console.WriteLine("Price => " + item.Price);
            Console.WriteLine("IsDelete => " + item.IsDelete);

        }

        public void Create()
        {
            Console.Write("Enter Product code: ");
            string productCode= Console.ReadLine()!;
            Console.Write("Enter Product Item: ");
            string productItem = Console.ReadLine()!;
        PriceInput:
            Console.Write("Enter Product Price: ");
            var Productprice = Console.ReadLine()!;
            bool IsDecimal =decimal.TryParse(Productprice, out decimal PriceInput);
            if (!IsDecimal)
            {
                goto PriceInput;
            }

            var product = new TblProduct()
            { 
                ProductCode = productCode,
                ProductItem = productItem,
                Price = PriceInput,
                IsDelete=false
            };

            AppDbContext db = new AppDbContext();
            db.TblProducts.Add(product);
            int productInput = db.SaveChanges();

        }

        public void Update()
        {
            Console.Write("Enter Product id: ");
            string input = Console.ReadLine()!;

            bool isInt = int.TryParse(input, out int Id);
            if (!isInt) return;

            Console.Write("Modify Product code: ");
            string modifyProductCode = Console.ReadLine()!;
            Console.Write("Modify Product Item: ");
            string modifyProductItem = Console.ReadLine()!;

        modifyPriceInput:
            Console.Write("Modify Product Price: ");
            var modifyProductprice = Console.ReadLine()!;
            bool IsDecimal = decimal.TryParse(modifyProductprice, out decimal PriceInput);
            if (!IsDecimal)
            {
                goto modifyPriceInput;
            }
                        
            AppDbContext db = new AppDbContext();
            var product = db.TblProducts
                .Where(x => x.IsDelete == false)
                .FirstOrDefault(x => x.ProductId == Id);
            if( product is null)
            {
                return;
            }
            product.ProductCode= modifyProductCode;
            product.ProductItem= modifyProductItem;
            product.Price = Convert.ToDecimal(modifyProductprice);
                        
            db.SaveChanges();

        }

        public void Delete()
        {
            Console.Write("Enter Product id: ");
            string input = Console.ReadLine()!;

            bool isInt = int.TryParse(input, out int Id);
            if (!isInt) return;

            AppDbContext db = new AppDbContext();
            var product = db.TblProducts.FirstOrDefault(x => x.ProductId == Id);
            if (product is null)
            {
                return;
            }
            product.IsDelete = true;
            db.SaveChanges();
        }
    }
}
