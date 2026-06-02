using Microsoft.EntityFrameworkCore;
using VidyaSar.Application.DTOs;
using VidyaSar.Application.Interfaces;
using VidyaSar.Domain.Entities;
using VidyaSar.Infrastructure.Data;
using VidyaSar.Infrastructure.Helpers;

namespace VidyaSar.Infrastructure.Repositories;

// ──────────────────────────────────────────────
//  User Repository
// ──────────────────────────────────────────────
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;
    public UserRepository(AppDbContext db) => _db = db;

    public Task<UserProfile?> FindByUseridAsync(string userid) =>
        _db.userprofiles.FirstOrDefaultAsync(u => u.userid == userid);

    public Task<UserProfile?> FindByIdAsync(string userid) =>
        _db.userprofiles.FindAsync(userid).AsTask();

    public async Task SaveAsync(UserProfile user)
    {
        if (_db.Entry(user).State == EntityState.Detached)
            _db.userprofiles.Add(user);
        await _db.SaveChangesAsync();
    }
    public async Task CreateDefaultUserProfileAsync(long collegeId,long? institutionId)
{
    var users = new List<UserProfile>
    {
        new UserProfile
        {
            userid = $"{collegeId}1006",
            password = BCrypt.Net.BCrypt.HashPassword("SuperAdmin@123"),
            role = 6,
            active = 1,
            name = "Super Admin",
            cl_col_id = collegeId,
            makerdatetime = DateTime.UtcNow,
            encryptedpassword = "SuperAdmin@123"
        },

        new UserProfile
        {
            userid = $"{collegeId}1005",
            password = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
            role = 5,
            active = 1,
            name = "Admin",
            cl_col_id = collegeId,
            makerdatetime = DateTime.UtcNow,
            encryptedpassword = "Admin@123"
        },

        new UserProfile
        {
            userid = $"{collegeId}1001",
            password = BCrypt.Net.BCrypt.HashPassword("Teacher@123"),
            role = 1,
            active = 1,
            name = "Teacher",
            cl_col_id = collegeId,
            makerdatetime = DateTime.UtcNow,
            encryptedpassword = "Teacher@123"
        },

        new UserProfile
        {
            userid = $"{collegeId}1002",
            password = BCrypt.Net.BCrypt.HashPassword("Student@123"),
            role = 2,
            active = 1,
            name = "Student",
            cl_col_id = collegeId,
            makerdatetime = DateTime.UtcNow,
            encryptedpassword = "Student@123"
        }


    };

    await _db.userprofiles.AddRangeAsync(users);
    await _db.SaveChangesAsync();
}


}

// ──────────────────────────────────────────────
//  University Repository
// ──────────────────────────────────────────────
public class UniversityRepository : IUniversityRepository
{
    private readonly AppDbContext _db;
    public UniversityRepository(AppDbContext db) => _db = db;

    public Task<bool> ExistsByNameExcludingIdAsync(string name, long excludeId) =>
        _db.tbl_mst_col_universities.AnyAsync(u =>
            u.university_name!.ToLower() == name.ToLower() &&
            u.university_id != excludeId);

    public async Task<List<tbl_mst_col_university>> GetByCategoryIdAsync(long id)
    {
        return await _db.tbl_mst_col_universities
            .Where(x => x.category_id == id)
            .OrderBy(x => x.university_name)
            .ToListAsync();
    }
    public Task<tbl_mst_col_university?> FindByIdAsync(long id) =>
        _db.tbl_mst_col_universities.FindAsync(id).AsTask();

    public async Task SaveAsync(tbl_mst_col_university university)
    {
        if (university.university_id == 0)
            _db.tbl_mst_col_universities.Add(university);
        else
            _db.tbl_mst_col_universities.Update(university);
        await _db.SaveChangesAsync();
    }
}

