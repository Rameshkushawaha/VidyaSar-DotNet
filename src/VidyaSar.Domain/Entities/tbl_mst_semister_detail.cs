using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_mst_semister_detail
{
    public long sm_sem_id { get; set; }

    public string? sm_sem_name { get; set; }

    public long? br_branch_id { get; set; }

    public string? makercode { get; set; }

    public DateTime? updatedatetime { get; set; }

    public string? bitisactive { get; set; }

    public string? bitevenodd { get; set; }

    public string? sm_sem_no { get; set; }

    public long? cl_col_id { get; set; }

    public decimal? years { get; set; }

    public decimal? electivesittingarrangement { get; set; }

    public string? isteacher { get; set; }

    public decimal? parent_semester { get; set; }

    public long? sem_degreeid { get; set; }

    public virtual tbl_mst_col_branch? br_branch { get; set; }

    public virtual UserProfile? isteacherNavigation { get; set; }

    public virtual ICollection<student_detail> student_detailadmittedsems { get; set; } = new List<student_detail>();

    public virtual ICollection<student_detail> student_detailcurrent_semesterNavigations { get; set; } = new List<student_detail>();

    public virtual category_master? yearsNavigation { get; set; }
}
