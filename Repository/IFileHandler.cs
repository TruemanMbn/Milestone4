using System.Collections.Generic;
namespace onlineShop.Repository;

public interface IFileHandler<T>
{
    public IEnumerable<T> addProductImages(T obj);
    public T updateProductImages(int id, T obj);
}
