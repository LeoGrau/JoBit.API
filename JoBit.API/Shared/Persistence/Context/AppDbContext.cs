using JoBit.API.JoBit.Domain.Models;
using JoBit.API.Security.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JoBit.API.Shared.Persistence.Context;

public class AppDbContext : DbContext
{
    public DbSet<ApplicantProfile>? ApplicantProfiles { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<Applicant>? Applicants { get; set; }
    public DbSet<Recruiter>? Recruiters { get; set; }
    public DbSet<RecruiterProfile>? RecruiterProfiles { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        
        //Users
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<User>().HasKey(user => user.UserId);
        modelBuilder.Entity<User>().Property(user => user.UserId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<User>().Property(user => user.Firstname);
        modelBuilder.Entity<User>().Property(user => user.Lastname);
        modelBuilder.Entity<User>().Property(user => user.Username);
        modelBuilder.Entity<User>().Property(user => user.Email);
        modelBuilder.Entity<User>().Property(user => user.UserType);
        modelBuilder.Entity<User>().Property(user => user.Password);
        modelBuilder.Entity<User>()
            .HasOne(user => user.Applicant)
            .WithOne(applicant => applicant.User)
            .HasForeignKey<Applicant>(applicant => applicant.UserId)
            .IsRequired(false);
        modelBuilder.Entity<User>()
            .HasOne(user => user.Recruiter)
            .WithOne(recruiter => recruiter.User)
            .HasForeignKey<Recruiter>(recruiter => recruiter.UserId)
            .IsRequired(false);

        //Applicants
        modelBuilder.Entity<Applicant>().ToTable("Applicants");
        modelBuilder.Entity<Applicant>().HasKey(applicant => applicant.ApplicantId);
        modelBuilder.Entity<Applicant>().Property(applicant => applicant.ApplicantId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Applicant>().Property(applicant => applicant.Firstname);
        modelBuilder.Entity<Applicant>().Property(applicant => applicant.Lastname);
        modelBuilder.Entity<Applicant>().Property(applicant => applicant.UserId);
        modelBuilder.Entity<Applicant>()
            .HasOne(applicant => applicant.ApplicantProfile)
            .WithOne(profile => profile.Applicant)
            .HasForeignKey<ApplicantProfile>(profile => profile.ApplicantId);

        //ApplicantProfile
        modelBuilder.Entity<ApplicantProfile>().ToTable("ApplicantProfiles");
        modelBuilder.Entity<ApplicantProfile>().HasKey(profile => profile.ApplicantId);
        modelBuilder.Entity<ApplicantProfile>().Property(profile => profile.ApplicantId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<ApplicantProfile>().Property(profile => profile.Firstname);
        modelBuilder.Entity<ApplicantProfile>().Property(profile => profile.Lastname);
        modelBuilder.Entity<ApplicantProfile>().Property(profile => profile.PhotoUrl);
        modelBuilder.Entity<ApplicantProfile>().Property(profile => profile.Description);
    }
}