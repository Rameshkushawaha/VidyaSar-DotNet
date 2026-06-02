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

        bool isValid = BCrypt.Net.BCrypt.Verify(request.Password, user.password);
        if (!isValid)
            throw new Exception("Invalid UserId or Password");

        string token = _jwtService.GenerateToken(user);

        return new AuthResponseDto
        {
            Token      = token,
            Userid     = user.userid,
            Name       = user.name,
            Role       = user.role,
            CollegeId  = user.cl_col_id,
            BranchId   = user.branch_id,
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

        user.password = BCrypt.Net.BCrypt.HashPassword(defaultPassword);
        user.encryptedpassword  = defaultPassword;

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
                var university = new tbl_mst_col_university
                {
                    university_name = dto.UniversityName,
                    bitisactive    = dto.BitIsActive,
                    updatedatetime = DateTime.UtcNow,
                    category_id     = dto.CategoryId,
                    makercode      = userId,
                    isparent       = dto.IsParent,
                    university_code = dto.UniversityCode
                };

                await _repo.SaveAsync(university);
                return ApiResponse.Ok("Data Added Successfully.");
            }

            // UPDATE
            var existing = await _repo.FindByIdAsync(dto.UniversityId.Value);
            if (existing is null)
                return ApiResponse.Fail("Data Not Found.");

            existing.university_name = dto.UniversityName;
            existing.bitisactive    = dto.BitIsActive;
            existing.updatedatetime = DateTime.UtcNow;
            existing.category_id     = dto.CategoryId;
            existing.makercode      = userId;
            existing.isparent       = dto.IsParent;
            existing.university_code = dto.UniversityCode;

            await _repo.SaveAsync(existing);
            return ApiResponse.Ok("Data Updated Successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }

     public async Task<ApiResponse> GetUniversityList(long categoryId)
    {
        try
        {
            var data =
                await _repo.GetByCategoryIdAsync(categoryId);

            return ApiResponse.Ok(
                "Data Found Successfully.",
                data);
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }

    public async Task<ApiResponse> GetUniversityByIdAsync(long id)
     {
       try
       { 
            var university = await _repo.FindByIdAsync(id);
    
            if (university == null)
               return ApiResponse.Fail("Data Not Found.");
    
            return ApiResponse.Ok(
                "Data Found Successfully.",
                university);
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
   }      
    
    public async Task<ApiResponse> DeleteUniversityAsync(long id)
    {
        try
        {
            var university = await _repo.FindByIdAsync(id);

            if (university == null)
                return ApiResponse.Fail("Data Not Found.");

            university.bitisactive = true;
            university.updatedatetime = DateTime.UtcNow;

            await _repo.SaveAsync(university);

            return ApiResponse.Ok(
                "Data Deleted Successfully.");
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
                var group = new tbl_mst_col_group
                {
                    gr_name            = dto.GrName,
                    makercode         = userId,
                    updatedatetime    = DateTime.UtcNow,
                    category_id        = 74L,
                    facebookurl       = dto.FacebookUrl,
                    twitterurl        = dto.TwitterUrl,
                    linkedinurl       = dto.LinkedinUrl,
                    pinteresturl      = dto.PinterestUrl,
                    googleurl         = dto.GoogleUrl,
                    logowidth         = dto.LogoWidth,
                    url               = dto.Url,
                    bitisactive       = dto.BitIsActive,
                    gr_no              = dto.GrNo,
                    googleplaystoreurl = dto.GooglePlayStoreUrl,
                    applestoreurl     = dto.AppleStoreUrl,
                    entityid          = 1L
                };

                await _repo.SaveAsync(group);
                return ApiResponse.Ok("Data Added Successfully.");
            }

            // UPDATE
            var existing = await _repo.FindByIdAsync(dto.GrId.Value);
            if (existing == null)
                return ApiResponse.Fail("No Data Found.");

            existing.gr_name            = dto.GrName;
            existing.makercode         = userId;
            existing.updatedatetime    = DateTime.UtcNow;
            existing.facebookurl       = dto.FacebookUrl;
            existing.twitterurl        = dto.TwitterUrl;
            existing.linkedinurl       = dto.LinkedinUrl;
            existing.pinteresturl      = dto.PinterestUrl;
            existing.googleurl         = dto.GoogleUrl;
            existing.logowidth         = dto.LogoWidth;
            existing.url               = dto.Url;
            existing.bitisactive       = dto.BitIsActive;
            existing.gr_no              = dto.GrNo;
            existing.googleplaystoreurl = dto.GooglePlayStoreUrl;
            existing.applestoreurl     = dto.AppleStoreUrl;

            await _repo.SaveAsync(existing);
            return ApiResponse.Ok("Data Updated Successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }

    public async Task<ApiResponse> GetGroupListAsync()
    {
        var data = await _repo.FindAll();

        return ApiResponse.Ok("done",data);
    }

    public async Task<ApiResponse> GetGroupByIdAsync(long id)
    {
        var data = await _repo.FindByIdAsync(id);
        if (data == null)
            return ApiResponse.Fail("Data Not Found.");

        return ApiResponse.Ok("done", data);
    }

    public async Task<ApiResponse> DeleteGroupAsync(long id)
    {
        try
        {
            var group = await _repo.FindByIdAsync(id);

            if (group == null)
                return ApiResponse.Fail("Data Not Found.");

            group.bitisactive = false;
            group.updatedatetime = DateTime.UtcNow;

            await _repo.SaveAsync(group);

            return ApiResponse.Ok(
                "Data Deleted Successfully.");
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
                var session = new session_master
                {
                    session_name        = dto.SessionName,
                    session_start_date   = dto.SessionStartDate,
                    session_end_date     = dto.SessionEndDate,
                    cl_col_id            = dto.ClColId,
                    bitisactive        = dto.BitIsActive,
                    session_fees        = dto.SessionFees,
                    current_session     = dto.CurrentSession,
                    admission_session   = dto.AdmissionSession,
                    admission_bitisactive = dto.AdmissionBitIsActive,
                    sessionyear        = dto.SessionYear,
                    admissiondate      = dto.AdmissionDate
                };

                await _repo.SaveAsync(session);
                return ApiResponse.Ok("Data Added Successfully.");
            }

            // UPDATE
            var existing = await _repo.FindByIdAsync(dto.SessionId.Value);
            if (existing is null)
                return ApiResponse.Fail("No Data Found.");

            existing.session_name        = dto.SessionName;
            existing.session_start_date   = dto.SessionStartDate;
            existing.session_end_date     = dto.SessionEndDate;
            existing.cl_col_id            = dto.ClColId;
            existing.bitisactive        = dto.BitIsActive;
            existing.session_fees        = dto.SessionFees;
            existing.current_session     = dto.CurrentSession;
            existing.admission_session   = dto.AdmissionSession;
            existing.admission_bitisactive = dto.AdmissionBitIsActive;
            existing.sessionyear        = dto.SessionYear;
            existing.admissiondate      = dto.AdmissionDate;

            await _repo.SaveAsync(existing);
            return ApiResponse.Ok("Data Updated Successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }
    
    public async Task<ApiResponse> GetSessionListAsync(long collegeId)
        {
            try
            {
                var data = await _repo.GetByCollegeIdAsync(collegeId);
    
                return ApiResponse.Ok(
                    "Data Found Successfully.",
                    data);
            }
            catch (Exception ex)
            {
                return ApiResponse.Fail(ex.Message);
            }
        }
    
    public async Task<ApiResponse> GetSessionByIdAsync(long id)
    {
        try
        {
            var data = await _repo.FindByIdAsync(id);
            if (data == null)
                return ApiResponse.Fail("Data Not Found.");

            return ApiResponse.Ok("Data Found Successfully.", data);
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }

    public async Task<ApiResponse> DeleteSessionAsync(long id)
    {
        try
        {
            var session = await _repo.FindByIdAsync(id);

            if (session == null)
                return ApiResponse.Fail("Data Not Found.");

            session.bitisactive = false;

            await _repo.SaveAsync(session);

            return ApiResponse.Ok(
                "Data Deleted Successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }
    
    public async Task<ApiResponse> ChangeCurrentSessionAsync(long collegeId, long sessionId)
    {
        try
        {
            var sessions = await _repo.GetByCollegeIdAsync(collegeId);

            var newCurrent = sessions.FirstOrDefault(s => s.session_id == sessionId);
            if (newCurrent == null)
                return ApiResponse.Fail("Session Not Found.");

            foreach (var session in sessions)
            {
                session.current_session = session.session_id == sessionId;
                await _repo.SaveAsync(session);
            }

            return ApiResponse.Ok("Current Session Updated Successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }

    public async Task<ApiResponse> ChangeCurrentAdmissionSessionAsync(long collegeId, long sessionId)
    {
        try
        {
            var sessions = await _repo.GetByCollegeIdAsync(collegeId);

            var newCurrent = sessions.FirstOrDefault(s => s.session_id == sessionId);
            if (newCurrent == null)
                return ApiResponse.Fail("Session Not Found.");

            foreach (var session in sessions)
            {
                session.admission_session = session.session_id == sessionId ? session.session_id : null;
                await _repo.SaveAsync(session);
            }

            return ApiResponse.Ok("Current Admission Session Updated Successfully.");
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
    private readonly IUserRepository _userRepo;
    public InstituteService(ICollegeRepository repo, IConfigurationRepository configRepo, IUserRepository userRepo)
    {
        _repo       = repo;
        _configRepo = configRepo;
        _userRepo   = userRepo;
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
                var college = new tbl_mst_collage();
                MapInstitute(dto, college);
                college.makercode      = userId;
                college.updatedatetime = DateTime.UtcNow;

                long newId = await _repo.SaveAsync(college);

                await _configRepo.CreateDefaultConfigurationsAsync(newId);

                // Create default users
                await _userRepo.CreateDefaultUserProfileAsync(newId, dto.InstitutionId);

                return ApiResponse.Ok("Institute Added Successfully", newId);
            }

            // UPDATE
            var existing = await _repo.FindByIdAsync(dto.ClColId.Value);
            if (existing == null)
                return ApiResponse.Fail("Institute Not Found");

            MapInstitute(dto, existing);
            existing.updatedatetime = DateTime.UtcNow;

            await _repo.SaveAsync(existing);
            return ApiResponse.Ok("Institute Updated Successfully", existing.cl_col_id);
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }

    private static void MapInstitute(InstituteDto dto, tbl_mst_collage college)
    {
        college.cl_col_name      = dto.ClColName;
        college.bitisactive    = dto.BitIsActive;
        college.address        = dto.Address;
        college.city           = dto.City;
        college.state          = dto.State;
        college.country        = dto.Country;
        college.phone          = dto.Phone;
        college.emailid        = dto.EmailId;
        college.institution_id  = dto.InstitutionId;
        college.university_id   = dto.UniversityId;
        college.website        = dto.Website;
        college.marksheetalias = dto.MarksheetAlias;
        college.schoolcode     = dto.SchoolCode;
        college.affiliationno  = dto.AffiliationNo;
    }

    // Placeholder — wired at infrastructure level if needed
    private Task CreateDefaultUsersAsync(long collegeId, long? institutionId) =>
        Task.CompletedTask;
    
    public async Task<ApiResponse> GetInstituteListAsync(long universityId)
    {
        try
        {
            var data = await _repo.GetByUniversityIdAsync(universityId);

            return ApiResponse.Ok(
                "Data Found Successfully.",
                data);
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }

    public async Task<ApiResponse> GetInstituteByIdAsync(long id)
    {
        try
        {
            var data = await _repo.FindByIdAsync(id);
            if (data == null)
                return ApiResponse.Fail("Data Not Found.");

            return ApiResponse.Ok("Data Found Successfully.", data);
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }
}


// degree service
 public class DegreeService : IDegreeServices
 {
        private readonly IDegreeRepository _repo;

        public DegreeService(IDegreeRepository repo)=>_repo = repo;
        public async Task<ApiResponse> AddUpdateDegreeAsync(DegreeDto dto,string userId)
        {
            try
            {
                bool isDuplicate = await _repo.ExistsByCategoryDescriptionAndCollegeExcludingIdAsync(dto.Category_Description.ToLower(),dto.CL_Col_Id, dto.Category_Id ??0);

                if (isDuplicate)
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Degree already exists."
                    };
                }

                if (dto.Category_Id == null || dto.Category_Id == 0)
                {

                    var degree = new degree_master
                    {
                        category_description = dto.Category_Description,
                        degree_name = dto.Degree_Name,
                        bitisactive = dto.bitIsActive,
                        cl_col_id = dto.CL_Col_Id,
                        col_fulladdress = dto.Col_FullAddress,
                        issuebooklimit = dto.issueBooklimit,
                        updatedatetime = DateTime.Now,
                        makercode = userId
                    };

                    await _repo.SaveAsync(degree);

                    return new ApiResponse
                    {
                        Success = true,
                        Message = "Degree added successfully."
                    };
                }
                else
                {
                    var degree = await _repo.FindByIdAsync( dto.Category_Id);

                    if (degree == null)
                    {
                        return new ApiResponse
                        {
                            Success = false,
                            Message = "Degree not found."
                        };
                    }

                    degree.category_description = dto.Category_Description;
                    degree.degree_name = dto.Degree_Name;
                    degree.bitisactive = dto.bitIsActive;
                    degree.cl_col_id = dto.CL_Col_Id;
                    degree.col_fulladdress = dto.Col_FullAddress;
                    degree.issuebooklimit = dto.issueBooklimit;
                    degree.updatedatetime = DateTime.Now;

                    await _repo.SaveAsync(degree);

                    return new ApiResponse
                    {
                        Success = true,
                        Message = "Degree updated successfully."
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    public async Task<ApiResponse> GetDegreeListAsync(long collegeId)
    {
        try
        {
            await _repo.GetByCollegeIdAsync(collegeId);

            return ApiResponse.Ok("Data Found Successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }

    public async Task<ApiResponse> GetDegreeByIdAsync(long id)
    {
        try
        {
            var data = await _repo.FindByIdAsync(id);
            if (data == null)
                return ApiResponse.Fail("Data Not Found.");

            return ApiResponse.Ok("Data Found Successfully.", data);
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }

    public async Task<ApiResponse> DeleteDegreeAsync(long id)
    {
        try
        {
            var degree = await _repo.FindByIdAsync(id);

            if (degree == null)
                return ApiResponse.Fail("Data Not Found.");

            degree.bitisactive = false;

            await _repo.SaveAsync(degree);

            return ApiResponse.Ok(
                "Data Deleted Successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }
}

// degree service

public class BranchService : IBranchService
{
    private readonly IBranchRepository _repo;

    public BranchService(IBranchRepository repo)
    {
        _repo = repo;
    }

    public async Task<ApiResponse> AddUpdateAsync(
        BranchDto dto,
        string userId)
    {
        try
        {
            long excludeId = dto.BranchId ?? 0;

            bool duplicate = await _repo.ExistsAsync(
                dto.BranchName,
                dto.CategoryId,
                excludeId);

            if (duplicate)
                return ApiResponse.Fail("Data Already Exists.");

            // ADD

            if (dto.BranchId == null || dto.BranchId == 0)
            {
                var branch = new tbl_mst_col_branch
                {
                    br_branch_name = dto.BranchName,
                    br_full_name = dto.FullName,
                    br_branch_no = dto.BranchNo,
                    category_id = dto.CategoryId,
                    cl_col_id = dto.CollegeId,
                    bitisactive = dto.BitIsActive,
                    hodid = dto.HODId,
                    degree_type = dto.DegreeType,
                    daycare = dto.DayCare,
                    makercode = userId,
                    updatedatetime = DateTime.UtcNow
                };

                await _repo.SaveAsync(branch);

                return ApiResponse.Ok(
                    "Data Added Successfully.");
            }

            // UPDATE

            var existing =
                await _repo.GetByIdAsync(dto.BranchId.Value);

            if (existing == null)
                return ApiResponse.Fail("Data Not Found.");

            existing.br_branch_name = dto.BranchName;
            existing.br_full_name = dto.FullName;
            existing.br_branch_no = dto.BranchNo;
            existing.category_id = dto.CategoryId;
            existing.cl_col_id = dto.CollegeId;
            existing.bitisactive = dto.BitIsActive;
            existing.hodid = dto.HODId;
            existing.degree_type = dto.DegreeType;
            existing.daycare = dto.DayCare;
            existing.makercode = userId;
            existing.updatedatetime = DateTime.UtcNow;

            await _repo.SaveAsync(existing);

            return ApiResponse.Ok(
                "Data Updated Successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }

    public async Task<ApiResponse> DeleteAsync(long id)
    {
        try
        {
            var branch = await _repo.GetByIdAsync(id);

            if (branch == null)
                return ApiResponse.Fail("Data Not Found.");

            await _repo.DeleteAsync(branch);

            return ApiResponse.Ok(
                "Data Deleted Successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }

    public async Task<ApiResponse> GetByIdAsync(long id)
    {
        try
        {
            var branch = await _repo.GetByIdAsync(id);

            if (branch == null)
                return ApiResponse.Fail("Data Not Found.");

            return ApiResponse.Ok(
                "Data Found Successfully.",
                branch);
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }

    public async Task<ApiResponse> GetPagedAsync(
        PaginationDto dto)
    {
        try
        {
            var data = await _repo.GetPagedAsync(
                dto.PageNumber,
                dto.PageSize,
                dto.SearchText);

            int totalCount =
                await _repo.GetTotalCountAsync(dto.SearchText);

            return ApiResponse.Ok(
                "Data Found Successfully.",
                new
                {
                    TotalCount = totalCount,
                    PageNumber = dto.PageNumber,
                    PageSize = dto.PageSize,
                    Data = data
                });
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }
}

public class SemesterService : ISemesterService
{
    private readonly ISemesterRepository _repo;

    public SemesterService(ISemesterRepository repo)
    {
        _repo = repo;
    }

    public async Task<ApiResponse> AddUpdateAsync(
        SemesterDto dto,
        string userId)
    {
        try
        {
            long excludeId = dto.SemesterId ?? 0;

            bool isDuplicate =
                await _repo.ExistsAsync(
                    dto.SemesterName,
                    dto.CollegeId,
                    excludeId);

            if (isDuplicate)
            {
                return ApiResponse.Fail(
                    "Data Already Exists.");
            }

            // ADD

            if (dto.SemesterId == null || dto.SemesterId == 0)
            {
                var semester = new tbl_mst_semister_detail
                {
                    sm_sem_name = dto.SemesterName,
                    br_branch_id = dto.BranchId,
                    makercode = userId,
                    updatedatetime = DateTime.UtcNow,
                    bitisactive = dto.BitIsActive,
                    bitevenodd = dto.BitEvenOdd,
                    sm_sem_no = dto.SemesterNo,
                    cl_col_id = dto.CollegeId,
                    years = dto.Years,
                    electivesittingarrangement = dto.ElectiveSittingArrangement,
                    isteacher = dto.IsTeacher,
                    sem_degreeid = dto.DegreeId
                };

                await _repo.SaveAsync(semester);

                return ApiResponse.Ok(
                    "Data Added Successfully.");
            }

            // UPDATE

            var existing =
                await _repo.GetByIdAsync(dto.SemesterId.Value);

            if (existing == null)
            {
                return ApiResponse.Fail(
                    "Data Not Found.");
            }

            existing.sm_sem_name = dto.SemesterName;
            existing.br_branch_id = dto.BranchId;
            existing.makercode = userId;
            existing.updatedatetime = DateTime.UtcNow;
            existing.bitisactive = dto.BitIsActive;
            existing.bitevenodd = dto.BitEvenOdd;
            existing.sm_sem_no = dto.SemesterNo;
            existing.cl_col_id = dto.CollegeId;
            existing.years = dto.Years;
            existing.electivesittingarrangement =
                dto.ElectiveSittingArrangement;
            existing.isteacher = dto.IsTeacher;
            existing.sem_degreeid = dto.DegreeId;

            await _repo.SaveAsync(existing);

            return ApiResponse.Ok(
                "Data Updated Successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }

    public async Task<ApiResponse> DeleteAsync(long id)
    {
        try
        {
            var semester = await _repo.GetByIdAsync(id);

            if (semester == null)
            {
                return ApiResponse.Fail("Data Not Found.");
            }

            await _repo.DeleteAsync(semester);

            return ApiResponse.Ok(
                "Data Deleted Successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }

    public async Task<ApiResponse> GetByIdAsync(long id)
    {
        try
        {
            var semester = await _repo.GetByIdAsync(id);

            if (semester == null)
            {
                return ApiResponse.Fail("Data Not Found.");
            }

            return ApiResponse.Ok(
                "Data Found Successfully.",
                semester);
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }

    public async Task<ApiResponse> GetPagedAsync(
        PaginationDto dto)
    {
        try
        {
            var data = await _repo.GetPagedAsync(
                dto.PageNumber,
                dto.PageSize,
                dto.SearchText);

            int totalCount =
                await _repo.GetTotalCountAsync(dto.SearchText);

            return ApiResponse.Ok(
                "Data Found Successfully.",
                new
                {
                    TotalCount = totalCount,
                    PageNumber = dto.PageNumber,
                    PageSize = dto.PageSize,
                    Data = data
                });
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }
}

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repo;

    public StudentService(IStudentRepository repo)
    {
        _repo = repo;
    }

   public async Task<ApiResponse> AddStudentAsync(StudentDto dto){
   
    try
    {
        string fullName =
            $"{dto.FirstName} {dto.MiddleName} {dto.LastName}"
            .Replace("  ", " ")
            .Trim();

        bool exists = await _repo.ExistsAsync(
            dto.MobileNo,
            dto.EmailId,
            fullName);

        if (exists)
        {
            return ApiResponse.Fail(
                "Student Already Exists.");
        }

        string rollNo =
            await _repo.GenerateRollNoAsync(
                dto.CollegeId,
                dto.SessionId,
                dto.BranchId,
                dto.SemesterId);

        long studentId =
            await _repo.GenerateStudentIdAsync();

        var student = new student_detail
        {
            student_id = studentId,

            firstname = dto.FirstName,
            middlename = dto.MiddleName,
            lastname = dto.LastName,

            full_name = fullName,

            father_name = dto.FatherName,
            mother_name = dto.MotherName,

            stud_mobile = dto.MobileNo,
            email_id = dto.EmailId,

            cl_col_id = dto.CollegeId,
            session_id = dto.SessionId,
            br_branch_id = dto.BranchId,

            current_semester = dto.SemesterId,
            studentdegree = dto.DegreeId,

            date_of_birth = dto.DateOfBirth,
            studentgender = dto.Gender,

            perm_address = dto.Address,

            roll_no = rollNo,

            dateofadmission =
                DateOnly.FromDateTime(DateTime.UtcNow),

            admissionyear = dto.SessionId,

            admittedinbranch = dto.BranchId,

            updatedatetime = DateTime.UtcNow,

            status_id = 1,

            student_cast = dto.StudentCast,
            blood_groups = dto.StudentBloodGroup
        };

        await _repo.AddStudentAsync(student);

        var profile = new UserProfile
        {
            userid = rollNo,

            password = dto.MobileNo,

            name = fullName,

            firstname = dto.FirstName,
            middlename = dto.MiddleName,
            lastname = dto.LastName,

            emailid = dto.EmailId,

            telno = dto.MobileNo,

            phone_no = long.TryParse(dto.MobileNo, out long phone)
                ? phone
                : 0,

            role = 2,

            active = 1,

            makerdatetime = DateTime.UtcNow,

            perm_address = dto.Address,
            current_address = dto.Address,

            cl_col_id = dto.CollegeId,
            branch_id = dto.BranchId
        };

        await _repo.AddUserProfileAsync(profile);

        await _repo.SaveChangesAsync();


        return ApiResponse.Ok(
            "Student Added Successfully.",
            new
            {
                StudentId = studentId,
                RollNo = rollNo,
                UserId = rollNo
            });
    }
    catch (Exception ex)
    {
    
        return ApiResponse.Fail(ex.Message);
    }
}

    public async Task<ApiResponse> GetStudentByIdAsync(string rollNo)
    {
        try
        {
            var student = await _repo.GetByIdAsync(rollNo);

            if (student == null)
                return ApiResponse.Fail("Data Not Found.");

            return ApiResponse.Ok(
                "Data Found Successfully.",
                student);
        }
        catch (Exception ex)
        {
            return ApiResponse.Fail(ex.Message);
        }
    }

    
}