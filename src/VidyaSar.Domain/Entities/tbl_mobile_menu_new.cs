using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_mobile_menu_new
{
    public long relation_id { get; set; }

    public decimal? college_id { get; set; }

    public string? name { get; set; }

    public string? link { get; set; }

    public string? icon { get; set; }

    public string? role_id { get; set; }

    public decimal? orderno { get; set; }

    public decimal? institutetype { get; set; }

    public int? featureid { get; set; }

    public string? featurename { get; set; }

    public string? linkdescription { get; set; }

    public string? featurenameicon { get; set; }

    public string? isdefault { get; set; }
}
