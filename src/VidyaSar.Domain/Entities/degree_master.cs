using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class degree_master
{
    public long category_id { get; set; }

    public string? category_description { get; set; }

    public string? makercode { get; set; }

    public DateTime? updatedatetime { get; set; }

    public bool? bitisactive { get; set; }

    public long? cl_col_id { get; set; }

    public string? issuebooklimit { get; set; }

    public string? col_fulladdress { get; set; }

    public string? degree_name { get; set; }

    public long? parent_degree { get; set; }

    public virtual ICollection<degree_master> Inverseparent_degreeNavigation { get; set; } = new List<degree_master>();

    public virtual tbl_mst_collage? cl_col { get; set; }

    public virtual degree_master? parent_degreeNavigation { get; set; }

    public virtual ICollection<student_detail> student_details { get; set; } = new List<student_detail>();

    public virtual ICollection<tbl_standardlibrary_configuration> tbl_standardlibrary_configurations { get; set; } = new List<tbl_standardlibrary_configuration>();
}
