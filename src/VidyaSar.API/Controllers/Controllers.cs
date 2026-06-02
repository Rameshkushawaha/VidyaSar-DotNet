using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VidyaSar.API.Middleware;
using VidyaSar.Application.Common;
using VidyaSar.Application.DTOs;
using VidyaSar.Application.Interfaces;
using VidyaSar.Domain.Entities;

namespace VidyaSar.API.Controllers;

// ──────────────────────────────────────────────
//  Auth Controller  –  POST /api/auth/login
// ──────────────────────────────────────────────
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) => _authService = authService;

    /// <summary>Authenticates a user and returns a JWT token.</summary>
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthRequestDto request)
    {
        try
        {
            Console.WriteLine("called");
            var response = await _authService.LoginAsync(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return Unauthorized(ApiResponse.Fail(ex.Message));
        }
    }
}

// ──────────────────────────────────────────────
//  Common Controller  –  POST /api/common/reset-password
// ──────────────────────────────────────────────
[ApiController]
[Route("api/common")]
[Authorize]
public class CommonController : ControllerBase
{
    private readonly ICommonService _commonService;

    public CommonController(ICommonService commonService) => _commonService = commonService;

    /// <summary>Resets the logged-in user's password to the default.</summary>
    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword()
    {
        var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));

        var result = await _commonService.ResetPasswordAsync(user.Userid);
        return Ok(result);
    }
}

// ──────────────────────────────────────────────
//  University Controller  –  POST /api/university/add-update
// ──────────────────────────────────────────────
[ApiController]
[Route("api/university")]
[Authorize]
public class UniversityController : ControllerBase
{
    private readonly IUniversityService _service;

    public UniversityController(IUniversityService service) => _service = service;

    /// <summary>Creates or updates a university record.</summary>
    [HttpPost("add-update")]
    public async Task<IActionResult> AddUpdateUniversity([FromBody] UniversityDto dto)
    {
        var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));

        var result = await _service.AddUpdateUniversityAsync(dto, user.Userid);
        return Ok(result);
    }

   [HttpGet("getUniversityList")]
    public async Task<IActionResult> GetUniversityList([FromHeader] long categoryId)
    {
         var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));

        var result = await _service.GetUniversityList(categoryId);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUniversityById([FromRoute] long id)
    {
         var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));

        var result = await _service.GetUniversityByIdAsync(id);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUniversity([FromRoute] long id)
    {         var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));       
        var result = await _service.DeleteUniversityAsync(id);
        return Ok(result);
    }    
}

// ──────────────────────────────────────────────
//  Education Group Controller  –  POST /api/group/add-update
// ──────────────────────────────────────────────
[ApiController]
[Route("api/group")]
[Authorize]
public class EducationGroupController : ControllerBase
{
    private readonly IEducationGroupService _service;

    public EducationGroupController(IEducationGroupService service) => _service = service;

    /// <summary>Creates or updates an education group.</summary>
    [HttpPost("add-update")]
    public async Task<IActionResult> AddUpdateGroup([FromBody] EducationGroupDto dto)
    {
        var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));

        var result = await _service.AddUpdateGroupAsync(dto, user.Userid);
        return Ok(result);
    }

    [HttpGet("getGroupList")]
    public async Task<IActionResult> GetGroupList()
    {
         var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));

        var result = await _service.GetGroupListAsync();
        return Ok(result);
    }


}

// ──────────────────────────────────────────────
//  Session Controller  –  POST /api/session/add-update
// ──────────────────────────────────────────────
[ApiController]
[Route("api/session")]
[Authorize]
public class SessionController : ControllerBase
{
    private readonly ISessionService _service;

    public SessionController(ISessionService service) => _service = service;

    /// <summary>Creates or updates an academic session.</summary>
    [HttpPost("add-update")]
    public async Task<IActionResult> AddUpdateSession([FromBody] SessionDto dto)
    {
        var result = await _service.AddUpdateSessionAsync(dto);
        return Ok(result);
    }

    [HttpGet("getSessionList")]
    public async Task<IActionResult> GetSessionList([FromHeader] long collegeId)
    {
         var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));
        var result = await _service.GetSessionListAsync(collegeId);
        return Ok(result);
    }

    [HttpGet("getSessionById")]
    public async Task<IActionResult> GetSessionById([FromHeader] long id)
    {
         var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));
        var result = await _service.GetSessionByIdAsync(id);
        return Ok(result);
    }

    [HttpDelete("deleteSession")]
    public async Task<IActionResult> DeleteSession([FromHeader] long id)
    {
         var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));
        var result = await _service.DeleteSessionAsync(id);
        return Ok(result);
    }
    
    [HttpPost("changeCurrentSession")]
    public async Task<IActionResult> ChangeCurrentSession([FromHeader] long collegeId, [FromHeader] long sessionId)
    {
         var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));
        var result = await _service.ChangeCurrentSessionAsync(collegeId, sessionId);
        return Ok(result);
    }

    [HttpPost("changeCurrentAdmissionSession")]
    public async Task<IActionResult> ChangeCurrentAdmissionSession([FromHeader] long collegeId, [FromHeader] long sessionId)
    {
         var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));
        var result = await _service.ChangeCurrentAdmissionSessionAsync(collegeId, sessionId);
        return Ok(result);
    }
}

