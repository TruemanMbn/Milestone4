using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FileUploadHelper.Base;
using Microsoft.AspNetCore.Http;

namespace onlineShop.Models;

public class Image:ProductImage
{
    [Key]
    public int Id{ get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public string imageUrl { get; set; }
}
