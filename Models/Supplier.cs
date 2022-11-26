using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace onlineShop.Models
{
    public partial class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string Company_Name { get; set; }
        public string Street_Address { get; set; }
        public string City_Name { get; set; }
        public string City_Code { get; set; }
        public string Email_Address { get; set; }
        public string Contact_Number { get; set; }
        public string Supplier_Type { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
