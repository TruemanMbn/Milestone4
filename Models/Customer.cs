using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace onlineShop.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }
        [Key]
        public int CustomerId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email_Address { get; set; }
        public string Gender { get; set; }
        public string Contact_Number { get; set; }
        public DateTime? Date_Of_Birth { get; set; }
        public string City_Name { get; set; }
        public string City_Code { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
