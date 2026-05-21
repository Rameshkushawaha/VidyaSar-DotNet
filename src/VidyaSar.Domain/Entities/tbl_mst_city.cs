using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_mst_city
{
    public long relation_id { get; set; }

    public long state_id { get; set; }

    public string? city_title { get; set; }

    public string? city_zipcode { get; set; }

    public string? city_description { get; set; }

    public decimal? created_by { get; set; }

    public string? created_on { get; set; }

    public bool? status { get; set; }

    public virtual tbl_mst_state state { get; set; } = null!;

    public virtual ICollection<tbl_mst_collage> tbl_mst_collages { get; set; } = new List<tbl_mst_collage>();
}
