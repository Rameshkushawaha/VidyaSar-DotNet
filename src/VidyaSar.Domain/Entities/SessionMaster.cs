using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidyaSar.Domain.Entities;

[Table("session_master",Schema = "public")]
public class SessionMaster
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("session_id")]
    public long SessionId { get; set; }

    [Column("session_name")]
    public string? SessionName { get; set; }

    [Column("session_start_date")]
    public DateTime? SessionStartDate { get; set; }

    [Column("session_end_date")]
    public DateTime? SessionEndDate { get; set; }

    [Column("cl_col_id")]
    public long? ClColId { get; set; }

    [Column("bitisactive")]
    public bool? BitIsActive { get; set; }

    [Column("session_fees")]
    public bool? SessionFees { get; set; }

    [Column("current_session")]
    public bool? CurrentSession { get; set; }

    [Column("admission_session")]
    public long? AdmissionSession { get; set; }

    [Column("admission_bitisactive")]
    public bool? AdmissionBitIsActive { get; set; }

    [Column("sessionyear")]
    public string? SessionYear { get; set; }

    [Column("admissiondate")]
    public DateTime? AdmissionDate { get; set; }
}
