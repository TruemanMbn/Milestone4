using System;
using System.Collections.Generic;
using System.Linq;
using FileUploadHelper.Strategy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using onlineShop.Models;

namespace onlineShop.Repository;

public class CategoryRepository : IProductCategory<ProductCategory>
{
    private readonly IWebHostEnvironment host;
    private readonly GroupWst8Context context;
    private readonly IUploadFileStrategy uploadFileStrategy;

    public CategoryRepository(IWebHostEnvironment host,GroupWst8Context context)
    {
        this.host = host;
        this.context = context;
        uploadFileStrategy = new UploadFileStrategy(new LocalFileUploadHelper(host));
    }
    public IEnumerable<ProductCategory> findAll()
    {
        return context.ProductCategory.ToHashSet();
    }

    public ProductCategory getById(int id)
    {
        var category = context.ProductCategory.SingleOrDefault(o=>o.ProductCategoryId.Equals(id));
        if(category == null) throw new Exception($"Category with {id} not found");
        return category;
    }

    public bool remove(int id)
    {
        var category = context.ProductCategory.SingleOrDefault(o=>o.ProductCategoryId.Equals(id));
        if(category == null) throw new Exception($"Category with {id} not found");
        context.ProductCategory.Remove(category);
        context.SaveChanges();
        return true;
    }

    public int save(ProductCategory obj)
    {
        var category = new ProductCategory(){
            ProductCategoryName = obj.ProductCategoryName,
            ImageUrl = uploadFileStrategy.SingleFileUpload("Thumbnail",obj.File)
        };
        context.ProductCategory.Add(category);
        return context.SaveChanges();
    }

    public bool update(ProductCategory obj)
    {
        var category = context.ProductCategory.SingleOrDefault(o=>o.ProductCategoryId.Equals(obj.ProductCategoryId));
        if(category == null) return false;
        category.ProductCategoryName = obj.ProductCategoryName;
        if(string.IsNullOrEmpty(category.ImageUrl) && obj.File != null){
         category.ImageUrl = uploadFileStrategy.SingleFileUpload("Thumbnail",obj.File);
        }else if(!string.IsNullOrEmpty(category.ImageUrl) && obj.File != null){
            uploadFileStrategy.Remove("Thumbnail",obj.ImageUrl);
            category.ImageUrl = uploadFileStrategy.SingleFileUpload("Thumbnail",obj.File);
            
        }
         context.ProductCategory.Attach(category);
         context.Entry(category).State = EntityState.Modified;
         context.SaveChanges();
        return true;
    }
}
