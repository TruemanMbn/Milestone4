using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using onlineShop.Models;
using onlineShop.Repository;

namespace onlineShop.Controllers;

public class AdminController : BaseController
{
    private readonly GroupWst8Context context;
    private readonly IWebHostEnvironment hostEnvironment;
    private readonly IProduct<Product> repo;
    private readonly IFileHandler<Image> productImages;
    private readonly IProductCategory<ProductCategory> category;

    public AdminController(GroupWst8Context context,
     IWebHostEnvironment hostEnvironment,
     IProduct<Product> repo,
     IFileHandler<Image> productImages,
     IProductCategory<ProductCategory> category)
    {
        this.context = context;
        this.hostEnvironment = hostEnvironment;
        this.repo = repo;
        this.productImages = productImages;
        this.category = category;
    }
    public IActionResult Index()
    {
        return View(repo.findAll().OrderByDescending(p=>p.ProductId));
    }

    public IActionResult createProduct(){
        ViewBag.categories = new SelectList(repo.categories(), "products");
        var suppliers = repo.GetSuppliers();
        ViewBag.suppliers = selectList(suppliers,"SupplierId","SupplierName");
        return View(new Product());
    }
    [HttpPost]
    public IActionResult createProduct(Product product){
        var insert = repo.save(product);
        if(insert > 0){
           notify("Product Added Sucessfully");
           return RedirectToAction("createProduct");
        }
        notify("Failed to save product","ketekete Online Ordering",NotificationType.error);
        return View();
    }

    public IActionResult viewProduct(int id){
        return View(repo.getById(id));
    }
    [HttpPost]
    public IActionResult viewProduct(int id, Image image){
        image.ProductId = id;
        IEnumerable<Image> images = productImages.addProductImages(image);
        if(images.Count() <= 0){
         notify("Select Images to Upload!","Sketekete Online Ordering",NotificationType.error);
         return RedirectToAction("viewProduct");
        }
        notify("Product Images Uploaded!");
        return RedirectToAction("viewProduct");
    }
    public IActionResult editProduct(int id){
        return View(repo.getById(id));
    }
     [HttpPut]
    public IActionResult editProduct(int id, Product product){
       product.ProductId = id;
       bool updated = repo.update(product);
       if(updated)
        {
        notify("Product Info Updated!!");
        return RedirectToAction();
        }
       notify("Product Update Failed","ketekete Online Ordering",NotificationType.error);
       return RedirectToAction();
    }
    public IActionResult removeProduct(int id){
        bool removed = repo.remove(id);
        if(removed){
             notify($"Product with ProductId {id} Removed!!!");
            return RedirectToAction("Index");
        }
        notify($"Failed to Remove Product With Id {id}","ketekete Online Ordering",NotificationType.error);
        return View();
    }

    public IActionResult addCategory(){
        return View(new ProductCategory());
    }
    [HttpPost]
    public IActionResult addCategory(ProductCategory productCategory){
        var insert = category.save(productCategory);
        if(insert > 0){
           notify("New Category Added!");
           return RedirectToAction("createProduct");
        }
        notify("Failed to save category","ketekete Online Ordering",NotificationType.error);
        return View();
    }

    public IActionResult getCategories(){
        return View(category.findAll());
    }
    public IActionResult editCategory(int id){
        return View(category.getById(id));
    }
    [HttpPost]
    public IActionResult editCategory(int id, ProductCategory prodCategory){
        prodCategory.ProductCategoryId = id;
        var updated = category.update(prodCategory);
       if(updated)
        {
        notify("Category details updated!!");
        return RedirectToAction();
        }
       notify("Category update failed","ketekete Online Ordering",NotificationType.error);
       return RedirectToAction();
    }
    [NonAction]
    private SelectList selectList (IEnumerable<SupplierInfo> supplierlist, string value, string text)
    {
        ISet<SelectListItem> items = new HashSet<SelectListItem>();
        foreach(var supp in supplierlist){
            items.Add(new SelectListItem(){
                Value =supp.SupplierId.ToString(),
                Text = supp.SupplierName
            });
        }
        return new SelectList(items,"Value","Text");
    }
}
