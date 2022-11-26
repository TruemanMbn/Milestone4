using onlineShop.Models;

namespace onlineShop.Repository;

public interface ICustomer<T>
{
   public int addCustomer(Customer customer,string UserId);
    public int updateCustomer(int id,Customer customer);
}