// ──────────────────────────────────────────────
//  College Repository
// ──────────────────────────────────────────────
public class CollegeRepository : ICollegeRepository
{
    private readonly AppDbContext _db;
    public CollegeRepository(AppDbContext db) => _db = db;

    public Task<bool> ExistsByNameExcludingIdAsync(string name, long excludeId) =>
        _db.tbl_mst_collages.AnyAsync(c =>
            c.cl_col_name!.ToLower() == name.ToLower() &&
            c.cl_col_id != excludeId);


    public Task<bool> ExistsByMarksheetAliasExcludingIdAsync(string alias, long excludeId) =>
        _db.tbl_mst_collages.AnyAsync(c =>
            c.marksheetalias == alias &&
            c.cl_col_id != excludeId);

    public Task<bool> ExistsBySchoolCodeExcludingIdAsync(string code, long excludeId) =>
        _db.tbl_mst_collages.AnyAsync(c =>
            c.schoolcode == code &&
            c.cl_col_id != excludeId);

    public Task<tbl_mst_collage?> FindByIdAsync(long id) =>
        _db.tbl_mst_collages.FindAsync(id).AsTask();

    public async Task<long> SaveAsync(tbl_mst_collage college)
    {
        if (college.cl_col_id == 0)
            _db.tbl_mst_collages.Add(college);
        else
            _db.tbl_mst_collages.Update(college);
        await _db.SaveChangesAsync();
        return college.cl_col_id;
    }

    public async Task<List<tbl_mst_collage>> GetByUniversityIdAsync(long universityId)
    {
        return await _db.tbl_mst_collages
            .Where(x => x.university_id == universityId)
            .OrderBy(x => x.cl_col_name)
            .ToListAsync();
    }
}

// ──────────────────────────────────────────────
//  Education Group Repository
// ──────────────────────────────────────────────
public class EducationGroupRepository : IEducationGroupRepository
{
    private readonly AppDbContext _db;
    public EducationGroupRepository(AppDbContext db) => _db = db;

    public Task<bool> ExistsByNameExcludingIdAsync(string name, long excludeId) =>
        _db.tbl_mst_col_groups.AnyAsync(g =>
            g.gr_name == name &&
            g.gr_id != excludeId);

    public Task<tbl_mst_col_group?> FindByIdAsync(long id) =>
        _db.tbl_mst_col_groups.FindAsync(id).AsTask();

    public async Task SaveAsync(tbl_mst_col_group group)
    {
        if (group.gr_id == 0)
            _db.tbl_mst_col_groups.Add(group);
        else
            _db.tbl_mst_col_groups.Update(group);
        await _db.SaveChangesAsync();
    }

     public Task<List<tbl_mst_col_group>> FindAll() =>
        _db.tbl_mst_col_groups.ToListAsync();
}

// ──────────────────────────────────────────────
//  Session Repository
// ──────────────────────────────────────────────
public class SessionRepository : ISessionRepository
{
    private readonly AppDbContext _db;
    public SessionRepository(AppDbContext db) => _db = db;

    public Task<bool> ExistsByNameAndCollegeExcludingIdAsync(
        string name, long colId, long excludeId) =>
        _db.session_masters.AnyAsync(s =>
            s.session_name!.ToLower() == name.ToLower() &&
            s.cl_col_id == colId &&
            s.session_id != excludeId);

    public Task<session_master?> FindByIdAsync(long id) =>
        _db.session_masters.FindAsync(id).AsTask();

    public async Task SaveAsync(session_master session)
    {
        if (session.session_id == 0)
            _db.session_masters.Add(session);
        else
            _db.session_masters.Update(session);
        await _db.SaveChangesAsync();
    }
    
    public async Task<List<session_master>> GetByCollegeIdAsync(long collegeId)
    {
        return await _db.session_masters
            .Where(x => x.cl_col_id == collegeId)
            .OrderByDescending(x => x.session_id)
            .ToListAsync();
    }

