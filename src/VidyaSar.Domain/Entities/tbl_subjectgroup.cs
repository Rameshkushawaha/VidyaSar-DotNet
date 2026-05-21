using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_subjectgroup
{
    public decimal relationid { get; set; }

    public long? collegeid { get; set; }

    public long? degreeid { get; set; }

    public long? branchid { get; set; }

    public string? tellyboucher { get; set; }

    public string? subjectname { get; set; }

    public virtual tbl_mst_collage? college { get; set; }

    public virtual ICollection<student_detail> student_details { get; set; } = new List<student_detail>();
}
