using Microsoft.EntityFrameworkCore;
using VidyaSar.Application.Interfaces;
using VidyaSar.Domain.Entities;
using VidyaSar.Infrastructure.Data;

namespace VidyaSar.Infrastructure.Repositories;

// ──────────────────────────────────────────────
//  User Repository
// ──────────────────────────────────────────────
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;
    public UserRepository(AppDbContext db) => _db = db;

    public Task<UserProfile?> FindByUseridAsync(string userid) =>
        _db.UserProfiles.FirstOrDefaultAsync(u => u.Userid == userid);

    public Task<UserProfile?> FindByIdAsync(string userid) =>
        _db.UserProfiles.FindAsync(userid).AsTask();

    public async Task SaveAsync(UserProfile user)
    {
        if (_db.Entry(user).State == EntityState.Detached)
            _db.UserProfiles.Add(user);
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
        _db.Universities.AnyAsync(u =>
            u.UniversityName!.ToLower() == name.ToLower() &&
            u.UniversityId != excludeId);

    public Task<University?> FindByIdAsync(long id) =>
        _db.Universities.FindAsync(id).AsTask();

    public async Task SaveAsync(University university)
    {
        if (university.UniversityId == 0)
            _db.Universities.Add(university);
        else
            _db.Universities.Update(university);
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
        _db.Colleges.AnyAsync(c =>
            c.ClColName!.ToLower() == name.ToLower() &&
            c.ClColId != excludeId);

    public Task<bool> ExistsByMarksheetAliasExcludingIdAsync(string alias, long excludeId) =>
        _db.Colleges.AnyAsync(c =>
            c.MarksheetAlias == alias &&
            c.ClColId != excludeId);

    public Task<bool> ExistsBySchoolCodeExcludingIdAsync(string code, long excludeId) =>
        _db.Colleges.AnyAsync(c =>
            c.SchoolCode == code &&
            c.ClColId != excludeId);

    public Task<College?> FindByIdAsync(long id) =>
        _db.Colleges.FindAsync(id).AsTask();

    public async Task<long> SaveAsync(College college)
    {
        if (college.ClColId == 0)
            _db.Colleges.Add(college);
        else
            _db.Colleges.Update(college);
        await _db.SaveChangesAsync();
        return college.ClColId;
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
        _db.EducationGroups.AnyAsync(g =>
            g.GrName == name &&
            g.GrId != excludeId);

    public Task<EducationGroup?> FindByIdAsync(long id) =>
        _db.EducationGroups.FindAsync(id).AsTask();

    public async Task SaveAsync(EducationGroup group)
    {
        if (group.GrId == 0)
            _db.EducationGroups.Add(group);
        else
            _db.EducationGroups.Update(group);
        await _db.SaveChangesAsync();
    }
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
        _db.Sessions.AnyAsync(s =>
            s.SessionName!.ToLower() == name.ToLower() &&
            s.ClColId == colId &&
            s.SessionId != excludeId);

    public Task<SessionMaster?> FindByIdAsync(long id) =>
        _db.Sessions.FindAsync(id).AsTask();

    public async Task SaveAsync(SessionMaster session)
    {
        if (session.SessionId == 0)
            _db.Sessions.Add(session);
        else
            _db.Sessions.Update(session);
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
        if (await _db.AcademicConfigurations.AnyAsync(a => a.CollegeId == collegeId)) return;
        _db.AcademicConfigurations.Add(new()
        {
            CollegeId = collegeId,
            ShortAttendenceLetterTemplateId = 1L, TimetableMailTemplateId = 1L,
            TeachingPlanTemplateId = 1L, AttendencesummaryTemplateId = 1L,
            LeaveAllowedDays = 1, AllowCampus = false, RestrictRoomAllocation = false,
            IsSubjectGroup = false, CampusInvitationTemplateId = 1L,
            IsRemovePeriodHeader = false, AllowTeacherToAddTeachingPlan = false,
            AllowTeacherToEditTeachingPlan = false, NeedApprovelforDailyDairyStaff = false,
            FeedbackByAttendance = false, ShowStudentLeavingOption = false,
            IsEnggTeachingPlan = false, IsDepartmentWiseLecture = false
        });
    }

    private async Task CreateAdmissionAsync(long collegeId)
    {
        if (await _db.AdmissionConfigurations.AnyAsync(a => a.Collegeid == collegeId)) return;
        _db.AdmissionConfigurations.Add(new()
        {
            Collegeid = collegeId,
            OfferLetterTemplateId = 1L, AppointmentLetterTemplateId = 1L,
            ProfileRequestTemplateId = 1L, StudentMessageTemplateId = 1L,
            EmployeeMessageTemplateId = 1L, PreadmissionTemplateId = 1L,
            EnquiryTemplateId = 1L, StudentChangePhoto = false,
            Percentage = "1", IsTeacherSpecific = true,
            NameOrdering = 1, ClassRollnoOrdering = 1
        });
    }

    private async Task CreateExamAsync(long collegeId)
    {
        if (await _db.ExamConfigurations.AnyAsync(e => e.CollegeId == collegeId)) return;
        _db.ExamConfigurations.Add(new()
        {
            CollegeId = collegeId, MarksheetTopHeader = "", IsShowGradValue = false,
            InwardExtension = "4", MaxInwardExtension = 5, OutwardExtension = "",
            MaxOutwardExtension = 5, Revolution = 1, ExamLatefineAfterdays = 5,
            ExamSuperLatefineAfterdays = 4, ExamSeatFlag = 1
        });
    }

    private async Task CreateFeesAsync(long collegeId)
    {
        if (await _db.FeesConfigurations.AnyAsync(f => f.CollegeId == collegeId)) return;
        _db.FeesConfigurations.Add(new()
        {
            CollegeId = collegeId, FeesReceiptTemplateId = 1L, OnlineFeesPayment = true,
            PerformanceReportFormate = 1, LateFeesApplicable = true, LateFeesAmountPerday = 5,
            AdmissionFeeHeadName = "", EmailPassword = "", IsRefund = false,
            IsRefundFeesNotCallculated = true, IsBusFeesNotCallculated = true,
            BounceCharges = 5, IsHeadWiseFees = true,
            PaymentGatewayChecksumKey = "", PaymentGatewayMerchantIDKey = "",
            PaymentGatewaySecurityID = "", PaymentGatewayReturnUrl = "",
            IsInstallmentPayment = true, IsLateFeesAmountPer = true,
            LateFeesFixAmount = 10, IsAutoClearcheckDateApplyBounceCharges = true
        });
    }

    private async Task CreateLibraryAsync(long collegeId)
    {
        if (await _db.LibraryConfigurations.AnyAsync(l => l.CollegeId == collegeId)) return;
        _db.LibraryConfigurations.Add(new()
        {
            CollegeId = collegeId, ReturnDays = 5, ReturnEmpDays = 5,
            NoBooks = 5, NoBookEmp = 5, MaxFine = 10,
            LibraryFine = 10, BookBankLibraryFine = 10, BookIssueMailTemplateId = 1L
        });
    }
}
