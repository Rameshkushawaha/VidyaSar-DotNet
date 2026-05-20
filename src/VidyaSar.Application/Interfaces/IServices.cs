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
}

public interface IInstituteService
{
    Task<ApiResponse> AddUpdateInstituteAsync(InstituteDto dto, string userId);
}

public interface IEducationGroupService
{
    Task<ApiResponse> AddUpdateGroupAsync(EducationGroupDto dto, string userId);
}

public interface ISessionService
{
    Task<ApiResponse> AddUpdateSessionAsync(SessionDto dto);
}
