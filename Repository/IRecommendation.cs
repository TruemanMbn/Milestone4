using System.Collections.Generic;
using onlineShop.Models;

namespace onlineShop.Repository;

public interface IRecommendation
{
    public HashSet<Product> GetRecommendations(int id);
}
