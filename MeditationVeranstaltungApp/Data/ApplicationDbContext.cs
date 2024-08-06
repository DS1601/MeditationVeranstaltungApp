using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeditationVeranstaltungApp.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Kontakt> Kontakts { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                 new IdentityRole
                 {
                     Name = "User",
                     NormalizedName = "USER",
                     Id = "a609455d-5f11-42bd-be9d-5fd66e4570c0"
                 },
                 new IdentityRole
                 {
                     Name = "Driver",
                     NormalizedName = "DRIVER",
                     Id = "b2b71169-bcf7-41c6-90c5-3f808fd7cafa"
                 },
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Id = "28aaaaad-012d-4951-b501-5813b2a541ff"
                }
            );

            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "ec673be3-bdfe-4ee6-9ff1-3712a38acb5e",
                    Email = "admin@web.de",
                    NormalizedEmail = "ADMIN@WEB.DE",
                    UserName = "admin@web.de",
                    NormalizedUserName = "ADMIN@WEB.DE",
                    PasswordHash = hasher.HashPassword(null, "Waheguru@1"),
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "28aaaaad-012d-4951-b501-5813b2a541ff",
                    UserId = "ec673be3-bdfe-4ee6-9ff1-3712a38acb5e"
                }
            );


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
