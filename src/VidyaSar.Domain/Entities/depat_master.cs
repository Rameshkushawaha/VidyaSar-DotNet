using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class depat_master
{
    public long dept_id { get; set; }

    public string? dept_name { get; set; }

    public long? cl_col_id { get; set; }

    public string? bitisactive { get; set; }

    public string? dept_head { get; set; }

    public bool? isteachingdept { get; set; }

    public virtual tbl_mst_collage? cl_col { get; set; }

    public virtual UserProfile? dept_headNavigation { get; set; }

    public virtual ICollection<UserProfile> userprofiles { get; set; } = new List<UserProfile>();
}
