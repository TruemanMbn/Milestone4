using onlineShop.Models;

namespace onlineShop.Repository;

public class CustomerRepository:ICustomer<Customer>
{
    private readonly GroupWst8Context context;

    public CustomerRepository(GroupWst8Context context)
     {
        this.context = context;
    }
     public int addCustomer(Customer customer, string userId){
        var user = new Customer(){
        First_Name = customer.First_Name,
        Last_Name = customer.Last_Name,
        Email_Address = customer.Email_Address,
        Contact_Number = customer.Contact_Number,
        Date_Of_Birth = customer.Date_Of_Birth,
        City_Name = customer.City_Name,
        City_Code = customer.City_Code,
        ApplicationUserId =  userId
        };

        context.Customer.Add(user);
        return context.SaveChanges();
     }
    public int updateCustomer(int id,Customer customer){
        return 0;
    }
}
