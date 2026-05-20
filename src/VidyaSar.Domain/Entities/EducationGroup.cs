using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidyaSar.Domain.Entities;

[Table("tbl_mst_col_group",Schema = "public")]
public class EducationGroup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("gr_id")]
    public long GrId { get; set; }

    [Column("gr_name")]
    public string? GrName { get; set; }

    [Column("makercode")]
    public string? MakerCode { get; set; }

    [Column("updatedatetime")]
    public DateTime? UpdateDateTime { get; set; }

    [Column("category_id")]
    public long? CategoryId { get; set; }

    [Column("facebookurl")]
    public string? FacebookUrl { get; set; }

    [Column("twitterurl")]
    public string? TwitterUrl { get; set; }

    [Column("linkedinurl")]
    public string? LinkedinUrl { get; set; }

    [Column("pinteresturl")]
    public string? PinterestUrl { get; set; }

    [Column("googleurl")]
    public string? GoogleUrl { get; set; }

    [Column("logowidth")]
    public string? LogoWidth { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("bitisactive")]
    public bool? BitIsActive { get; set; }

    [Column("gr_no")]
    public string? GrNo { get; set; }

    [Column("googleplaystoreurl")]
    public string? GooglePlayStoreUrl { get; set; }

    [Column("applestoreurl")]
    public string? AppleStoreUrl { get; set; }

    [Column("entityid")]
    public long? EntityId { get; set; }
}
