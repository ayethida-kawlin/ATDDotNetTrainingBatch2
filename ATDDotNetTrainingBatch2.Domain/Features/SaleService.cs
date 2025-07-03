using ATDDotNetTrainingBatch2.MiniPOS.Database.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDDotNetTrainingBatch2.MiniPOS.Domain.Features
{
    public class SaleService
    {
        public TblProduct FindProduct(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            return item;
        }

        public int Sale(List<TblSaleDetail> products)
        {
            AppDbContext db = new AppDbContext();
            //List<TblSaleDetail> products = new List<TblSaleDetail>();

            #region Generate Sale Summary and create Sale
            TblSaleSummary saleSummary = new TblSaleSummary()
            {
                Total = products.Sum(x => (x.Price * x.Qty)),
                IsDelete = false,
                Date = DateTime.Now,
                InvoiceNo = Guid.NewGuid().ToString()

            };

            db.TblSaleSummaries.Add(saleSummary);
            db.SaveChanges();
            

            #endregion

            #region Modify Sale Detail and Create Sale Detail

            foreach (var product in products)
            {
                product.SaleId = saleSummary.SaleId;
            }
            db.TblSaleDetails.AddRange(products);
           var result = db.SaveChanges();
            return result;

            #endregion


        }

        public List<TblSaleDetail> SaleDetailListing()
        {
            AppDbContext db = new AppDbContext();
            var saleDetailListing = db.TblSaleDetails.ToList();
            return saleDetailListing;

        }

        public List<TblSaleSummary> SaleSummaryListing()
        {
            AppDbContext db = new AppDbContext();
            var saleSummaryListing = db.TblSaleSummaries.ToList();
            return saleSummaryListing;
        }
    }
}
