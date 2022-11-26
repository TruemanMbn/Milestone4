using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using onlineShop.Models;
using onlineShop.Repository;
using onlineShop.ViewModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace onlineShop.Controllers
{
    public class HomeController :  BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private GroupWst8Context db;
        private readonly IWebHostEnvironment hostEnvironment;
        private IProductCategory<ProductCategory> repo;

        public HomeController(ILogger<HomeController> logger, GroupWst8Context context,IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            db = context;
            this.hostEnvironment = hostEnvironment;
            repo  = new CategoryRepository(hostEnvironment,db);
        }

        public IActionResult Index(int? page)
        {
            return View(repo.findAll());
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
