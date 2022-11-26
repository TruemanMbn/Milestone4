using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace onlineShop.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Order = new HashSet<Order>();
        }
        [Key]
        public int Employee_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Street_Address { get; set; }
        public string City { get; set; }
        public int City_Code { get; set; }
        public string Type { get; set; }
        public string Email_Address { get; set; }
        public string Contact { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
