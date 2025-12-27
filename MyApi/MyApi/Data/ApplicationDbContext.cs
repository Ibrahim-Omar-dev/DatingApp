using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore;
using MyApi.Entities;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AppUser>()
            .HasOne(u => u.Member)
            .WithOne(m => m.AppUser)
            .HasForeignKey<Member>(m => m.AppUserId);

        modelBuilder.Entity<Member>()
            .HasMany(m => m.photos)
            .WithOne(p => p.Member)
            .HasForeignKey(p => p.MemberId);
    }


    public DbSet<AppUser> Users { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Photo> Photos { get; set; }

}
