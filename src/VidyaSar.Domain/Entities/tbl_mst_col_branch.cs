using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_mst_col_branch
{
    public long br_branch_id { get; set; }

    public string? br_branch_name { get; set; }

    public long? cl_col_id { get; set; }

    public string? makercode { get; set; }

    public DateTime? updatedatetime { get; set; }

    public bool? bitisactive { get; set; }

    public string? br_branch_no { get; set; }

    public string? course_type { get; set; }

    public string? remaining_seats { get; set; }

    public string? degree_type { get; set; }

    public decimal? category_id { get; set; }

    public string? br_full_name { get; set; }

    public string? hodid { get; set; }

    public string? tallyparentname { get; set; }

    public bool? daycare { get; set; }

    public decimal? admissionformfee { get; set; }

    public long? parent_branch { get; set; }

    public virtual ICollection<tbl_mst_col_branch> Inverseparent_branchNavigation { get; set; } = new List<tbl_mst_col_branch>();

    public virtual tbl_mst_collage? cl_col { get; set; }

    public virtual UserProfile? makercodeNavigation { get; set; }

    public virtual tbl_mst_col_branch? parent_branchNavigation { get; set; }

    public virtual ICollection<student_detail> student_detailadmittedinbranchNavigations { get; set; } = new List<student_detail>();

    public virtual ICollection<student_detail> student_detailbr_branches { get; set; } = new List<student_detail>();

    public virtual ICollection<tbl_mst_semister_detail> tbl_mst_semister_details { get; set; } = new List<tbl_mst_semister_detail>();
}
