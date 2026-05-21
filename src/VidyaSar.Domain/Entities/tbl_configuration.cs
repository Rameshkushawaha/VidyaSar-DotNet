using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_configuration
{
    public long id { get; set; }

    public string? contactperson { get; set; }

    public decimal? collegeid { get; set; }

    public string? tallypath { get; set; }

    public bool? showhrms { get; set; }

    public bool? isplaygroup { get; set; }

    public int? collegtype { get; set; }

    public string? language { get; set; }
}
