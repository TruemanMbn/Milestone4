using System.Collections.Generic;

namespace onlineShop.Repository;

public interface ICategory
{
    public IEnumerable<string> categories();
    public string getCategoryNameById(int id);
}
