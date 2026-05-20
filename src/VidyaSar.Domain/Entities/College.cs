using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidyaSar.Domain.Entities;

[Table("tbl_mst_collage",Schema = "public")]
public class College
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("cl_col_id")]
    public long ClColId { get; set; }

    [Column("cl_col_name")]
    public string? ClColName { get; set; }

    [Column("bitisactive")]
    public bool? BitIsActive { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("city")]
    public long City { get; set; }

    [Column("state")]
    public long State { get; set; }

    [Column("country")]
    public string? Country { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("emailid")]
    public string? EmailId { get; set; }

    [Column("institution_id")]
    public long? InstitutionId { get; set; }

    [Column("university_id")]
    public long? UniversityId { get; set; }

    [Column("website")]
    public string? Website { get; set; }

    [Column("marksheetalias")]
    public string? MarksheetAlias { get; set; }

    [Column("schoolcode")]
    public string? SchoolCode { get; set; }

    [Column("affiliationno")]
    public string? AffiliationNo { get; set; }

    [Column("makercode")]
    public string? MakerCode { get; set; }

    [Column("updatedatetime")]
    public DateTime? UpdateDateTime { get; set; }
}
