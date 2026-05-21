using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_feesconfiguration
{
    public long relationid { get; set; }

    public long collegeid { get; set; }

    public decimal finedays { get; set; }

    public decimal fineamount { get; set; }

    public string? canceladmissionhead { get; set; }

    public bool? tallyintegration { get; set; }

    public decimal? salingfeeshead { get; set; }

    public int? installmenttype { get; set; }

    public decimal? excesshead { get; set; }

    public decimal? reevaluationhead { get; set; }

    public decimal? busfees { get; set; }

    public decimal? etectronicpaymentcharges { get; set; }

    public bool? hidedueamount { get; set; }

    public bool? restrictexcessamount { get; set; }

    public decimal? bouncecharges { get; set; }

    public byte[]? chaqueimage { get; set; }

    public string? finetype { get; set; }

    public int? finecalculationdate { get; set; }

    public virtual tbl_mst_collage college { get; set; } = null!;
}
