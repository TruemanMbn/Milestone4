using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using onlineShop.Extensions;
using onlineShop.Models;
using onlineShop.Repository;
using onlineShop.ViewModel;

namespace onlineShop.Controllers
{
	public class StoreController :  BaseController
	{
		private const string cartKey ="CartItem";
		private const string counterKey ="CartCounter";
        private const string totalItems ="Items";
		private readonly ILogger<HomeController> _logger;
        private GroupWst8Context db;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IRecommendation recommender;
        private IProduct<Product> repo;
		private List<CartViewModel> listOfShoppingCartModels;
		public StoreController(ILogger<HomeController> logger, GroupWst8Context context,IWebHostEnvironment hostEnvironment,IRecommendation recommender)
		{
			_logger = logger;
            db = context;
            this.hostEnvironment = hostEnvironment;
            this.recommender = recommender;
            repo  = new ProductRepository(db,hostEnvironment);
			listOfShoppingCartModels = new List<CartViewModel>();
		}
		public IActionResult ShoppingCart()
		{
			var cart = HttpContext.Session.Get<List<CartViewModel>>(cartKey);
            HttpContext.Session.Set<int>(totalItems,cart.Sum(o=>o.Quantity));
			return View(cart);
		}

		[Authorize]
		public IActionResult WishList()
		{
			return View();
		}

		public IActionResult getProductByCategories(int id){
			var products = repo.filterByCategory(repo.getCategoryNameById(id));
			return View(products);
		}

		[HttpPost]
        public JsonResult getProductByCategories(string ItemId)
        {
            CartViewModel objShoppingCartModel = new CartViewModel();
            var objPro = repo.getById(int.Parse(ItemId));
			 if (!string.IsNullOrEmpty(HttpContext.Session.GetString(counterKey)))
			 {
				listOfShoppingCartModels = HttpContext.Session.Get<List<CartViewModel>>(cartKey);
			 }
        
           
            if (listOfShoppingCartModels != null && listOfShoppingCartModels.Any(model => model.ItemId == ItemId))
            {
                objShoppingCartModel = listOfShoppingCartModels.Single(model => model.ItemId == ItemId);
                objShoppingCartModel.Quantity = objShoppingCartModel.Quantity + 1;
                objShoppingCartModel.Total = objShoppingCartModel.Quantity * objShoppingCartModel.UnitPrice;
            }
            else
            {
                objShoppingCartModel.ItemId = ItemId;
                objShoppingCartModel.ItemName = objPro.Name;
                objShoppingCartModel.Quantity = 1;
                objShoppingCartModel.Total = objPro.Selling_Price;
                objShoppingCartModel.UnitPrice = objPro.Selling_Price;
                objShoppingCartModel.ImageUrl = objPro.ImageUrl;
                objShoppingCartModel.Description = objPro.Description;
                objShoppingCartModel.Recommendations = null;
                objShoppingCartModel.Recommendations =recommender.GetRecommendations(int.Parse(objShoppingCartModel.ItemId)).ToArray();
                listOfShoppingCartModels.Add(objShoppingCartModel);
            }

			HttpContext.Session.Set<int>(counterKey,listOfShoppingCartModels.Count);
			HttpContext.Session.Set<List<CartViewModel>>(cartKey,listOfShoppingCartModels);
            // SaveCartTotalToSession(listOfShoppingCartModels);
            return Json(new { Success = true, Counter = listOfShoppingCartModels.Count });
        }


		public ActionResult Remove(int id)
        {
            List<CartViewModel> cart = HttpContext.Session.Get<List<CartViewModel>>(cartKey);
            foreach(var item in cart)
            {
                if(item.ItemId == id.ToString())
                {
                    cart.Remove(item);
                    break;
                }
            }
            
           HttpContext.Session.Set<List<CartViewModel>>(cartKey,cart);
           HttpContext.Session.Set<int>(counterKey,cart.Count);
            if (cart == null)
            {
				HttpContext.Session.Set<List<CartViewModel>>(cartKey,null);
            }
           // SaveCartTotalToSession(cart);

            return RedirectToAction("ShoppingCart","Store");
        }

        public ActionResult Plus(int id)
        {
            List<CartViewModel> cart = HttpContext.Session.Get<List<CartViewModel>>(cartKey);
            foreach (var item in cart)
            {
                if (item.ItemId == id.ToString())
                {
                    item.Quantity = item.Quantity + 1;
                    item.Total = item.Quantity * item.UnitPrice;
                   
                }
            }
           	HttpContext.Session.Set<List<CartViewModel>>(cartKey,cart);
            //SaveCartTotalToSession(cart);
            return RedirectToAction("ShoppingCart", "Store");
        }
		public ActionResult Minus(int id)
        {
             List<CartViewModel> cart = HttpContext.Session.Get<List<CartViewModel>>(cartKey);
            foreach (var item in cart)
            {
                if (item.ItemId == id.ToString() && item.Quantity !=1) 
                {
                    item.Quantity = item.Quantity - 1;
                    item.Total = item.Quantity * item.UnitPrice;
                   
                }
            }
           	HttpContext.Session.Set<List<CartViewModel>>(cartKey,cart);
            //SaveCartTotalToSession(cart);
            return RedirectToAction("ShoppingCart", "Store");
        }

        public IActionResult productDetail(int id){
            return View(repo.getById(id));
        }
        [Authorize]
        public IActionResult checkout(){
	        var cart = HttpContext.Session.Get<List<CartViewModel>>(cartKey);
	        HttpContext.Session.Set<int>(totalItems,cart.Sum(o=>o.Quantity));
	        return View(cart);
        }

        public IActionResult ToggleButton(string value)
        {
	        Toggle toggle = new Toggle();
	        if (value.Equals(("Delivery")))
	        {
		        toggle.Delivery = true;
	        }
	        else
	        {
		        toggle.Collection = true;
	        }
	        return View(toggle);
        }
	}

}
