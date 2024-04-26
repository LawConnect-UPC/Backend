using Lawyeed.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Lawyeed.API.Lawyeed.Domain.Models;

namespace Lawyeed.API.Lawyeed.Persistence.Contexts;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Person> Persons { get; set; }
    public DbSet<PersonLawyer> Lawyers { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //Person
        builder.Entity<Person>().ToTable("Persons");
        
        
        //Relations
        builder.Entity<Person>().HasDiscriminator(p => p.Type)
            .HasValue<Person>("client")
            .HasValue<PersonLawyer>("lawyer");
        
        //Person
        builder.Entity<Person>().HasKey(p => p.Id);
        builder.Entity<Person>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Person>().Property(p => p.FisrtName).IsRequired().HasMaxLength(40);
        builder.Entity<Person>().Property(p => p.LastName).IsRequired().HasMaxLength(40);
        builder.Entity<Person>().Property(p => p.Email).IsRequired().HasMaxLength(50);
        builder.Entity<Person>().Property(p => p.Password).IsRequired().HasMaxLength(40);
        builder.Entity<Person>().Property(p => p.Description).IsRequired().HasMaxLength(200);
        builder.Entity<Person>().Property(p => p.UrlImage).IsRequired().HasMaxLength(100);
        builder.Entity<Person>().Property(p => p.Type).IsRequired().HasMaxLength(20);
        
        //Person Lawyer
        builder.Entity<PersonLawyer>().Property(l => l.Specialty).HasMaxLength(30);
        builder.Entity<PersonLawyer>().Property(l => l.WonCases);
        builder.Entity<PersonLawyer>().Property(l => l.TotalCases);
        builder.Entity<PersonLawyer>().Property(l => l.LostCases);

        //Apply Naming Conventions
        builder.UseSnakeCaseNamingConvention();
    }
}