using System;
using System.Collections.Generic;

namespace ATDDotNetTrainingBatch2.WinFormsApp1.Database.AppDbContextModels;

public partial class TblSaleSummary
{
    public int SaleId { get; set; }

    public string InvoiceNo { get; set; } = null!;

    public DateTime Date { get; set; }

    public decimal Total { get; set; }

    public bool IsDelete { get; set; }
}
