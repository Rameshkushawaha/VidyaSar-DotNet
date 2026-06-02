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
    public string BitIsActive { get; set; }
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

public class DegreeDto
    {
        public long? Category_Id { get; set; }

        public string Category_Description { get; set; }

        public string Degree_Name { get; set; }

        public bool bitIsActive { get; set; }

        public long CL_Col_Id { get; set; }

        public string Roll_Format { get; set; }

        public string Roll_Code { get; set; }

        public string Col_FullAddress { get; set; }

        public string issueBooklimit { get; set; }

        public decimal? Issue_Day { get; set; }
    }

public class BranchDto
{
    public long? BranchId { get; set; }

    public string BranchName { get; set; }

    public string FullName { get; set; }

    public string BranchNo { get; set; }

    public long CategoryId { get; set; }

    public long CollegeId { get; set; }

    public bool BitIsActive { get; set; }

    public string HODId { get; set; }

    public string DegreeType { get; set; }

    public bool? DayCare { get; set; }

    public int NoOfSem { get; set; }
}

public class BranchResponseDto
{
    public long BranchId { get; set; }

    public string BranchName { get; set; }

    public string FullName { get; set; }

    public string BranchNo { get; set; }

    public long CategoryId { get; set; }

    public long CollegeId { get; set; }

    public string BitIsActive { get; set; }
}

public class PaginationDto
{
    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 10;

    public string? SearchText { get; set; }
}

public class SemesterDto
{
    public long? SemesterId { get; set; }

    public string SemesterName { get; set; }

    public long BranchId { get; set; }

    public string BitIsActive { get; set; }

    public string BitEvenOdd { get; set; }

    public string SemesterNo { get; set; }

    public long CollegeId { get; set; }

    public long Years { get; set; }

    public decimal ElectiveSittingArrangement { get; set; }

    public TimeSpan? FromTime { get; set; }

    public TimeSpan? ToTime { get; set; }

    public decimal? LevertyTime { get; set; }

    public decimal? RatePerMinute { get; set; }

    public string IsTeacher { get; set; }

    public string UniversitySemesterCode { get; set; }

    public long? DegreeId { get; set; }
}

public class SemesterResponseDto
{
    public long SemesterId { get; set; }

    public string SemesterName { get; set; }

    public string SemesterNo { get; set; }

    public string BitEvenOdd { get; set; }

    public long BranchId { get; set; }

    public long CollegeId { get; set; }

    public long Years { get; set; }

    public string BitIsActive { get; set; }
}

public class AdmissionConfigurationDto
{
    public long CollegeId { get; set; }
    public long SessionId { get; set; }
    public string AdmissionStartDate { get; set; }
    public string AdmissionEndDate { get; set; }
    public string ApplicationFee { get; set; }
    public string AdmissionFee { get; set; }
    public string TotalFee { get; set; }
}

public class FeesConfigurationDto
{
    public long CollegeId { get; set; }
    public long SessionId { get; set; }
    public string TuitionFee { get; set; }
    public string ExamFee { get; set; }
    public string LibraryFee { get; set; }
    public string SportsFee { get; set; }
    public string OtherFee { get; set; }
}

public class StudentDto
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }

    public string FatherName { get; set; }

    public string MotherName { get; set; }
    public string MobileNo { get; set; }

    public string EmailId { get; set; }

    public long CollegeId { get; set; }

    public long SessionId { get; set; }

    public long BranchId { get; set; }

    public long SemesterId { get; set; }

    public long DegreeId { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public long Gender { get; set; }
    public long StudentCast { get; set; }
    public long StudentBloodGroup { get; set; }
    public string Address { get; set; }
}