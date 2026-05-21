using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_admissionconfiguration
{
    public long relation_id { get; set; }

    public long? collegeid { get; set; }

    public decimal? admissionform { get; set; }

    public virtual tbl_mst_collage? college { get; set; }
}
