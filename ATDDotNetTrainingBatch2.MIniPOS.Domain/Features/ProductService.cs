using ATDDotNetTrainingBatch2.MiniPOS.Database.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDDotNetTrainingBatch2.MiniPOS.Domain.Features
{
    public class ProductService
    {
        public List<TblProduct> GetProduct()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.TblProducts
                .Where(x => x.IsDelete == false).ToList();
            return lst;
        }

        public TblProduct? FindProduct(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblProducts
                .Where(x => x.IsDelete == false)
                .FirstOrDefault(x => x.ProductId == id);
            return item;

        }

        public int CreateProduct(string productCode, string productItem, decimal productPrice)
        {
            var product = new TblProduct()
            {
                ProductCode = productCode,
                ProductItem = productItem,
                Price = productPrice,
                IsDelete = false
            };

            AppDbContext db = new AppDbContext();
            db.TblProducts.Add(product);
            var productInput = db.SaveChanges();
            return productInput;
        }

        public int UpdateProduct(int id, string productCode, string productName, decimal productPrice)
        {
            AppDbContext db = new AppDbContext();
            var product = db.TblProducts
                .Where(x => x.IsDelete == false)
                .FirstOrDefault(x => x.ProductId == id);

            if (product is null) return -1;

            product.ProductCode = productCode;
            product.ProductItem = productName;
            product.Price = productPrice;

            var result = db.SaveChanges();
            return result;
        }

        public int DeleteProduct(int id)
        {
            AppDbContext db = new AppDbContext();
            var product = db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            if (product is null) return -1;

            product.IsDelete = true;
            var result = db.SaveChanges();
            return result;
        }
    }
}
