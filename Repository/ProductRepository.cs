using System.Diagnostics;
using FileUploadHelper.Strategy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using onlineShop.Exceptions;
using onlineShop.Models;
using onlineShop.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace onlineShop.Repository
{
    public class ProductRepository :IProduct<Product>,ISupplier
    {
        private GroupWst8Context _context;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IUploadFileStrategy imageUpload;

        public ProductRepository(GroupWst8Context context,IWebHostEnvironment hostEnvironment)
        {
            this._context = context;
            this.hostEnvironment = hostEnvironment;
            imageUpload = new UploadFileStrategy(new LocalFileUploadHelper(hostEnvironment));
            
        }

        public IEnumerable<Product> filterByCategory(string category)
        {
            var productList = _context.Product.Include(img =>img.ListOfImages).ToHashSet();
            if(string.IsNullOrEmpty(category))return productList;
            return productList.Where(p=>p.Product_Category.ToLower().Equals(category.ToLower())).ToHashSet();
        }

        public IEnumerable<Product> filterByName(string name)
        {
            var productList = _context.Product.Include(img =>img.ListOfImages).ToHashSet();
            if(string.IsNullOrEmpty(name))return productList;
            return productList.Where(p=>p.Name.ToLower().Contains(name.ToLower())).ToHashSet();
        }

        public IEnumerable<Product> filterByPrice(int min, int max)
        {
            var productList = _context.Product.Include(img =>img.ListOfImages).ToHashSet();
            return productList.Where(p=>p.Selling_Price >=min && p.Selling_Price <= max).ToHashSet();
        }

        public IEnumerable<Product> findAll()
        {
             return _context.Product.Include(img =>img.ListOfImages).AsEnumerable<Product>().ToHashSet();
        }

        public Product getById(int id)
        {
            var product = _context.Product.Include(img =>img.ListOfImages).SingleOrDefault(product=>product.ProductId.Equals(id));
            if(product == null) throw new ProductDoesNotExistException($"Product With Id: {id} doest not exist!");
            return product;
        }

        public bool remove(int id)
        {
            var product = _context.Product.SingleOrDefault(p=>p.ProductId.Equals(id));
            if(product == null) throw new ProductDeletionException($"Can not delete product with id: {id}");
            if(product.ListOfImages == null){
                 _context.Product.Remove(product);
                  imageUpload.Remove("Thumbnail",product.ImageUrl);
                 _context.SaveChanges();
                  return true;
            }else{
                 imageUpload.Remove("Thumbnail",product.ImageUrl);
                foreach(var img in product.ListOfImages)
                {
                    imageUpload.Remove("Thumbnail",img.imageUrl);
                }
                _context.Product.Remove(product);
                _context.SaveChanges();
                return true;
            }
        }

        public int save(Product obj)
        {
            var product = new Product(){
                SupplierId = obj.SupplierId,
                Unit_In_Stock = obj.Unit_In_Stock,
                Reorder_Level = obj.Reorder_Level,
                Selling_Price = obj.Selling_Price,
                Name = obj.Name,
                Product_Category =obj.Product_Category,
                ImageUrl = imageUpload.SingleFileUpload("Thumbnail",obj.File)
            };

            _context.Product.Add(product);
            return _context.SaveChanges();
        }

        public bool update(Product obj)
        {
            var product = _context.Product.Include(f=>f.ListOfImages).SingleOrDefault(o=>o.ProductId.Equals(obj.ProductId));
            if(product==null)return false;
            product.Unit_In_Stock =obj.Unit_In_Stock;
            product.Reorder_Level =obj.Reorder_Level;
            product.Selling_Price = obj.Selling_Price;
            product.Name = obj.Name;
            product.Description = obj.Description;
            if(obj.File !=null){
            if(string.IsNullOrEmpty(product.ImageUrl)){
                product.ImageUrl = imageUpload.SingleFileUpload("Thumbnail",obj.File);
            }else{
                imageUpload.Remove("Thumbnail",product.ImageUrl);
                product.ImageUrl = imageUpload.SingleFileUpload("Thumbnail",obj.File);
            }
            }
            _context.Product.Attach(product);
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        IEnumerable<string> ICategory.categories()
        {
            var product =_context.ProductCategory.Select(p=>p.ProductCategoryName).ToHashSet();
            return product;
        }

        public IEnumerable<SupplierInfo> GetSuppliers()
        {
            var suppliers = (from supp in _context.Supplier select new SupplierInfo()
            {
                SupplierId = supp.SupplierId,SupplierName =supp.Company_Name
            }).ToHashSet();
            return suppliers;                              
        }

        public string getCategoryNameById(int id)
        {
            return _context.ProductCategory.SingleOrDefault(o=>o.ProductCategoryId.Equals(id)).ProductCategoryName;
        }
    }
}
