using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class category_master
{
    public decimal category_id { get; set; }

    public string? category_description { get; set; }

    public string? makercode { get; set; }

    public DateTime? updatedatetime { get; set; }

    public bool? bitisactive { get; set; }

    public decimal? categoryid { get; set; }

    public string? category_name { get; set; }

    public decimal? cl_col_id { get; set; }

    public bool? is_collegewise { get; set; }

    public string? abbr { get; set; }

    public virtual category_table? category { get; set; }

    public virtual ICollection<student_detail> student_detailblood_groupsNavigations { get; set; } = new List<student_detail>();

    public virtual ICollection<student_detail> student_detailstudent_castNavigations { get; set; } = new List<student_detail>();

    public virtual ICollection<student_detail> student_detailstudentgenderNavigations { get; set; } = new List<student_detail>();

    public virtual ICollection<tbl_mst_semister_detail> tbl_mst_semister_details { get; set; } = new List<tbl_mst_semister_detail>();

    public virtual ICollection<tbl_standardlibrary_bookbank_configuration> tbl_standardlibrary_bookbank_configurations { get; set; } = new List<tbl_standardlibrary_bookbank_configuration>();
}
