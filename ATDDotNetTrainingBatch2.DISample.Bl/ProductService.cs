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

    }
}
