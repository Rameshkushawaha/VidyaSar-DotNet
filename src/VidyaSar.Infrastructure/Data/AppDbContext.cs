using Microsoft.EntityFrameworkCore;
using VidyaSar.Domain.Entities;

namespace VidyaSar.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<UserProfile>           UserProfiles            { get; set; }
    public DbSet<University>            Universities            { get; set; }
    public DbSet<College>               Colleges                { get; set; }
    public DbSet<EducationGroup>        EducationGroups         { get; set; }
    public DbSet<SessionMaster>         Sessions                { get; set; }
    public DbSet<AcademicConfiguration>  AcademicConfigurations  { get; set; }
    public DbSet<AdmissionConfiguration> AdmissionConfigurations { get; set; }
    public DbSet<ExamConfiguration>     ExamConfigurations      { get; set; }
    public DbSet<FeesConfiguration>     FeesConfigurations      { get; set; }
    public DbSet<LibraryConfiguration>  LibraryConfigurations   { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");
        base.OnModelCreating(modelBuilder);

        // Ensure string PK for UserProfile
        modelBuilder.Entity<UserProfile>()
            .HasKey(u => u.Userid);

        // Lowercase table/column conventions (PostgreSQL friendly)
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName()?.ToLower());
            foreach (var prop in entity.GetProperties())
                prop.SetColumnName(prop.GetColumnName().ToLower());
        }
    }
}
