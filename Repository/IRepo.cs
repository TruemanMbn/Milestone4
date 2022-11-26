using onlineShop.ViewModel;
using System.Collections.Generic;

namespace onlineShop.Repository
{
    public interface IRepo
    {
        public List<ProductViewModel> getAllProducts();
    }
}
