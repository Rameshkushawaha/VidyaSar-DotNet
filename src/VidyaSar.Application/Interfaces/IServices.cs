using VidyaSar.Application.Common;
using VidyaSar.Application.DTOs;

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
}

public interface IInstituteService
{
    Task<ApiResponse> AddUpdateInstituteAsync(InstituteDto dto, string userId);
}

public interface IEducationGroupService
{
    Task<ApiResponse> AddUpdateGroupAsync(EducationGroupDto dto, string userId);

    Task<ApiResponse> GetGroupListAsync();
}

public interface ISessionService
{
    Task<ApiResponse> AddUpdateSessionAsync(SessionDto dto);
}
public interface IDegreeServices
{
    Task<ApiResponse> AddUpdateDegreeAsync(DegreeDto dto,string userId);
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
