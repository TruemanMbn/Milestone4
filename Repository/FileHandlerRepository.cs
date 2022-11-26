using System.Collections.Generic;
using System.Linq;
using FileUploadHelper.Strategy;
using Microsoft.AspNetCore.Hosting;
using onlineShop.Models;

namespace onlineShop.Repository;

public class FileHandlerRepository : IFileHandler<Image>
{
    private readonly GroupWst8Context context;
    private readonly IUploadFileStrategy imageUpload;
    private readonly IWebHostEnvironment hostEnvironment;
    public FileHandlerRepository(GroupWst8Context context,IWebHostEnvironment hostEnvironment)
    {
     this.context = context;
     this.hostEnvironment = hostEnvironment;
     imageUpload = new UploadFileStrategy(new LocalFileUploadHelper(hostEnvironment));   
    }
    public IEnumerable<Image> addProductImages(Image obj)
    {
        obj.ListOfFileCollection = new List<string>();
        if(obj.FileCollection != null && obj.FileCollection.Count > 0){
        var uploaded =imageUpload.CollectionFileUpload("Thumbnail",obj);
        if(uploaded){
        foreach(var image in obj.ListOfFileCollection){
         var images = new Image(){
            ProductId = obj.ProductId,
            imageUrl = image
         };

         context.Images.Add(images);
         context.SaveChanges();
        }
        return context.Images.Where(p=>p.ProductId.Equals(obj.ProductId)).AsEnumerable<Image>();
        }
       }
       return Enumerable.Empty<Image>();
    }

    public Image updateProductImages(int id, Image obj)
    {
        throw new System.NotImplementedException();
    }
}
