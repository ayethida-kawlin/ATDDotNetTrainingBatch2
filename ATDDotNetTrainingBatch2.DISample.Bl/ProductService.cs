using ATDDotNetTrainingBatch2.DI_Database.AppDbContextModels;
using ATDDotNetTrainingBatch2.DISample.DA;

namespace ATDDotNetTrainingBatch2.DISample.Bl
{
    public class ProductService
    {
        private readonly ProductDataAccess _productDataAccess;
        public ProductService(ProductDataAccess productDataAccess)
        {
            _productDataAccess = productDataAccess;
        }

        public List<TblProduct> GetProducts(int pageNo, int pageSize)
        {
            if (pageSize == 0) 
            {
                throw new Exception("Page Number cannot be zero.");
            }
            if(pageSize == 0)
            {
                throw new Exception("Page Number cannot be zero.");
            }

            return _productDataAccess.GetProducts(pageNo, pageSize);
        }

        public async Task<List<TblProduct>> GetProductsAsync(int pageNo, int pageSize)
        {
            if (pageSize == 0)
            {
                throw new Exception("Page Number cannot be zero.");
            }
            if (pageSize == 0)
            {
                throw new Exception("Page Number cannot be zero.");
            }

            return await _productDataAccess.GetProductsAsync(pageNo, pageSize);
        }

        public async Task<int> AddProductAsync(TblProduct product)
        {
            if (product is null)
            {
                //throw new ArgumentNullException(nameof(product),"Product cannot be null");
                throw new Exception("Product cannot be null");
            }
            var result = await _productDataAccess.AddProductAsync(product);
            return result;
        }
        public async Task<int> UpdateProductAsync(TblProduct product) 
        { 
            if(product.ProductId == 0)
            {
                throw new Exception("Invalid product id.");
            }
            var result = await _productDataAccess.UpdateProductAsync(product);
            return result;

        }

        public async Task<int> DeleteProductAsync(int productId)
        {
            if (productId == 0)
            {
                throw new Exception("Invalid product id.");
            }
            var result = await _productDataAccess.DeleteProductAsync(productId);
            return result;

        }
    }
}
