using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class session_master
{
    public string? session_name { get; set; }

    public long session_id { get; set; }

    public DateTime? session_start_date { get; set; }

    public DateTime? session_end_date { get; set; }

    public long? cl_col_id { get; set; }

    public bool? bitisactive { get; set; }

    public bool? current_session { get; set; }

    public long? admission_session { get; set; }

    public bool? admission_bitisactive { get; set; }

    public string? sessionyear { get; set; }

    public DateTime? admissiondate { get; set; }

    public bool? session_fees { get; set; }

    public virtual tbl_mst_collage? cl_col { get; set; }

    public virtual ICollection<student_detail> student_detailadmissionyearNavigations { get; set; } = new List<student_detail>();

    public virtual ICollection<student_detail> student_detailleavingyearNavigations { get; set; } = new List<student_detail>();

    public virtual ICollection<student_detail> student_detailsessions { get; set; } = new List<student_detail>();
}
