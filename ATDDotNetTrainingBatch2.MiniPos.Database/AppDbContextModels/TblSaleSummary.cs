using System;
using System.Collections.Generic;

namespace ATDDotNetTrainingBatch2.MiniPOS.Database.AppDbContextModels;

public partial class TblSaleSummary
{
    public int Id { get; set; }

    public string InvoiceNo { get; set; } = null!;

    public string SaleId { get; set; } = null!;

    public DateTime Date { get; set; }

    public decimal Total { get; set; }
}