// ──────────────────────────────────────────────
//  Institute Controller  –  POST /api/institute/add-update
// ──────────────────────────────────────────────
[ApiController]
[Route("api/institute")]
[Authorize]
public class InstituteController : ControllerBase
{
    private readonly IInstituteService _service;

    public InstituteController(IInstituteService service) => _service = service;

    /// <summary>Creates or updates a college/institute record.</summary>
    [HttpPost("add-update")]
    public async Task<IActionResult> AddUpdateInstitute([FromBody] InstituteDto dto)
    {
        var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));

        var result = await _service.AddUpdateInstituteAsync(dto, user.Userid);
        return Ok(result);
    }

    [HttpGet("getInstituteList")]
    public async Task<IActionResult> GetInstituteList([FromHeader] long universityId)
    {
         var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));
        var result = await _service.GetInstituteListAsync(universityId);
        return Ok(result);
    }

    [HttpGet("getInstituteById")]
    public async Task<IActionResult> GetInstituteById([FromHeader] long id)
    {
         var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));
        var result = await _service.GetInstituteByIdAsync(id);
        return Ok(result);
    }
}

// ──────────────────────────────────────────────
//  Degree Controller  –  POST /api/degree/add-update
// ──────────────────────────────────────────────
[ApiController]
[Route("api/degree")]
[Authorize]
public class DegreeController : ControllerBase
{
    private readonly IDegreeServices _service;

    public DegreeController(IDegreeServices service) => _service = service;

    /// <summary>Creates or updates an academic degree.</summary>
    [HttpPost("add-update")]
    public async Task<IActionResult> AddUpdateDegree([FromBody] DegreeDto dto)
    {
        var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));
        var result = await _service.AddUpdateDegreeAsync(dto,user.Userid);
        return Ok(result);
    }

    [HttpGet("getDegreeList")]
    public async Task<IActionResult> GetDegreeList([FromHeader] long collegeId)
    {
         var user = HttpContext.GetLoggedInUser();
        if (user is null)
        {
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));
        }
        
        var result = await _service.GetDegreeListAsync(collegeId);
        return Ok(result);  
    }

    [HttpGet("getDegreeById")]
    public async Task<IActionResult> GetDegreeById([FromHeader] long id)
    {
         var user = HttpContext.GetLoggedInUser();
        if (user is null)       
        {
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));
        }
        var result = await _service.GetDegreeByIdAsync(id);
        return Ok(result);
    }

    [HttpDelete("deleteDegree")]
    public async Task<IActionResult> DeleteDegree([FromHeader] long id)
    {
         var user = HttpContext.GetLoggedInUser();
        if (user is null)        
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));  

        var result = await _service.DeleteDegreeAsync(id);
        return Ok(result);
    }
}

// ──────────────────────────────────────────────
//  Branch Controller  –  POST /api/branch/add-update
// ──────────────────────────────────────────────

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class BranchController : ControllerBase
{
    private readonly IBranchService _service;

    public BranchController(IBranchService service)
    {
        _service = service;
    }

    [HttpPost("add-update")]
    public async Task<IActionResult> AddUpdate(
        [FromBody] BranchDto dto)
    {
        var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));

        var result =
            await _service.AddUpdateAsync(dto, user.Userid);

        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));
        var result = await _service.DeleteAsync(id);

        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));
        var result = await _service.GetByIdAsync(id);

        return Ok(result);
    }

    [HttpPost("pagination")]
    public async Task<IActionResult> GetPaged(
        [FromBody] PaginationDto dto)
    {
        var user = HttpContext.GetLoggedInUser();
        if (user is null)
            return Unauthorized(ApiResponse.Fail("Unauthorized Access"));
        var result = await _service.GetPagedAsync(dto);

        return Ok(result);
    }
}

// ──────────────────────────────────────────────
//  Branch Controller  –  POST /api/branch/add-update
// ──────────────────────────────────────────────


[ApiController]
[Authorize]
[Route("api/[controller]")]
public class SemesterController : ControllerBase
{
    private readonly ISemesterService _service;

    public SemesterController(ISemesterService service)
    {
        _service = service;
    }

    [HttpPost("add-update")]
    public async Task<IActionResult> AddUpdate(
        [FromBody] SemesterDto dto)
    {
        string userId =
            User?.Identity?.Name ?? "System";

        var result =
            await _service.AddUpdateAsync(dto, userId);

        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _service.DeleteAsync(id);

        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result =
            await _service.GetByIdAsync(id);

        return Ok(result);
    }

    [HttpPost("pagination")]
    public async Task<IActionResult> GetPaged(
        [FromBody] PaginationDto dto)
    {
        var result =
            await _service.GetPagedAsync(dto);

        return Ok(result);
    }
}

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _service;
    
    public StudentController(IStudentService service)
    {
        _service = service;
    }

    [HttpPost("add-student")]
    public async Task<IActionResult> AddStudent(
        [FromBody] StudentDto dto)
    {
        var result =
            await _service.AddStudentAsync(dto);

        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpGet("{rollNo}")]
    public async Task<IActionResult> GetByRollNo(string rollNo)
    {
        var result =
            await _service.GetStudentByIdAsync(rollNo);

        return Ok(result);
    }
}
