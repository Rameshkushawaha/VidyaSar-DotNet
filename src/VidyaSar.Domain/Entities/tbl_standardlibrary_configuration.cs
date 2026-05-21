using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_standardlibrary_configuration
{
    public long relation_id { get; set; }

    public decimal? library_id { get; set; }

    public long? degree_id { get; set; }

    public decimal? dailyfineamount { get; set; }

    public decimal? maxfinelimit { get; set; }

    public decimal? checkoutduration_staff { get; set; }

    public decimal? checkoutduration_student { get; set; }

    public decimal? renewlimit_staff { get; set; }

    public decimal? renewlimit_student { get; set; }

    public decimal? maxcheckouts_staff { get; set; }

    public decimal? maxcheckouts_student { get; set; }

    public decimal? fineamountafter7days { get; set; }

    public virtual degree_master? degree { get; set; }
}
