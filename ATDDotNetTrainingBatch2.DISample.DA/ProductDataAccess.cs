using ATDDotNetTrainingBatch2.DI_Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ATDDotNetTrainingBatch2.DISample.DA
{
    public class ProductDataAccess
    {
        private readonly AppDbContext _db;
        public ProductDataAccess(AppDbContext db)
        {
            _db = db;
        }

        // 1,1 to 10
        // 2, 11 to 20
        // 3, 21 to 30
        public List<TblProduct> GetProducts(int pageNo, int pageSize)
        {
            var lst =  _db.TblProducts
                .Skip((pageNo - 1)* pageSize)
                .Take(pageSize)
                .ToList();
            
            return lst;
        }
       
        public async Task<int> AddProductAsync(TblProduct product)
        {
            await _db.TblProducts.AddAsync(product);
            var result = await _db.SaveChangesAsync();
            return result;
        }
        public async Task<int> UpdateProductAsync(TblProduct product)
        {
            var item = await _db.TblProducts.FirstOrDefaultAsync(x => x.ProductId == product.ProductId);
            if (item is null)
                throw new Exception("Product not found.");
            //return 0;

            item.ProductItem = product.ProductItem;
            item.Price = product.Price;
            item.ProductCode = product.ProductCode;


            var result = await _db.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteProductAsync(int productId)
        {
            var item = await _db.TblProducts.FirstOrDefaultAsync(x => x.ProductId == productId);
            if (item is null)
                throw new Exception("Product not found.");

            item.IsDelete = true; // softdelete
            //_db.Remove(item);
            var result = await _db.SaveChangesAsync();
            return result;
        }

        public  async Task<List<TblProduct>> GetProductsAsync(int pageNo, int pageSize)
        {
            var lst = await _db.TblProducts
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return lst;

            //var task1 = _db.TblProducts
            //    .Skip((pageNo - 1) * pageSize)
            //    .Take(pageSize)
            //    .ToListAsync();
            //var task2 = _db.TblProducts
            //    .Skip((pageNo - 1) * pageSize)
            //    .Take(pageSize)
            //    .ToListAsync();
            //var task3 = _db.TblProducts
            //    .Skip((pageNo - 1) * pageSize)
            //    .Take(pageSize)
            //    .ToListAsync();

            //await Task.WhenAll(task1, task2, task3);    


        }

        // start no / end no (1 to 10)
        // 11 to 20
        // 21 to 30
        // page No = 1
        // end no => page No * page size 
        // 1 * 10= 10
        // 2 * 10= 20
        // 3 * 10= 30
        // start no => end row no - page size 
        // 30 - 10 = 20 + 1 => 21 to 30

        // page 101? start no + 1 =1001 to 1010
        // end no => 101 * 10 = 1010 
        // start no => 1010 -  10 = 1000


    }
}
