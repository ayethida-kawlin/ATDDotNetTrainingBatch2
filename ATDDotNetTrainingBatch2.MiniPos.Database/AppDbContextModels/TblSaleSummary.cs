using System;
using System.Collections.Generic;

namespace ATDDotNetTrainingBatch2POS.Database.AppDbContextModels;

public partial class TblSaleSummary
{
    public string InvoiceNo { get; set; } = null!;

    public string SaleId { get; set; } = null!;

    public DateTime Date { get; set; }

    public decimal Total { get; set; }
}
