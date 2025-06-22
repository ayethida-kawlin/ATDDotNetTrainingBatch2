using System;
using System.Collections.Generic;

namespace ATDDotNetTrainingBatch2POS.Database.AppDbContextModels;

public partial class TblProduct
{
    public string ProductCode { get; set; } = null!;

    public string ProductItem { get; set; } = null!;

    public decimal Price { get; set; }

    public bool IsDelete { get; set; }
}
