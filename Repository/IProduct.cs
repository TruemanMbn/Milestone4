using System.Collections.Generic;
using System;
namespace onlineShop.Repository;
public interface IProduct<T>:ICategory,ISupplier
{
    
    public int save(T obj);
    public T getById(int id);
    public IEnumerable<T> findAll();
    public bool remove(int id);
    public bool update(T obj);
    public IEnumerable<T> filterByName(string name);
    public IEnumerable<T> filterByCategory(string category);
    public IEnumerable<T> filterByPrice(int min, int max);
}
