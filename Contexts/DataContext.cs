using cms_submission.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Persistence.EFCore;
using System.Configuration;

namespace cms_submission.Contexts;

public class DataContext : DbContext
{

    protected readonly IConfiguration Configuration;
    public DataContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    public required DbSet<ContactEntity> ContactRequests { get; set; }
    public required DbSet<NewsLetterEntity> NewsLetterRequests { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<ContactEntity>(entity =>
        {
            entity.ToTable("ContactRequests");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContactUmbracoKey).HasColumnName("contactUmbracoKey");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.Email).HasColumnName("email");
        });
        modelBuilder.Entity<NewsLetterEntity>(entity =>
          {
              entity.ToTable("NewsLetterRequests");
              entity.HasKey(e => e.Id);
              entity.Property(e => e.Email).HasColumnName("Email");
          });


        }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to the sqlite database
        options.UseSqlite(Configuration.GetConnectionString("UmbracoDatabase"));
    }
}
