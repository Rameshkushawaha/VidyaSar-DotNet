using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidyaSar.Domain.Entities;

[Table("userprofile", Schema = "public")]
public class UserProfile
{
    [Key]
    [Column("userid")]
    public string Userid { get; set; } = null!;

    [Column("role")]
    public int? Role { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("known_as")]
    public string? KnownAs { get; set; }

    [Column("emailid")]
    public string? Emailid { get; set; }

    [Column("telno")]
    public string? Telno { get; set; }

    [Column("title")]
    public string? Title { get; set; }

    [Column("makercode")]
    public string? Makercode { get; set; }

    [Column("makerdatetime")]
    public DateTime? Makerdatetime { get; set; }

    [Column("password")]
    public string? Password { get; set; }

    [Column("active")]
    public long? Active { get; set; }

    [Column("qualifications")]
    public string? Qualifications { get; set; }

    [Column("perm_address")]
    public string? PermAddress { get; set; }

    [Column("current_address")]
    public string? CurrentAddress { get; set; }

    [Column("phone_no")]
    public long? PhoneNo { get; set; }

    [Column("dob")]
    public DateTime? Dob { get; set; }

    [Column("gender")]
    public string? Gender { get; set; }

    [Column("mob_no")]
    public long? MobNo { get; set; }

    [Column("service_type")]
    public string? ServiceType { get; set; }

    [Column("flag")]
    public string? Flag { get; set; }

    [Column("branch_id")]
    public long? BranchId { get; set; }

    [Column("cl_col_id")]
    public long? ClColId { get; set; }

    [Column("class_type")]
    public string? ClassType { get; set; }

    [Column("attendflag")]
    public string? Attendflag { get; set; }

    [Column("empatt")]
    public string? Empatt { get; set; }

    [Column("punchid")]
    public string? Punchid { get; set; }

    [Column("fathername")]
    public string? Fathername { get; set; }

    [Column("isfirstlogin")]
    public string? Isfirstlogin { get; set; }

    [Column("designation_id")]
    public long? DesignationId { get; set; }

    [Column("tokenurl")]
    public string? Tokenurl { get; set; }

    [Column("tokenexpirydate")]
    public DateTime? Tokenexpirydate { get; set; }

    [Column("firstname")]
    public string? Firstname { get; set; }

    [Column("middlename")]
    public string? Middlename { get; set; }

    [Column("lastname")]
    public string? Lastname { get; set; }

    [Column("ismarried")]
    public bool? Ismarried { get; set; }

    [Column("em_org_code")]
    public string? EmOrgCode { get; set; }

    [Column("lastlogin")]
    public DateTime? Lastlogin { get; set; }

    [Column("failedlogincount")]
    public int? Failedlogincount { get; set; }

    [Column("encryptedpassword")]
    public string? Encryptedpassword { get; set; }

    [Column("oldpassword")]
    public string? Oldpassword { get; set; }

    [Column("lastchangepassworddate")]
    public DateTime? Lastchangepassworddate { get; set; }

    [Column("imagepath")]
    public string? Imagepath { get; set; }

    [Column("signaturepath")]
    public string? Signaturepath { get; set; }
}
