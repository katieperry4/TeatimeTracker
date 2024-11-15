using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeaCapstone.Models;

namespace TeaCapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TeaLog> TeaLog { get; set; }
        public virtual DbSet<TeaType> TeaType { get; set; }
        public virtual DbSet<TeaVariety> TeaVariety { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TeaType>()
                .HasMany(e => e.TeaVarieties)
                .WithOne(e => e.TeaType)
                .HasForeignKey(e => e.TeaTypeId);

            builder.Entity<TeaLog>()
                .HasOne(t => t.TeaVariety)
                .WithMany()
                .HasForeignKey(t => t.TeaVarietyId);

            builder.Entity<TeaLog>()
                .HasOne(t => t.IdentityUser)
                .WithMany()
                .HasForeignKey(t => t.UserId);
        }

        
    }
}
