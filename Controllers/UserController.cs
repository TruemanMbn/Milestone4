using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using onlineShop.Models;
using onlineShop.Repository;

namespace onlineShop.Controllers;

public class UserController :  BaseController
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly ICustomer<Customer> repo;

    public UserController(UserManager<IdentityUser> userManager,ICustomer<Customer> repo)
    {
         this.userManager = userManager;
        this.repo = repo;
    }
    public IActionResult Profile()
    {
        return View(new Customer());
    }
    [HttpPost]
    public IActionResult Profile(Customer customer){
        if(customer == null){
            return BadRequest();
        }
        repo.addCustomer(customer,userManager.GetUserId(HttpContext.User));
        notify("Account Registration successful!");
        return RedirectToAction("Index","Home");
    }
}
