using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FileUploadHelper.Base;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace onlineShop.Models
{
    public partial class ProductCategory:ProductImage
    {
        [Key]
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
