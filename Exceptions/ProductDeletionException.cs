using System;

namespace onlineShop.Exceptions;

public class ProductDeletionException:Exception
{
     public ProductDeletionException(string message):base(message)
    {
        
    }
    public ProductDeletionException():base()
    {
        
    }
}
