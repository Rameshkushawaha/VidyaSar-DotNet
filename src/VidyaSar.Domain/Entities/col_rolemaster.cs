using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class col_rolemaster
{
    public int role { get; set; }

    public string? role_name { get; set; }

    public decimal? cl_col_id { get; set; }

    public virtual ICollection<UserProfile> userprofiles { get; set; } = new List<UserProfile>();
}
