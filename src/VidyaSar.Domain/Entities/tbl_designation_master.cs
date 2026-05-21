using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_designation_master
{
    public long relation_id { get; set; }

    public string? designation { get; set; }

    public virtual ICollection<UserProfile> userprofiles { get; set; } = new List<UserProfile>();
}
