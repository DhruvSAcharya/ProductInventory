using ProductInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IDataAccess
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductbyId(int id);
    }
}
