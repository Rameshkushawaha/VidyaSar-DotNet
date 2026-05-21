using VidyaSar.Application.DTOs;
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
    Task<tbl_mst_col_university?> FindByIdAsync(long id);
    Task SaveAsync(tbl_mst_col_university university);

    Task<List<tbl_mst_col_university>> GetByCategoryIdAsync(long id);
}

public interface ICollegeRepository
{
    Task<bool> ExistsByNameExcludingIdAsync(string name, long excludeId);
    Task<bool> ExistsByMarksheetAliasExcludingIdAsync(string alias, long excludeId);
    Task<bool> ExistsBySchoolCodeExcludingIdAsync(string code, long excludeId);
    Task<tbl_mst_collage?> FindByIdAsync(long id);
    Task<long> SaveAsync(tbl_mst_collage college);
}

public interface IEducationGroupRepository
{
    Task<bool> ExistsByNameExcludingIdAsync(string name, long excludeId);
    Task<tbl_mst_col_group?> FindByIdAsync(long id);
    Task SaveAsync(tbl_mst_col_group group);
    Task<List<tbl_mst_col_group>> FindAll();
}

public interface ISessionRepository
{
    Task<bool> ExistsByNameAndCollegeExcludingIdAsync(string name, long colId, long excludeId);
    Task<session_master?> FindByIdAsync(long id);
    Task SaveAsync(session_master session);
}

public interface IConfigurationRepository
{
    Task CreateDefaultConfigurationsAsync(long collegeId);
}

public interface IDegreeRepository
{
     Task<bool> ExistsByCategoryDescriptionAndCollegeExcludingIdAsync(string name, long colId, long excludeId);
    Task<degree_master?> FindByIdAsync(long? Id);
    Task SaveAsync(degree_master degree);
}

public interface IBranchRepository
{
    Task<bool> ExistsAsync(string name, long categoryId, long excludeId);

    Task<tbl_mst_col_branch?> GetByIdAsync(long id);

    Task<List<tbl_mst_col_branch>> GetPagedAsync(
        int pageNumber,
        int pageSize,
        string? search);

    Task<int> GetTotalCountAsync(string? search);

    Task SaveAsync(tbl_mst_col_branch branch);

    Task DeleteAsync(tbl_mst_col_branch branch);
}

public interface ISemesterRepository
{
    Task<bool> ExistsAsync(
        string semesterName,
        long collegeId,
        long excludeId);

    Task<tbl_mst_semister_detail?> GetByIdAsync(long id);

    Task<List<tbl_mst_semister_detail>> GetPagedAsync(
        int pageNumber,
        int pageSize,
        string? search);

    Task<int> GetTotalCountAsync(string? search);

    Task SaveAsync(tbl_mst_semister_detail semester);

    Task DeleteAsync(tbl_mst_semister_detail semester);
}