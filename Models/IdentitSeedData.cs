using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DluzynaSzkola2.Models
{
    public class IdentitSeedData
    {
        private const string adminUser = "Przemek";
        private const string adminPassword = "!1Pandemonium!1";
        public static async Task EnsurePopulated(UserManager<IdentityUser> userManager)
        {
            IdentityUser user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new IdentityUser("Przemek");
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
