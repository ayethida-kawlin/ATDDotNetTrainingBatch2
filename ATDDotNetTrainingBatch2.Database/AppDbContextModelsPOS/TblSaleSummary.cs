using System;
using System.Collections.Generic;

namespace ATDDotNetTrainingBatch2.Database.AppDbContextModelsPOS;

public partial class TblSaleSummary
{
    public string InvoiceNo { get; set; } = null!;

    public string SaleId { get; set; } = null!;

    public DateTime Date { get; set; }

    public decimal Total { get; set; }
}
