using ATDDotNetTrainingBatch2.DI_Database.AppDbContextModels;

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
            return _db.TblProducts
                .Skip((pageNo - 1)* pageSize)
                .Take(pageSize)
                .ToList();
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
