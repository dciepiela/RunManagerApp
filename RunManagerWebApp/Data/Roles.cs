using Microsoft.AspNetCore.Identity;
using RunManagerWebApp.Data.Enum;
using RunManagerWebApp.Models;

namespace RunManagerWebApp.Data
{
    public class Roles
    {
        public static async Task CreateRoles(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //ROLE
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                ////Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "mimiak00@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "dciepielaADMIN",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            City = "Orońsko",
                            Street = "Wierzbicka 50",
                            PostalCode = "26-505"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "zaq1@WSX");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                //string appUserEmail = "user@gmail.com";

                //var appUser = await userManager.FindByEmailAsync(appUserEmail);
                //if (appUser == null)
                //{
                //    var newAppUser = new AppUser()
                //    {
                //        UserName = "app-user",
                //        Email = appUserEmail,
                //        EmailConfirmed = true,
                //        Address = new Address()
                //        {
                //            City = "Radom",
                //            Street = "Starowiejska 10",
                //            PostalCode = "26-600"
                //        }
                //    };
                //    await userManager.CreateAsync(newAppUser, "zaq1@WSX");
                //    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                //}
            }
        }
    }
}
