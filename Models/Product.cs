using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using FileUploadHelper.Base;
using Microsoft.AspNetCore.Http;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace onlineShop.Models
{
    public partial class Product:ProductImage
    {
        [Key]
        public int ProductId { get; set; }
        [Display(Name ="Supplier Name")]
        public int SupplierId { get; set; }
         public int CategoryId { get; set; }
         [Display(Name ="Category")]
        public string Product_Category { get; set; }
         [Display(Name ="Quantity")]
        public int Unit_In_Stock { get; set; }
        public int Reorder_Level { get; set; }
        public decimal Selling_Price { get; set; }
         [Display(Name ="Product Name")]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public virtual Supplier Supplier { get; set; }
         [Display(Name ="Select Product Images")]
         [JsonIgnore]
        public virtual IEnumerable<Image> ListOfImages {get; set;}

        
    }
}
