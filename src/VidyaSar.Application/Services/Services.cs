using VidyaSar.Application.Common;
using VidyaSar.Application.DTOs;
using VidyaSar.Application.Interfaces;
using VidyaSar.Domain.Entities;

namespace VidyaSar.Application.Services;

// ──────────────────────────────────────────────
//  Auth Service
// ──────────────────────────────────────────────
public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepo;
    private readonly IJwtService _jwtService;

    public AuthService(IUserRepository userRepo, IJwtService jwtService)
    {
        _userRepo = userRepo;
        _jwtService = jwtService;
    }

    public async Task<AuthResponseDto> LoginAsync(AuthRequestDto request)
    {
        var user = await _userRepo.FindByUseridAsync(request.Userid)
            ?? throw new Exception("Invalid User");

        bool isValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
        if (!isValid)
            throw new Exception("Invalid UserId or Password");

        string token = _jwtService.GenerateToken(user);

        return new AuthResponseDto
        {
            Token      = token,
            Userid     = user.Userid,
            Name       = user.Name,
            Role       = user.Role,
            CollegeId  = user.ClColId,
            BranchId   = user.BranchId,
            ExpiryTime = _jwtService.GetExpirationTime()
        };
    }
}

// ──────────────────────────────────────────────
//  Common Service
// ──────────────────────────────────────────────
public class CommonService : ICommonService
{
    private readonly IUserRepository _userRepo;

    public CommonService(IUserRepository userRepo) => _userRepo = userRepo;

    public async Task<ApiResponse> ResetPasswordAsync(string userId)
    {
        const string defaultPassword = "Password@123";

        var user = await _userRepo.FindByIdAsync(userId)
            ?? throw new Exception("User Not Found");

        user.Password = BCrypt.Net.BCrypt.HashPassword(defaultPassword);
        user.Encryptedpassword  = defaultPassword;

        await _userRepo.SaveAsync(user);

        return ApiResponse.Ok("Password reset successfully.", defaultPassword);
    }
}

// ──────────────────────────────────────────────
//  University Service
// ──────────────────────────────────────────────
public class UniversityService : IUniversityService
{
    private readonly IUniversityRepository _repo;

    public UniversityService(IUniversityRepository repo) => _repo = repo;

