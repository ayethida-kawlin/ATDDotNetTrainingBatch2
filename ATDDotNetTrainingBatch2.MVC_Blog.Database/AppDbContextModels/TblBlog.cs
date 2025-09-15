using System;
using System.Collections.Generic;

namespace ATDDotNetTrainingBatch2.MVC_Blog.Database.AppDbContextModels;

public partial class TblBlog
{
    public string BlogId { get; set; } = null!;

    public string BlogTitle { get; set; } = null!;

    public string BlogAuthor { get; set; } = null!;

    public string BlogContent { get; set; } = null!;

    public DateTime CreatedDateTime { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedDateTime { get; set; }

    public string? ModifiedBy { get; set; }

    public bool DeleteFlag { get; set; }
}
