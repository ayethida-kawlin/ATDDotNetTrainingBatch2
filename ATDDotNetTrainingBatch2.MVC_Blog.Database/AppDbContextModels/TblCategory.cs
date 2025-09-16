using System;
using System.Collections.Generic;

namespace ATDDotNetTrainingBatch2.MVC_Blog.Database.AppDbContextModels;

public partial class TblCategory
{
    public string CategoryId { get; set; } = null!;

    public string CategoryCode { get; set; } = null!;

    public string CategoryName { get; set; } = null!;
}