    public async Task DeleteAsync(session_master session)
    {
        _db.session_masters.Remove(session);
        await _db.SaveChangesAsync();
    }
}

// ──────────────────────────────────────────────
//  Configuration Repository
// ──────────────────────────────────────────────
public class ConfigurationRepository : IConfigurationRepository
{
    private readonly AppDbContext _db;
    public ConfigurationRepository(AppDbContext db) => _db = db;

    public async Task CreateDefaultConfigurationsAsync(long collegeId)
    {
        await CreateAcademicAsync(collegeId);
        await CreateAdmissionAsync(collegeId);
        await CreateExamAsync(collegeId);
        await CreateFeesAsync(collegeId);
        await CreateLibraryAsync(collegeId);
        await _db.SaveChangesAsync();
    }

    private async Task CreateAcademicAsync(long collegeId)
    {
        if (await _db.tbl_academic_configurations.AnyAsync(a => a.collegeid == collegeId)) return;
        _db.tbl_academic_configurations.Add(new()
        {
            collegeid = collegeId,
            short_attendence_letter_template_id = 1L, timetable_mail_template_id = 1L,
            teaching_plan_template_id = 1L, attendencesummary_template_id = 1L,
            leavealloweddays = 1, allowcampus = false, restrictroomallocation = false,
            issubjectgroup = false, campus_invitation_template_id = 1L,
            isremoveperiodheader = false, allowteachertoaddteachingplan = false,
            allowteachertoeditteachingplan = false, needapprovelfordailydairystaff = false,
            feedbackbyattendance = false, showstudentleavingoption = false,
            isenggteachingplan = false, isdepartmentwiselecture = false
        });
    }

    private async Task CreateAdmissionAsync(long collegeId)
    {
        if (await _db.tbl_admission_configurations.AnyAsync(a => a.collegeid == collegeId)) return;
        _db.tbl_admission_configurations.Add(new()
        {
            collegeid = collegeId,
            offer_letter_template_id = 1L, appointment_letter_template_id = 1L,
            profile_request_template_id = 1L, student_message_template_id = 1L,
            employee_message_template_id = 1L, preadmission_template_id = 1L,
            enquiry_template_id = 1L, studentchangephoto = false,
            percentage = "1", isteacherspecific = true,
            nameordering = 1, classrollnoordering = 1
        });
    }

    private async Task CreateExamAsync(long collegeId)
    {
        if (await _db.tbl_exam_configurations.AnyAsync(e => e.collegeid == collegeId)) return;
        _db.tbl_exam_configurations.Add(new()
        {
            collegeid = collegeId, marksheet_top_header = "", isshowgradvalue = false,
            inwardextension = "4", maxinwardextension = 5, outwardextension = "",
            maxoutwardextension = 5, revolution = 1, examlatefineafterdays = 5,
            examsuperlatefineafterdays = 4, examseatflag = 1
        });
    }

    private async Task CreateFeesAsync(long collegeId)
    {
        if (await _db.tbl_fees_configurations.AnyAsync(f => f.collegeid == collegeId)) return;
        _db.tbl_fees_configurations.Add(new()
        {
            collegeid = collegeId, fees_receipt_template_id = 1L, onlinefeespayment = true,
            performancereportformate = 1, latefeesapplicable = true, latefeesamountperday = 5,
            admissionfeeheadname = "", emailpassword = "", isrefund = false,
            isrefundfeesnotcallculated = true, isbusfeesnotcallculated = true,
            bouncecharges = 5, isheadwisefees = true,
            paymentgatewaychecksumkey = "", paymentgatewaymerchantidkey = "",
            paymentgatewaysecurityid = "", paymentgatewayreturnurl = "",
            isinstallmentpayment = true, is_late_fees_amount_per = true,
            latefeesfixamount = 10, isautoclearcheckdateapplybouncecharges = true
        });
    }

