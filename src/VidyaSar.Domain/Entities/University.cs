using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidyaSar.Domain.Entities;

[Table("tbl_mst_col_university",Schema = "public")]
public class University
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("university_id")]
    public long UniversityId { get; set; }

    [Column("university_name")]
    public string? UniversityName { get; set; }

    [Column("bitisactive")]
    public bool? BitIsActive { get; set; }

    [Column("updatedatetime")]
    public DateTime? UpdateDateTime { get; set; }

    [Column("category_id")]
    public long? CategoryId { get; set; }

    [Column("makercode")]
    public string? MakerCode { get; set; }

    [Column("isparent")]
    public bool? IsParent { get; set; }

    [Column("university_code")]
    public string? UniversityCode { get; set; }
}
