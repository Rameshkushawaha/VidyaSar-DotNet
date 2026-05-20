using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidyaSar.Domain.Entities;

[Table("tbl_academic_configuration",Schema = "public")]
public class AcademicConfiguration
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Column("collegeid")]
    public long? CollegeId { get; set; }

    public long? ShortAttendenceLetterTemplateId { get; set; }
    public long? TimetableMailTemplateId { get; set; }
    public long? TeachingPlanTemplateId { get; set; }
    public long? AttendencesummaryTemplateId { get; set; }
    public int? LeaveAllowedDays { get; set; }
    public bool? AllowCampus { get; set; }
    public bool? RestrictRoomAllocation { get; set; }
    public bool? IsSubjectGroup { get; set; }
    public long? CampusInvitationTemplateId { get; set; }
    public bool? IsRemovePeriodHeader { get; set; }
    public bool? AllowTeacherToAddTeachingPlan { get; set; }
    public bool? AllowTeacherToEditTeachingPlan { get; set; }
    public bool? NeedApprovelforDailyDairyStaff { get; set; }
    public bool? FeedbackByAttendance { get; set; }
    public bool? ShowStudentLeavingOption { get; set; }
    public bool? IsEnggTeachingPlan { get; set; }
    public bool? IsDepartmentWiseLecture { get; set; }
}

[Table("tbl_admission_configuration",Schema = "public")]
public class AdmissionConfiguration
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long? Collegeid { get; set; }
    public long? OfferLetterTemplateId { get; set; }
    public long? AppointmentLetterTemplateId { get; set; }
    public long? ProfileRequestTemplateId { get; set; }
    public long? StudentMessageTemplateId { get; set; }
    public long? EmployeeMessageTemplateId { get; set; }
    public long? PreadmissionTemplateId { get; set; }
    public long? EnquiryTemplateId { get; set; }
    public bool? StudentChangePhoto { get; set; }
    public string? Percentage { get; set; }
    public bool? IsTeacherSpecific { get; set; }
    public int? NameOrdering { get; set; }
    public int? ClassRollnoOrdering { get; set; }
}

[Table("tbl_exam_configuration",Schema = "public")]
public class ExamConfiguration
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long? CollegeId { get; set; }
    public string? MarksheetTopHeader { get; set; }
    public bool? IsShowGradValue { get; set; }
    public string? InwardExtension { get; set; }
    public int? MaxInwardExtension { get; set; }
    public string? OutwardExtension { get; set; }
    public int? MaxOutwardExtension { get; set; }
    public int? Revolution { get; set; }
    public int? ExamLatefineAfterdays { get; set; }
    public int? ExamSuperLatefineAfterdays { get; set; }
    public int? ExamSeatFlag { get; set; }
}

[Table("tbl_fees_configuration",Schema = "public")]
public class FeesConfiguration
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long? CollegeId { get; set; }
    public long? FeesReceiptTemplateId { get; set; }
    public bool? OnlineFeesPayment { get; set; }
    public int? PerformanceReportFormate { get; set; }
    public bool? LateFeesApplicable { get; set; }
    public int? LateFeesAmountPerday { get; set; }
    public string? AdmissionFeeHeadName { get; set; }
    public string? EmailPassword { get; set; }
    public bool? IsRefund { get; set; }
    public bool? IsRefundFeesNotCallculated { get; set; }
    public bool? IsBusFeesNotCallculated { get; set; }
    public int? BounceCharges { get; set; }
    public bool? IsHeadWiseFees { get; set; }
    public string? PaymentGatewayChecksumKey { get; set; }
    public string? PaymentGatewayMerchantIDKey { get; set; }
    public string? PaymentGatewaySecurityID { get; set; }
    public string? PaymentGatewayReturnUrl { get; set; }
    public bool? IsInstallmentPayment { get; set; }
    public bool? IsLateFeesAmountPer { get; set; }
    public int? LateFeesFixAmount { get; set; }
    public bool? IsAutoClearcheckDateApplyBounceCharges { get; set; }
}

[Table("tbl_library_configuration",Schema = "public")]
public class LibraryConfiguration
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public int? ReturnDays { get; set; }
    public int? ReturnEmpDays { get; set; }
    public int? NoBooks { get; set; }
    public int? NoBookEmp { get; set; }
    public int? MaxFine { get; set; }
    public int? LibraryFine { get; set; }
    public int? BookBankLibraryFine { get; set; }
    public long? CollegeId { get; set; }
    public long? BookIssueMailTemplateId { get; set; }
}