    private async Task CreateLibraryAsync(long collegeId)
    {
        if (await _db.tbl_library_configurations.AnyAsync(l => l.collegeid == collegeId)) return;
        _db.tbl_library_configurations.Add(new()
        {
            collegeid = collegeId, returndays = 5, returnempdays = 5,
            nobooks = 5, nobookemp = 5, maxfine = 10,
            libraryfine = 10, bookbanklibraryfine = 10, bookissuemailtemplateid = 1L
        });
    }
    
}

public class DegreeRepository : IDegreeRepository
{
    private readonly AppDbContext _db;
    public DegreeRepository(AppDbContext db) => _db = db;

    public Task<bool> ExistsByCategoryDescriptionAndCollegeExcludingIdAsync(
        string name, long colId, long excludeId) =>
        _db.degree_masters.AnyAsync(s =>
            s.category_description!.ToLower() == name.ToLower() &&
            s.cl_col_id == colId &&
            s.category_id != excludeId);

    public Task<degree_master?> FindByIdAsync(long? Id)
    {
        throw new NotImplementedException();
    }


    public async Task SaveAsync(degree_master degree)
    {
        if (degree.category_id == 0)
            _db.degree_masters.Add(degree);
        else
            _db.degree_masters.Update(degree);
        await _db.SaveChangesAsync();
    }

    public async Task<List<degree_master>> GetByCollegeIdAsync(long collegeId)
    {
        return await _db.degree_masters
            .Where(x => x.cl_col_id == collegeId)
            .OrderBy(x => x.category_description)
            .ToListAsync();
    }

     public async Task DeleteAsync(degree_master degree)
    {
        _db.degree_masters.Remove(degree);
        await _db.SaveChangesAsync();
    }

    Task IDegreeRepository.GetByCollegeIdAsync(long collegeId)
    {
        return GetByCollegeIdAsync(collegeId);
    }
}

public class BranchRepository : IBranchRepository
{
    private readonly AppDbContext _db;

    public BranchRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> ExistsAsync(
        string name,
        long categoryId,
        long excludeId)
    {
        return await _db.tbl_mst_col_branches.AnyAsync(x =>
            x.br_branch_name.ToLower() == name.ToLower()
            && x.category_id == categoryId
            && x.br_branch_id != excludeId);
    }

    public async Task<tbl_mst_col_branch?> GetByIdAsync(long id)
    {
        return await _db.tbl_mst_col_branches
            .FirstOrDefaultAsync(x => x.br_branch_id == id);
    }

    public async Task<List<tbl_mst_col_branch>> GetPagedAsync(
        int pageNumber,
        int pageSize,
        string? search)
    {
        var query = _db.tbl_mst_col_branches.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x =>
                x.br_branch_name.Contains(search));
        }

        return await query
            .OrderByDescending(x => x.br_branch_id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> GetTotalCountAsync(string? search)
    {
        var query = _db.tbl_mst_col_branches.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x =>
                x.br_branch_name.Contains(search));
        }

        return await query.CountAsync();
    }

    public async Task SaveAsync(tbl_mst_col_branch branch)
    {
        if (branch.br_branch_id == 0)
            await _db.tbl_mst_col_branches.AddAsync(branch);
        else
            _db.tbl_mst_col_branches.Update(branch);

        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(tbl_mst_col_branch branch)
    {
        _db.tbl_mst_col_branches.Remove(branch);

        await _db.SaveChangesAsync();
    }
}

public class SemesterRepository : ISemesterRepository
{
    private readonly AppDbContext _db;

    public SemesterRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> ExistsAsync(
        string semesterName,
        long collegeId,
        long excludeId)
    {
        return await _db.tbl_mst_semister_details
            .AnyAsync(x =>
                x.sm_sem_name.ToLower() == semesterName.ToLower()
                && x.cl_col_id == collegeId
                && x.sm_sem_id != excludeId);
    }

    public async Task<tbl_mst_semister_detail?> GetByIdAsync(long id)
    {
        return await _db.tbl_mst_semister_details
            .FirstOrDefaultAsync(x => x.sm_sem_id == id);
    }

