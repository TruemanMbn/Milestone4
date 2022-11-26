using System;

namespace onlineShop.Exceptions;

public class ProductDoesNotExistException:Exception
{
    public ProductDoesNotExistException(string message):base(message)
    {
        
    }
    public ProductDoesNotExistException():base()
    {
        
    }
}
