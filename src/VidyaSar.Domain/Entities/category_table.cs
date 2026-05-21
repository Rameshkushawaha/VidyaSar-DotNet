using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class category_table
{
    public decimal categoryid { get; set; }

    public string? category_name { get; set; }

    public DateTime? updatedatetime { get; set; }

    public string? makercode { get; set; }

    public decimal? cl_col_id { get; set; }

    public bool? is_collegewise { get; set; }

    public virtual ICollection<category_master> category_masters { get; set; } = new List<category_master>();
}