    public async Task<List<tbl_mst_semister_detail>> GetPagedAsync(
        int pageNumber,
        int pageSize,
        string? search)
    {
        var query = _db.tbl_mst_semister_details.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x =>
                x.sm_sem_name.Contains(search));
        }

        return await query
            .OrderByDescending(x => x.sm_sem_id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> GetTotalCountAsync(string? search)
    {
        var query = _db.tbl_mst_semister_details.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(x =>
                x.sm_sem_name.Contains(search));
        }

        return await query.CountAsync();
    }

    public async Task SaveAsync(tbl_mst_semister_detail semester)
    {
        if (semester.sm_sem_id == 0)
            await _db.tbl_mst_semister_details.AddAsync(semester);
        else
            _db.tbl_mst_semister_details.Update(semester);

        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(tbl_mst_semister_detail semester)
    {
        _db.tbl_mst_semister_details.Remove(semester);

        await _db.SaveChangesAsync();
    }
}

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _db;

    public StudentRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> ExistsAsync(
        string mobileNo,
        string email,
        string fullName)
    {
        return await _db.student_details.AnyAsync(x =>
            x.stud_mobile == mobileNo ||
            x.email_id == email ||
            x.full_name == fullName);
    }

    public async Task<long> GetNextStudentIdAsync()
    {
        return (await _db.student_details
            .MaxAsync(x => (long?)x.student_id) ?? 0) + 1;
    }

    public async Task AddStudentAsync(student_detail student)
    {
        await _db.student_details.AddAsync(student);
    }

    public async Task AddUserProfileAsync(UserProfile profile)
    {
        await _db.userprofiles.AddAsync(profile);
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
     public async Task<string> GenerateRollNoAsync(long collegeId, long sessionId,long branchId, long semesterId)
    {
    var college = await _db.tbl_mst_collages
        .FirstOrDefaultAsync(x => x.cl_col_id == collegeId);

    var session = await _db.session_masters
        .FirstOrDefaultAsync(x => x.session_id == sessionId);

    var semester = await _db.tbl_mst_semister_details
        .FirstOrDefaultAsync(x => x.sm_sem_id == semesterId);

    var branch = await _db.tbl_mst_col_branches
        .FirstOrDefaultAsync(x => x.br_branch_id == branchId);

    if (semester == null)
    {
        semester = await _db.tbl_mst_semister_details
            .Where(x => x.br_branch_id == branchId)
            .OrderBy(x => x.years)
            .FirstOrDefaultAsync();
    }

    string yearName = semester?.years switch
    {
        369 => "1",
        370 => "2",
        371 => "3",
        418 => "4",
        _ => ""
    };

    int counter = 1;

    string branchName;

    // if (college.gr_id == 26)
    //     branchName = branch.TallyParentName;
    // else
        branchName = branch.br_branch_id.ToString();

    string prefix =
        $"{college.cl_col_id}" +
        $"{session.session_start_date.Value:yy}" +
        $"{((college.institution_id == 234 || college.institution_id == 75)
            ? branch.br_branch_id.ToString()
            : RegexConvert.ToAlphaOnly(branchName.Replace(" ", "").ToUpper()) + yearName)}";

    string rollNo = prefix + counter.ToString("D3");

    while (await _db.student_details.AnyAsync(x => x.roll_no == rollNo))
    {
        counter++;
        rollNo = prefix + counter.ToString("D3");
    }

    return rollNo;
}

     public async Task<student_detail?> GetByIdAsync(string rollNo)
    {
        return await _db.student_details
            .FirstOrDefaultAsync(x => x.roll_no == rollNo);
    }

    public async Task<long> GenerateStudentIdAsync()
    {
        return (await _db.student_details
            .MaxAsync(x => (long?)x.student_id) ?? 0) + 1;
    }


}