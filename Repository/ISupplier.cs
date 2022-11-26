using System.Collections.Generic;
namespace onlineShop.Repository;


public class SupplierInfo{
    public int SupplierId { get; set; }
    public string SupplierName { get; set; }
}
public interface ISupplier
{
    public IEnumerable<SupplierInfo> GetSuppliers();
}
