using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_exam_configuration
{
    public long id { get; set; }

    public string? marksheettophader { get; set; }

    public bool? isshowgradvalue { get; set; }

    public string? inwardextension { get; set; }

    public decimal? maxinwardextension { get; set; }

    public string? outwardextension { get; set; }

    public decimal? maxoutwardextension { get; set; }

    public int? revolution { get; set; }

    public decimal? collegeid { get; set; }

    public decimal? examlatefineafterdays { get; set; }

    public decimal? examsuperlatefineafterdays { get; set; }

    public int? examseatflag { get; set; }

    public int? examtype { get; set; }

    public int? allowteachertoentermarks { get; set; }

    public bool? istimetablewise { get; set; }

    public decimal? allowedsubjects { get; set; }

    public short? isallowedsubject { get; set; }

    public bool? iscollectexamfee { get; set; }

    public long? college_id { get; set; }

    public int? exam_latefine_afterdays { get; set; }

    public int? exam_seat_flag { get; set; }

    public int? exam_super_latefine_afterdays { get; set; }

    public string? inward_extension { get; set; }

    public bool? is_show_grad_value { get; set; }

    public string? marksheet_top_header { get; set; }

    public int? max_inward_extension { get; set; }

    public int? max_outward_extension { get; set; }

    public string? outward_extension { get; set; }
}
