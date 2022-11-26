using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using onlineShop.Models;

namespace onlineShop.Controllers;

public class DashboardController :  BaseController
{
        private readonly RoleManager<IdentityRole> manager;

        public DashboardController(RoleManager<IdentityRole> manager)
        {
            this.manager = manager;
        }

        public IActionResult CreateRole()
        {
             return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(UserRole role)
        {
            var roleExist = await manager.RoleExistsAsync(role.Rolename);
            if (!roleExist)
            {
                await manager.CreateAsync(new IdentityRole(role.Rolename));
            }
            return RedirectToAction();
        }
}
