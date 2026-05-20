using VidyaSar.Domain.Entities;

namespace VidyaSar.Application.Interfaces;

public interface IUserRepository
{
    Task<UserProfile?> FindByUseridAsync(string userid);
    Task<UserProfile?> FindByIdAsync(string userid);
    Task SaveAsync(UserProfile user);
}

public interface IUniversityRepository
{
    Task<bool> ExistsByNameExcludingIdAsync(string name, long excludeId);
    Task<University?> FindByIdAsync(long id);
    Task SaveAsync(University university);
}

public interface ICollegeRepository
{
    Task<bool> ExistsByNameExcludingIdAsync(string name, long excludeId);
    Task<bool> ExistsByMarksheetAliasExcludingIdAsync(string alias, long excludeId);
    Task<bool> ExistsBySchoolCodeExcludingIdAsync(string code, long excludeId);
    Task<College?> FindByIdAsync(long id);
    Task<long> SaveAsync(College college);
}

public interface IEducationGroupRepository
{
    Task<bool> ExistsByNameExcludingIdAsync(string name, long excludeId);
    Task<EducationGroup?> FindByIdAsync(long id);
    Task SaveAsync(EducationGroup group);
}

public interface ISessionRepository
{
    Task<bool> ExistsByNameAndCollegeExcludingIdAsync(string name, long colId, long excludeId);
    Task<SessionMaster?> FindByIdAsync(long id);
    Task SaveAsync(SessionMaster session);
}

public interface IConfigurationRepository
{
    Task CreateDefaultConfigurationsAsync(long collegeId);
}
