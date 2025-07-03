using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ATDDotNetTrainingBatch2.MiniPOS.Database.AppDbContextModels;
using ATDDotNetTrainingBatch2.MiniPOS.Domain.Features;

namespace ATDDotNetTrainingBatch2.MiniPosConsoleApp
{
    public class ProductUI
    {
        public void Read()
        {
            //AppDbContext db = new AppDbContext();
            //List<TblProduct> lst =  db.TblProducts
            //    .Where(x => x.IsDelete == false).ToList();
            ProductService productService = new ProductService();
            var lst = productService.GetProduct();

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
            string input = Console.ReadLine()!;

            bool isInt = int.TryParse(input, out int Id);
            if (!isInt) return;
            #region Command before split UI and service code
            //AppDbContext db = new AppDbContext();
            //var item = db.TblProducts
            //    .Where(x => x.IsDelete == false)
            //    .FirstOrDefault(x => x.ProductId == Id);
            #endregion

            #region after split UI and service
            ProductService productService = new ProductService();
            var item = productService.FindProduct(Id);
            #endregion

            if (item is null)
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
            string productCode = Console.ReadLine()!;
            Console.Write("Enter Product Item: ");
            string productItem = Console.ReadLine()!;

            Console.Write("Enter Product Price: ");
            var productprice = Convert.ToDecimal(Console.ReadLine())!;

            #region Command before split with UI and service code
            //var product = new TblProduct()
            //{ 
            //    ProductCode = productCode,
            //    ProductItem = productItem,
            //    Price = productprice,
            //    IsDelete=false
            //};

            //AppDbContext db = new AppDbContext();
            //db.TblProducts.Add(product);
            //var productInput = db.SaveChanges();
            #endregion

            #region After split with UI and service

            ProductService productService = new ProductService();
            int result = productService.CreateProduct(productCode, productItem, productprice);

            #endregion
        }

        public void Update()
        {
        ProductIdInput:
            Console.Write("Enter Product id: ");
            string id = Console.ReadLine()!;

            bool isInt = int.TryParse(id, out int Id);
            if (!isInt) return;

            ProductService productService = new ProductService();
            var item = productService.FindProduct(Id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                goto ProductIdInput;
            }
            Console.WriteLine($"Old Product code: {item.ProductCode} ");
            Console.WriteLine($"Old Product Name: {item.ProductItem}");
            Console.WriteLine($"Old Product price: {item.Price}");
            Console.WriteLine("------------------------------------------");

            Console.Write("Enter modify Product Code: ");
            string code = Console.ReadLine()!;
            Console.Write("Enter modify Product Name: ");
            string name = Console.ReadLine()!;
            Console.Write("Enter modify Product Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine())!;

            #region Command before split UI and service
            //AppDbContext db = new AppDbContext();
            //var product = db.TblProducts
            //    .Where(x => x.IsDelete == false)
            //    .FirstOrDefault(x => x.ProductId == Id);

            //if (product is null)
            //{
            //    return;
            //}

            //product.ProductCode = item.ProductCode;
            //product.ProductItem = item.ProductItem;
            //product.Price = item.Price;

            //var result = db.SaveChanges();
            #endregion

            int result = productService.UpdateProduct(Id, code, name, price);
            if(result == -1)
            {
                Console.WriteLine("No data found.");
                goto ProductIdInput;
            }

        }

        public void Delete()
        {
        FirstPage:
            Console.Write("Enter Product id: ");
            string input = Console.ReadLine()!;

            bool isInt = int.TryParse(input, out int Id);
            if (!isInt)
            {
                goto FirstPage;
            };

            ProductService productService = new ProductService();
            var item = productService.FindProduct(Id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                goto FirstPage;
            }

            //AppDbContext db = new AppDbContext();
            //var product = db.TblProducts.FirstOrDefault(x => x.ProductId == Id);
            //if (product is null)
            //{
            //    return;
            //}
            //product.IsDelete = true;
            //db.SaveChanges();
        }

        public void Execute()
        {
        Result:
            Console.WriteLine("Product Menu");
            Console.WriteLine("----------------------");
            Console.WriteLine("1. New Product");
            Console.WriteLine("2. Product List");
            Console.WriteLine("3. Edit Product");
            Console.WriteLine("4. Delete Product");
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

            Console.WriteLine("----------------------");
            EnumProductMenu menu = (EnumProductMenu)no;
            switch (menu)
            {

                case EnumProductMenu.NewProduct:
                    Console.WriteLine("This menu is new Product");
                    Console.WriteLine("----------------------");
                    Create();
                    break;
                case EnumProductMenu.ProductList:
                    Console.WriteLine("This menu is Product List");
                    Read();
                    Console.WriteLine("----------------------");
                    break;
                case EnumProductMenu.EditProduct:
                    Console.WriteLine("This menu is Edit Product");
                    Update();
                    break;
                case EnumProductMenu.DeleteProduct:
                    Console.WriteLine("This menu is Delete Product");
                    Delete();
                    break;
                case EnumProductMenu.Exit:
                    goto End;
                case EnumProductMenu.None:
                default:
                    Console.WriteLine("Invalid Product Menu, Please choose 1 to 5");
                    goto Result;
            }
            Console.WriteLine("----------------------");
            goto Result;

        End:
            Console.WriteLine("Exiting Product Menu....");
        }
    }

    public enum EnumProductMenu
    {
        None,
        NewProduct,
        ProductList,
        EditProduct,
        DeleteProduct,
        Exit

    }


}