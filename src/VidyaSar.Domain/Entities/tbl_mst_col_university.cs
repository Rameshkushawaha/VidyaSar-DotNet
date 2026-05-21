using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_mst_col_university
{
    public long university_id { get; set; }

    public string? university_name { get; set; }

    public string? makercode { get; set; }

    public DateTime? updatedatetime { get; set; }

    public bool? bitisactive { get; set; }

    public long? category_id { get; set; }

    public bool? isparent { get; set; }

    public string? university_code { get; set; }
}
