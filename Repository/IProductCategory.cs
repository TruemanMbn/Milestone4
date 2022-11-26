using System.Collections.Generic;
namespace onlineShop.Repository;

public interface IProductCategory<T>
{
    public int save(T obj);
    public T getById(int id);
    public IEnumerable<T> findAll();
    public bool remove(int id);
    public bool update(T obj);
}