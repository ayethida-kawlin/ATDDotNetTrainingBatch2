using System;
using System.Collections.Generic;

namespace ATDDotNetTrainingBatch2.WinFormsApp1.Database.AppDbContextModels;

public partial class TblSaleDetail
{
    public int SaleDetailId { get; set; }

    public int SaleId { get; set; }

    public string ProductCode { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public int Qty { get; set; }

    public decimal Price { get; set; }

    public DateTime Date { get; set; }

    public bool IsDelete { get; set; }
}
