using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Models.Intermediate;
using JoBit.API.Security.Domain.Models;
using JoBit.API.Security.Domain.Models.Intermediate;
using JoBit.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace JoBit.API.Shared.Persistence.Context;

public class AppDbContext : DbContext
{
    public DbSet<ApplicantProfile>? ApplicantProfiles { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<Applicant>? Applicants { get; set; }
    public DbSet<Recruiter>? Recruiters { get; set; }
    public DbSet<RecruiterProfile>? RecruiterProfiles { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<TechSkill> TechSkills { get; set; }
    public DbSet<ApplicantTechSkill> ApplicantTechSkills { get; set; }
    public DbSet<PostJob> PostJobs { get; set; }
    public DbSet<PostJobRecruiter> PostJobRecruiters { get; set; }
    public DbSet<PostJobApplicant> PostJobApplicants { get; set; }
    public DbSet<Institution> EducationalInstitutions { get; set; }

    public DbSet<CompanyProfile> CompanyProfiles { get; set; }
    public DbSet<Career> Careers { get; set; }
    public DbSet<CareerInstitution> CareerInstitutions { get; set; }

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
            .HasForeignKey<Recruiter>(recruiter => recruiter.UserId);

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
        modelBuilder.Entity<ApplicantProfile>()
            .HasMany(profile => profile.ApplicantTechSkills)
            .WithOne(applicantTechSkill => applicantTechSkill.ApplicantProfile)
            .HasForeignKey(applicantTechSkill => applicantTechSkill.ApplicantId);
        modelBuilder.Entity<ApplicantProfile>()
            .HasMany(applicant => applicant.CareerInstitutions)
            .WithOne(institution => institution.ApplicantProfile)
            .HasForeignKey(institution => institution.ApplicantId);
        
        
        //Recruiter
        modelBuilder.Entity<Recruiter>().ToTable("Recruiters");
        modelBuilder.Entity<Recruiter>().HasKey(recruiter => recruiter.RecruiterId);
        modelBuilder.Entity<Recruiter>().Property(recruiter => recruiter.RecruiterId).IsRequired();
        modelBuilder.Entity<Recruiter>().Property(recruiter => recruiter.Firstname);
        modelBuilder.Entity<Recruiter>().Property(recruiter => recruiter.Lastname);
        modelBuilder.Entity<Recruiter>().Property(recruiter => recruiter.UserId);
        modelBuilder.Entity<Recruiter>()
            .HasOne(recruiter => recruiter.RecruiterProfile)
            .WithOne(profile => profile.Recruiter)
            .HasForeignKey<RecruiterProfile>(profile => profile.RecruiterId);
        modelBuilder.Entity<Recruiter>()
            .HasMany(recruiter => recruiter.PostJobRecruiters)
            .WithOne(postJobRecruiter => postJobRecruiter.Recruiter)
            .HasForeignKey(postJobRecruiter => postJobRecruiter.RecruiterId);
        
        //PostJobRecruiters
        modelBuilder.Entity<PostJobRecruiter>().ToTable("PostJobRecruiters");
        modelBuilder.Entity<PostJobRecruiter>().HasKey(postJobRecruiter => new { postJobRecruiter.RecruiterId, postJobRecruiter.PostId });
        modelBuilder.Entity<PostJobRecruiter>().Property(postJobRecruiter => postJobRecruiter.RecruiterId);
        modelBuilder.Entity<PostJobRecruiter>().Property(postJobRecruiter => postJobRecruiter.PostId);
        modelBuilder.Entity<PostJobRecruiter>().Property(postJobRecruiter => postJobRecruiter.MainPublisher);
        
        //PostJobApplicants
        modelBuilder.Entity<PostJobApplicant>().ToTable("PostJobApplicants");
        modelBuilder.Entity<PostJobApplicant>().HasKey(postJobApplicant => new { postJobApplicant.ApplicantId, postJobApplicant.PostId });
        modelBuilder.Entity<PostJobApplicant>().Property(postJobApplicant => postJobApplicant.ApplicantId);
        modelBuilder.Entity<PostJobApplicant>().Property(postJobApplicant => postJobApplicant.PostId);
        
        
        //RecruiterProfile
        modelBuilder.Entity<RecruiterProfile>().ToTable("RecruiterProfiles");
        modelBuilder.Entity<RecruiterProfile>().HasKey(profile => profile.RecruiterId);
        modelBuilder.Entity<RecruiterProfile>().Property(profile => profile.RecruiterId).IsRequired();
        modelBuilder.Entity<RecruiterProfile>().Property(profile => profile.Firstname);
        modelBuilder.Entity<RecruiterProfile>().Property(profile => profile.Lastname);
        modelBuilder.Entity<RecruiterProfile>().Property(profile => profile.PhotoUrl);
        modelBuilder.Entity<RecruiterProfile>().Property(profile => profile.Description);
        
        //Companies
        modelBuilder.Entity<Company>().ToTable("Companies");
        modelBuilder.Entity<Company>().HasKey(company => company.CompanyId);
        modelBuilder.Entity<Company>().Property(company => company.CompanyId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Company>().Property(company => company.CompanyName);
        modelBuilder.Entity<Company>()
            .HasMany(company => company.Recruiters)
            .WithOne(recruiter => recruiter.Company)
            .HasForeignKey(recruiter => recruiter.CompanyId);
        modelBuilder.Entity<Company>()
            .HasMany(company => company.PostJobs)
            .WithOne(postJob => postJob.Company)
            .HasForeignKey(postJob => postJob.CompanyId);
        modelBuilder.Entity<Company>()
            .HasOne(company => company.CompanyProfile)
            .WithOne(companyProfile => companyProfile.Company)
            .HasForeignKey<CompanyProfile>(companyProfile => companyProfile.CompanyId);


        //Company Profiles
        modelBuilder.Entity<CompanyProfile>().ToTable("Companies");
        modelBuilder.Entity<CompanyProfile>().HasKey(companyProfile => companyProfile.CompanyId);
        modelBuilder.Entity<CompanyProfile>().Property(companyProfile => companyProfile.CompanyId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<CompanyProfile>().Property(companyProfile => companyProfile.CompanyName);


        //TechSkills
        modelBuilder.Entity<TechSkill>().ToTable("TechSkills");
        modelBuilder.Entity<TechSkill>().HasKey(techSkill => techSkill.TechSkillId);
        modelBuilder.Entity<TechSkill>().Property(techSkill => techSkill.TechSkillId).IsRequired()
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<TechSkill>().Property(techSkill => techSkill.TechName);
        modelBuilder.Entity<TechSkill>().Property(techSkill => techSkill.PhotoUrl);
        modelBuilder.Entity<TechSkill>()
            .HasMany(techSkill => techSkill.ApplicantTechSkills)
            .WithOne(applicantTechSkill => applicantTechSkill.TechSkill)
            .HasForeignKey(applicantTechSkill => applicantTechSkill.TechSkillId);
        
        //ApplicantTechSkills
        modelBuilder.Entity<ApplicantTechSkill>().ToTable("ApplicantTechSkills");
        modelBuilder.Entity<ApplicantTechSkill>().HasKey(applicantTechSkill => applicantTechSkill.ApplicantTechSkillId);
        modelBuilder.Entity<ApplicantTechSkill>()
            .Property(applicantTechSkill => applicantTechSkill.ApplicantTechSkillId).IsRequired();
        modelBuilder.Entity<ApplicantTechSkill>()
            .Property(applicantTechSkill => applicantTechSkill.ApplicantId).IsRequired();
        modelBuilder.Entity<ApplicantTechSkill>()
            .Property(applicantTechSkill => applicantTechSkill.TechSkillId).IsRequired();
        modelBuilder.Entity<ApplicantTechSkill>()
            .Property(applicantTechSkill => applicantTechSkill.ApplicantId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<ApplicantTechSkill>().Property(applicantTechSkill => applicantTechSkill.StartDate);
        
        //PostJobs
        modelBuilder.Entity<PostJob>().ToTable("PostJobs");
        modelBuilder.Entity<PostJob>().HasKey(postJob => postJob.PostId);
        modelBuilder.Entity<PostJob>().Property(postJob => postJob.PostId).ValueGeneratedOnAdd().IsRequired();
        modelBuilder.Entity<PostJob>().Property(postJob => postJob.Title);
        modelBuilder.Entity<PostJob>().Property(postJob => postJob.Description);
        modelBuilder.Entity<PostJob>().Property(postJob => postJob.CompanyId);
        modelBuilder.Entity<PostJob>().Property(postJob => postJob.JobModality);
        modelBuilder.Entity<PostJob>().Property(postJob => postJob.TimeModality);
        modelBuilder.Entity<PostJob>().Property(postJob => postJob.JobName);
        modelBuilder.Entity<PostJob>().Property(postJob => postJob.Place);
        modelBuilder.Entity<PostJob>().Property(postJob => postJob.Salary);
        modelBuilder.Entity<PostJob>()
            .HasMany(postJob => postJob.PostJobRecruiters)
            .WithOne(postJobRecruiter => postJobRecruiter.PostJob)
            .HasForeignKey(postJobRecruiter => postJobRecruiter.PostId);
        modelBuilder.Entity<PostJob>()
            .HasOne(postJob => postJob.RecruiterPublisher)
            .WithMany(recruiter => recruiter.PostJobs)
            .HasForeignKey(postJob => postJob.RecruiterPublisherId);

        //CompanyProfiles
        modelBuilder.Entity<CompanyProfile>().ToTable("CompanyProfiles");
        modelBuilder.Entity<CompanyProfile>().HasKey(companyProfile => companyProfile.CompanyId);
        modelBuilder.Entity<CompanyProfile>().Property(companyProfile => companyProfile.CompanyId);
        modelBuilder.Entity<CompanyProfile>().Property(companyProfile => companyProfile.CompanyName);
        modelBuilder.Entity<CompanyProfile>().Property(companyProfile => companyProfile.BusinessSector);
        modelBuilder.Entity<CompanyProfile>().Property(companyProfile => companyProfile.PhotoUrl);
        modelBuilder.UseSnakeCase();
        
        //Careers
        modelBuilder.Entity<Career>().ToTable("Careers");
        modelBuilder.Entity<Career>().HasKey(career =>  career.CareerId);
        modelBuilder.Entity<Career>().Property(career =>  career.CareerId).ValueGeneratedOnAdd().IsRequired();
        modelBuilder.Entity<Career>().Property(career =>  career.CareerName);
        modelBuilder.Entity<Career>()
            .HasMany(institution => institution.CareerInstitutions)
            .WithOne(institution => institution.Career)
            .HasForeignKey(institution => institution.CareerId);
        
        //Institutions
        modelBuilder.Entity<Institution>().ToTable("Institutions");
        modelBuilder.Entity<Institution>().HasKey(institution => institution.InstitutionId);
        modelBuilder.Entity<Institution>().Property(institution =>  institution.InstitutionId).ValueGeneratedOnAdd().IsRequired();
        modelBuilder.Entity<Institution>().Property(institution =>  institution.InstitutionName);
        modelBuilder.Entity<Institution>().Property(institution =>  institution.PhotoUrl);
        modelBuilder.Entity<Institution>()
            .HasMany(institution => institution.CareerInstitutions)
            .WithOne(institution => institution.Institution)
            .HasForeignKey(institution => institution.InstitutionId);
        
        //CareerInstitutions
        modelBuilder.Entity<CareerInstitution>().ToTable("CareerInstitutions");
        modelBuilder.Entity<CareerInstitution>().HasKey(institution => institution.CareerInstitutionId);
        modelBuilder.Entity<CareerInstitution>().Property(institution => institution.CareerInstitutionId).ValueGeneratedOnAdd().IsRequired();
        modelBuilder.Entity<CareerInstitution>().Property(institution =>  institution.CareerId);
        modelBuilder.Entity<CareerInstitution>().Property(institution =>  institution.InstitutionId);
        modelBuilder.Entity<CareerInstitution>().Property(institution => institution.ApplicantId);
        
        modelBuilder.UseSnakeCase();
    }
}