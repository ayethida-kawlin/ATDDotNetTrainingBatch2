using System;
using System.Collections.Generic;

namespace ATDDotNetTrainingBatch2.WinFormsApp1.Database.AppDbContextModels;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string ProductCode { get; set; } = null!;

    public string ProductItem { get; set; } = null!;

    public decimal Price { get; set; }

    public bool IsDelete { get; set; }
}
