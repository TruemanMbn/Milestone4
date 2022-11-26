
using System.Collections.Generic;
using System.Linq;
using onlineShop.Models;

namespace onlineShop.Repository;

public class ProductRecommenderRepository : IRecommendation
{
    private readonly GroupWst8Context context;

    public ProductRecommenderRepository(GroupWst8Context context)
    {
        this.context = context;
    }
    public HashSet<Product> GetRecommendations(int id)
    {
         HashSet<Product> tempList = new HashSet<Product>();
        var orderLine = context.OrderLine.FirstOrDefault(o=>o.ProductId.Equals(id)); //get list of orderlines with this productId
        if(orderLine != null){
         var list = context.OrderLine.Where(order=>order.OrderId.Equals(orderLine.OrderId)).Select(o=>o.ProductId).ToHashSet();
         foreach(var itemId in list){
            var prod = context.Product.Where(o=>o.ProductId.Equals(itemId)).ToList();
            foreach(var p in prod){
                var product = context.Product.SingleOrDefault(o=>o.ProductId.Equals(p.ProductId));
                tempList.Add(product);
            }
           
         }
        }
        return tempList;
    }
}
