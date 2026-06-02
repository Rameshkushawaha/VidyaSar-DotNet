using VidyaSar.Application.Common;
using VidyaSar.Application.DTOs;
using VidyaSar.Domain.Entities;

namespace VidyaSar.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> LoginAsync(AuthRequestDto request);
}

public interface ICommonService
{
    Task<ApiResponse> ResetPasswordAsync(string userId);
}

public interface IUniversityService
{
    Task<ApiResponse> AddUpdateUniversityAsync(UniversityDto dto, string userId);
    Task<ApiResponse> GetUniversityList(long categoryId);
    
    Task<ApiResponse> GetUniversityByIdAsync(long id);
    Task<ApiResponse> DeleteUniversityAsync(long id);
}

public interface IInstituteService
{
    Task<ApiResponse> AddUpdateInstituteAsync(InstituteDto dto, string userId);
    Task<ApiResponse> GetInstituteListAsync(long universityId);
    Task<ApiResponse> GetInstituteByIdAsync(long id);
}

public interface IEducationGroupService
{
    Task<ApiResponse> AddUpdateGroupAsync(EducationGroupDto dto, string userId);

    Task<ApiResponse> GetGroupListAsync();
    Task<ApiResponse> GetGroupByIdAsync(long id);
    Task<ApiResponse> DeleteGroupAsync(long id);
}

public interface ISessionService
{
    Task<ApiResponse> AddUpdateSessionAsync(SessionDto dto);
    Task<ApiResponse> GetSessionListAsync(long collegeId);
    Task<ApiResponse> GetSessionByIdAsync(long id);
    Task<ApiResponse> DeleteSessionAsync(long id);
    Task<ApiResponse> ChangeCurrentSessionAsync(long collegeId, long sessionId);
    Task<ApiResponse> ChangeCurrentAdmissionSessionAsync(long collegeId, long sessionId);
}
public interface IDegreeServices
{
    Task<ApiResponse> AddUpdateDegreeAsync(DegreeDto dto,string userId);
    Task<ApiResponse> GetDegreeListAsync(long collegeId);
    Task<ApiResponse> GetDegreeByIdAsync(long id);
    Task<ApiResponse> DeleteDegreeAsync(long id);
}

public interface IBranchService
{
    Task<ApiResponse> AddUpdateAsync(
        BranchDto dto,
        string userId);

    Task<ApiResponse> DeleteAsync(long id);

    Task<ApiResponse> GetByIdAsync(long id);

    Task<ApiResponse> GetPagedAsync(PaginationDto dto);
}

public interface ISemesterService
{
    Task<ApiResponse> AddUpdateAsync(
        SemesterDto dto,
        string userId);

    Task<ApiResponse> DeleteAsync(long id);

    Task<ApiResponse> GetByIdAsync(long id);

    Task<ApiResponse> GetPagedAsync(PaginationDto dto);
}

public interface IConfigurationService
{
    Task<ApiResponse> CreateDefaultConfigurationsAsync(long collegeId);

    Task<ApiResponse> GetAdmissionConfigurationByCollegeIdAsync(long collegeId);

    Task<ApiResponse> UpdateAdmissionConfigurationAsync(AdmissionConfigurationDto dto);
}
public interface IStudentService
{
    Task<ApiResponse> AddStudentAsync(
        StudentDto dto);

    Task<ApiResponse> GetStudentByIdAsync(string rollNo);

    // Task<ApiResponse> DeleteAsync(long studentId);

    // Task<ApiResponse> GetPagedAsync(
    //     PaginationDto dto);
}