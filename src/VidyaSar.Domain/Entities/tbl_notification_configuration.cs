using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_notification_configuration
{
    public long id { get; set; }

    public bool? allowcommentinnewsfeed { get; set; }

    public bool? allowsenddailydairybyparent { get; set; }

    public decimal? textlimitnewsfeed { get; set; }

    public bool? needapprovelofnewsfeedpostedstaff { get; set; }

    public bool? needapprovelforalertssendbystaff { get; set; }

    public decimal? feesduedayforalerts { get; set; }

    public decimal? hidecalenderbeforday { get; set; }

    public bool? sendnotificationtimetablechanges { get; set; }

    public bool? bulkattendanceinmobile { get; set; }

    public bool? sendcopyofalertstoprincipal { get; set; }

    public bool? sendcopyofalertstoclassteacher { get; set; }

    public bool? isstandarddailydairy { get; set; }

    public bool? isstandardalerts { get; set; }

    public decimal? collegeid { get; set; }
}
