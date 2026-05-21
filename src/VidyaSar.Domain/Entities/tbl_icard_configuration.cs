using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_icard_configuration
{
    public long id { get; set; }

    public decimal? stuicardformat { get; set; }

    public decimal? employeeicardformat { get; set; }

    public string? stuicardbackground { get; set; }

    public string? stuicardsign { get; set; }

    public string? empicardbackground { get; set; }

    public string? empicardsign { get; set; }

    public decimal? collegeid { get; set; }
}
