using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_leave_configuration
{
    public long id { get; set; }

    public int? attendancelimit { get; set; }

    public decimal? leaveapprovelautoforwarding { get; set; }

    public decimal? collegeid { get; set; }

    public bool? isdirectapproval { get; set; }
}
