using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_mst_col_group
{
    public long gr_id { get; set; }

    public string? gr_name { get; set; }

    public string? makercode { get; set; }

    public DateTime? updatedatetime { get; set; }

    public bool? bitisactive { get; set; }

    public long? category_id { get; set; }

    public string? facebookurl { get; set; }

    public string? twitterurl { get; set; }

    public string? linkedinurl { get; set; }

    public string? pinteresturl { get; set; }

    public string? googleurl { get; set; }

    public string? grouplogo { get; set; }

    public string? logowidth { get; set; }

    public string? url { get; set; }

    public string? googleplaystoreurl { get; set; }

    public string? applestoreurl { get; set; }

    public long? entityid { get; set; }

    public string? gr_no { get; set; }
}
