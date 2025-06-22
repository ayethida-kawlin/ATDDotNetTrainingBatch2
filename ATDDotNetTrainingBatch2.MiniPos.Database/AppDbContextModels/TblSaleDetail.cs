using System;
using System.Collections.Generic;

namespace ATDDotNetTrainingBatch2POS.Database.AppDbContextModels;

public partial class TblSaleDetail
{
    public string SaleDetailId { get; set; } = null!;

    public string SaleId { get; set; } = null!;

    public string ProductCode { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public int Qty { get; set; }

    public decimal Price { get; set; }
}
