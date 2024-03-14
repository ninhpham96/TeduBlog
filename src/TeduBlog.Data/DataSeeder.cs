using Microsoft.AspNetCore.Identity;
using TeduBlog.Core.Domain.Identity;

namespace TeduBlog.Data;

public class DataSeeder
{
    public async Task SeedAsync(TeduBlogContext context)
    {
        var passwordHasher = new PasswordHasher<AppUser>();
        var rootAdminRoleId = Guid.NewGuid();
        if (!context.Roles.Any())
        {
            await context.Roles.AddAsync(
                new AppRole()
                {
                    Id = rootAdminRoleId,
                    Name = "ADMIN",
                    NormalizedName = "ADMIN",
                    DisplayName = "Quan tri vien",
                });
            await context.SaveChangesAsync();
        }
        if (!context.Users.Any())
        {
            var userId = Guid.NewGuid();
            var user = new AppUser()
            {
                Id = userId,
                FirstName = "Pham",
                LastName = "Ninh",
                Email = "Phamninh704@gmail.com",
                NormalizedEmail = "PHAMNINH704@GMAIL.COM",
                UserName = "ADMIN",
                IsActive = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = false,
                DateCreated = DateTime.Now
            };
            user.PasswordHash = passwordHasher.HashPassword(user, "@123456@");
            await context.UserRoles.AddAsync(new IdentityUserRole<Guid>()
            {
                RoleId = rootAdminRoleId,
                UserId = userId,
            });
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
    }
}
