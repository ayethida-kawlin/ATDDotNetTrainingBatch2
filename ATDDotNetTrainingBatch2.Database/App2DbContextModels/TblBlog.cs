﻿using System;
using System.Collections.Generic;

namespace ATDDotNetTrainingBatch2.Database.App2DbContextModels;

public partial class TblBlog
{
    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;

    public string BlogAuthor { get; set; } = null!;

    public string BlogContent { get; set; } = null!;

    public bool IsDelete { get; set; }
}