    public async Task<ApiResponse> AddUpdateUniversityAsync(UniversityDto dto, string userId)
    {
        try
        {
            long excludeId = dto.UniversityId ?? 0;

            bool isDuplicate = await _repo.ExistsByNameExcludingIdAsync(
                dto.UniversityName!, excludeId);

            if (isDuplicate)
                return ApiResponse.Fail("Data Already Exists.");

            // ADD
            if (dto.UniversityId is null or 0)
            {
                var university = new University
                {
                    UniversityName = dto.UniversityName,
                    BitIsActive    = dto.BitIsActive,
                    UpdateDateTime = DateTime.UtcNow,
                    CategoryId     = dto.CategoryId,
                    MakerCode      = userId,
                    IsParent       = dto.IsParent,
                    UniversityCode = dto.UniversityCode
                };

                await _repo.SaveAsync(university);
                return ApiResponse.Ok("Data Added Successfully.");
            }

            // UPDATE
            var existing = await _repo.FindByIdAsync(dto.UniversityId.Value);
            if (existing is null)
                return ApiResponse.Fail("Data Not Found.");

            existing.UniversityName = dto.UniversityName;
            existing.BitIsActive    = dto.BitIsActive;
            existing.UpdateDateTime = DateTime.UtcNow;
            existing.CategoryId     = dto.CategoryId;
            existing.MakerCode      = userId;
            existing.IsParent       = dto.IsParent;
            existing.UniversityCode = dto.UniversityCode;

            await _repo.SaveAsync(existing);
            return ApiResponse.Ok("Data Updated Successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }
}

// ──────────────────────────────────────────────
//  Education Group Service
// ──────────────────────────────────────────────
public class EducationGroupService : IEducationGroupService
{
    private readonly IEducationGroupRepository _repo;

    public EducationGroupService(IEducationGroupRepository repo) => _repo = repo;

    public async Task<ApiResponse> AddUpdateGroupAsync(EducationGroupDto dto, string userId)
    {
        try
        {
            long excludeId = dto.GrId ?? 0;

            bool isDuplicate = await _repo.ExistsByNameExcludingIdAsync(dto.GrName!, excludeId);
            if (isDuplicate)
                return ApiResponse.Fail("Data Already Exists.");

            // ADD
            if (dto.GrId is null or 0)
            {
                var group = new EducationGroup
                {
                    GrName            = dto.GrName,
                    MakerCode         = userId,
                    UpdateDateTime    = DateTime.UtcNow,
                    CategoryId        = 74L,
                    FacebookUrl       = dto.FacebookUrl,
                    TwitterUrl        = dto.TwitterUrl,
                    LinkedinUrl       = dto.LinkedinUrl,
                    PinterestUrl      = dto.PinterestUrl,
                    GoogleUrl         = dto.GoogleUrl,
                    LogoWidth         = dto.LogoWidth,
                    Url               = dto.Url,
                    BitIsActive       = dto.BitIsActive,
                    GrNo              = dto.GrNo,
                    GooglePlayStoreUrl = dto.GooglePlayStoreUrl,
                    AppleStoreUrl     = dto.AppleStoreUrl,
                    EntityId          = 1L
                };

                await _repo.SaveAsync(group);
                return ApiResponse.Ok("Data Added Successfully.");
            }

            // UPDATE
            var existing = await _repo.FindByIdAsync(dto.GrId.Value);
            if (existing == null)
                return ApiResponse.Fail("No Data Found.");

            existing.GrName            = dto.GrName;
            existing.MakerCode         = userId;
            existing.UpdateDateTime    = DateTime.UtcNow;
            existing.FacebookUrl       = dto.FacebookUrl;
            existing.TwitterUrl        = dto.TwitterUrl;
            existing.LinkedinUrl       = dto.LinkedinUrl;
            existing.PinterestUrl      = dto.PinterestUrl;
            existing.GoogleUrl         = dto.GoogleUrl;
            existing.LogoWidth         = dto.LogoWidth;
            existing.Url               = dto.Url;
            existing.BitIsActive       = dto.BitIsActive;
            existing.GrNo              = dto.GrNo;
            existing.GooglePlayStoreUrl = dto.GooglePlayStoreUrl;
            existing.AppleStoreUrl     = dto.AppleStoreUrl;

            await _repo.SaveAsync(existing);
            return ApiResponse.Ok("Data Updated Successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }
}

// ──────────────────────────────────────────────
//  Session Service
// ──────────────────────────────────────────────
public class SessionService : ISessionService
{
    private readonly ISessionRepository _repo;

    public SessionService(ISessionRepository repo) => _repo = repo;

    public async Task<ApiResponse> AddUpdateSessionAsync(SessionDto dto)
    {
        try
        {
            long excludeId = dto.SessionId ?? 0;

            bool isDuplicate = await _repo.ExistsByNameAndCollegeExcludingIdAsync(
                dto.SessionName!, dto.ClColId!.Value, excludeId);

            if (isDuplicate)
                return ApiResponse.Fail("Data Already Exists.");

            // ADD
            if (dto.SessionId is null or 0)
            {
                var session = new SessionMaster
                {
                    SessionName        = dto.SessionName,
                    SessionStartDate   = dto.SessionStartDate,
                    SessionEndDate     = dto.SessionEndDate,
                    ClColId            = dto.ClColId,
                    BitIsActive        = dto.BitIsActive,
                    SessionFees        = dto.SessionFees,
                    CurrentSession     = dto.CurrentSession,
                    AdmissionSession   = dto.AdmissionSession,
                    AdmissionBitIsActive = dto.AdmissionBitIsActive,
                    SessionYear        = dto.SessionYear,
                    AdmissionDate      = dto.AdmissionDate
                };

                await _repo.SaveAsync(session);
                return ApiResponse.Ok("Data Added Successfully.");
            }

            // UPDATE
            var existing = await _repo.FindByIdAsync(dto.SessionId.Value);
            if (existing is null)
                return ApiResponse.Fail("No Data Found.");

            existing.SessionName        = dto.SessionName;
            existing.SessionStartDate   = dto.SessionStartDate;
            existing.SessionEndDate     = dto.SessionEndDate;
            existing.ClColId            = dto.ClColId;
            existing.BitIsActive        = dto.BitIsActive;
            existing.SessionFees        = dto.SessionFees;
            existing.CurrentSession     = dto.CurrentSession;
            existing.AdmissionSession   = dto.AdmissionSession;
            existing.AdmissionBitIsActive = dto.AdmissionBitIsActive;
            existing.SessionYear        = dto.SessionYear;
            existing.AdmissionDate      = dto.AdmissionDate;

            await _repo.SaveAsync(existing);
            return ApiResponse.Ok("Data Updated Successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }
}

// ──────────────────────────────────────────────
//  Institute Service
// ──────────────────────────────────────────────
public class InstituteService : IInstituteService
{
    private readonly ICollegeRepository _repo;
    private readonly IConfigurationRepository _configRepo;

    public InstituteService(ICollegeRepository repo, IConfigurationRepository configRepo)
    {
        _repo       = repo;
        _configRepo = configRepo;
    }

    public async Task<ApiResponse> AddUpdateInstituteAsync(InstituteDto dto, string userId)
    {
        try
        {
            long excludeId = dto.ClColId ?? 0;

            if (await _repo.ExistsByNameExcludingIdAsync(dto.ClColName!, excludeId))
                return ApiResponse.Fail("Institute already exists.");

            if (string.IsNullOrWhiteSpace(dto.MarksheetAlias) ||
                string.IsNullOrWhiteSpace(dto.SchoolCode))
                return ApiResponse.Fail("Institute Code and School Code cannot be null.");

            if (await _repo.ExistsByMarksheetAliasExcludingIdAsync(dto.MarksheetAlias!, excludeId))
                return ApiResponse.Fail("Marksheet Alias already exists.");

            if (await _repo.ExistsBySchoolCodeExcludingIdAsync(dto.SchoolCode!, excludeId))
                return ApiResponse.Fail("School Code already exists.");

            // ADD
            if (dto.ClColId is null or 0)
            {
                var college = new College();
                MapInstitute(dto, college);
                college.MakerCode      = userId;
                college.UpdateDateTime = DateTime.UtcNow;

                long newId = await _repo.SaveAsync(college);

                await _configRepo.CreateDefaultConfigurationsAsync(newId);

                // Create default users
                await CreateDefaultUsersAsync(newId, dto.InstitutionId);

                return ApiResponse.Ok("Institute Added Successfully", newId);
            }

            // UPDATE
            var existing = await _repo.FindByIdAsync(dto.ClColId.Value);
            if (existing == null)
                return ApiResponse.Fail("Institute Not Found");

            MapInstitute(dto, existing);
            existing.UpdateDateTime = DateTime.UtcNow;

            await _repo.SaveAsync(existing);
            return ApiResponse.Ok("Institute Updated Successfully", existing.ClColId);
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }

    private static void MapInstitute(InstituteDto dto, College college)
    {
        college.ClColName      = dto.ClColName;
        college.BitIsActive    = dto.BitIsActive;
        college.Address        = dto.Address;
        college.City           = dto.City;
        college.State          = dto.State;
        college.Country        = dto.Country;
        college.Phone          = dto.Phone;
        college.EmailId        = dto.EmailId;
        college.InstitutionId  = dto.InstitutionId;
        college.UniversityId   = dto.UniversityId;
        college.Website        = dto.Website;
        college.MarksheetAlias = dto.MarksheetAlias;
        college.SchoolCode     = dto.SchoolCode;
        college.AffiliationNo  = dto.AffiliationNo;
    }

    // Placeholder — wired at infrastructure level if needed
    private Task CreateDefaultUsersAsync(long collegeId, long? institutionId) =>
        Task.CompletedTask;
}
