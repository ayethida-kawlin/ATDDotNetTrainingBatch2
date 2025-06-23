using System;
using System.Collections.Generic;

namespace ATDDotNetTrainingBatch2.MiniPOS.Database.AppDbContextModels;

public partial class TblSaleDetail
{
    public int SaleId { get; set; }

    public string SaleDetailId { get; set; } = null!;

    public string ProductCode { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public int Qty { get; set; }

    public decimal Price { get; set; }

    public DateTime Date { get; set; }
}
