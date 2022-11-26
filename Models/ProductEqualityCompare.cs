using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace onlineShop.Models;

public class ProductEqualityCompare : IEqualityComparer<Product>
{
    public bool Equals(Product x, Product y)
    {    
        return x.ProductId.Equals(y.ProductId) && x.Selling_Price.Equals(y.Selling_Price)&& x.Name.Equals(y.Name, System.StringComparison.InvariantCultureIgnoreCase);
    }

    public int GetHashCode([DisallowNull] Product obj)
    {
        return obj.GetHashCode();
    }
}
