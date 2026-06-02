using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidyaSar.Domain.Entities;

[Table("userprofile")]
public partial class UserProfile
{
    public string userid { get; set; } = null!;

    public int? role { get; set; }

    public string? name { get; set; }

    public string? known_as { get; set; }

    public string? emailid { get; set; }

    public string? telno { get; set; }

    public string? title { get; set; }

    public string? makercode { get; set; }

    public DateTime? makerdatetime { get; set; }

    public string? password { get; set; }

    public long? active { get; set; }

    public string? qualifications { get; set; }

    public string? perm_address { get; set; }

    public string? current_address { get; set; }

    public long? phone_no { get; set; }

    public DateTime? dob { get; set; }

    public string? gender { get; set; }

    public long? mob_no { get; set; }

    public string? service_type { get; set; }

    public string? flag { get; set; }

    public long? branch_id { get; set; }

    public long? cl_col_id { get; set; }

    public string? class_type { get; set; }

    public string? attendflag { get; set; }

    public string? empatt { get; set; }

    public string? punchid { get; set; }

    public string? fathername { get; set; }

    public string? isfirstlogin { get; set; }

    public long? designation_id { get; set; }

    public string? tokenurl { get; set; }

    public DateTime? tokenexpirydate { get; set; }

    public string? firstname { get; set; }

    public string? middlename { get; set; }

    public string? lastname { get; set; }

    public bool? ismarried { get; set; }

    public string? em_org_code { get; set; }

    public DateTime? lastlogin { get; set; }

    public int? failedlogincount { get; set; }

    public string? encryptedpassword { get; set; }

    public string? oldpassword { get; set; }

    public DateTime? lastchangepassworddate { get; set; }

    public string? imagepath { get; set; }

    public string? signaturepath { get; set; }

    public virtual depat_master? branch { get; set; }

    public virtual tbl_mst_collage? cl_col { get; set; }

    public virtual ICollection<depat_master> depat_masters { get; set; } = new List<depat_master>();

    public virtual tbl_designation_master? designation { get; set; }

    public virtual col_rolemaster? roleNavigation { get; set; }

    public virtual ICollection<tbl_mst_col_branch> tbl_mst_col_branches { get; set; } = new List<tbl_mst_col_branch>();

    public virtual ICollection<tbl_mst_semister_detail> tbl_mst_semister_details { get; set; } = new List<tbl_mst_semister_detail>();

}
