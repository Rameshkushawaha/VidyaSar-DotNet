namespace VidyaSar.Application.DTOs;

public class AuthRequestDto
{
    public string Userid { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int? Role { get; set; }
    public string? Name { get; set; }
    public string? KnownAs { get; set; }
    public string? Emailid { get; set; }
    public string? Telno { get; set; }
    public string? Title { get; set; }
    public long? Active { get; set; }
    public string? Qualifications { get; set; }
    public string? PermAddress { get; set; }
    public string? CurrentAddress { get; set; }
    public long? PhoneNo { get; set; }
    public DateTime? Dob { get; set; }
    public string? Gender { get; set; }
    public long? MobNo { get; set; }
    public string? ServiceType { get; set; }
    public long? BranchId { get; set; }
    public long? ClColId { get; set; }
    public string? Firstname { get; set; }
    public string? Middlename { get; set; }
    public string? Lastname { get; set; }
    public bool? Ismarried { get; set; }
    public DateTime? Lastlogin { get; set; }
    public string? Imagepath { get; set; }
    public string? Signaturepath { get; set; }
}

public class AuthResponseDto
{
    public string Token { get; set; } = null!;
    public string Userid { get; set; } = null!;
    public string? Name { get; set; }
    public int? Role { get; set; }
    public long? CollegeId { get; set; }
    public long? BranchId { get; set; }
    public long ExpiryTime { get; set; }
}

public class LoggedInUserDto
{
    public string Userid { get; set; } = null!;
    public string? Name { get; set; }
    public int? Role { get; set; }
    public long? CollegeId { get; set; }
    public long? BranchId { get; set; }
}

public class UniversityDto
{
    public long? UniversityId { get; set; }
    public string? UniversityName { get; set; }
    public bool? BitIsActive { get; set; }
    public long? CategoryId { get; set; }
    public bool? IsParent { get; set; }
    public string? UniversityCode { get; set; }
}

public class InstituteDto
{
    public long? ClColId { get; set; }
    public string? ClColName { get; set; }
    public bool? BitIsActive { get; set; }
    public string? Address { get; set; }
    public long City { get; set; }
    public long State { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? EmailId { get; set; }
    public long? InstitutionId { get; set; }
    public long? UniversityId { get; set; }
    public string? Website { get; set; }
    public string? MarksheetAlias { get; set; }
    public string? SchoolCode { get; set; }
    public string? AffiliationNo { get; set; }
}

public class EducationGroupDto
{
    public long? GrId { get; set; }
    public string? GrName { get; set; }
    public string? FacebookUrl { get; set; }
    public string? TwitterUrl { get; set; }
    public string? LinkedinUrl { get; set; }
    public string? PinterestUrl { get; set; }
    public string? GoogleUrl { get; set; }
    public string? LogoWidth { get; set; }
    public string? Url { get; set; }
    public bool? BitIsActive { get; set; }
    public string? GrNo { get; set; }
    public string? GooglePlayStoreUrl { get; set; }
    public string? AppleStoreUrl { get; set; }
}

public class SessionDto
{
    public long? SessionId { get; set; }
    public string? SessionName { get; set; }
    public DateTime? SessionStartDate { get; set; }
    public DateTime? SessionEndDate { get; set; }
    public long? ClColId { get; set; }
    public bool? BitIsActive { get; set; }
    public bool? SessionFees { get; set; }
    public bool? CurrentSession { get; set; }
    public long? AdmissionSession { get; set; }
    public bool? AdmissionBitIsActive { get; set; }
    public string? SessionYear { get; set; }
    public DateTime? AdmissionDate { get; set; }
}
