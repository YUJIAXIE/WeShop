using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeShop.EFModel;

namespace WeShop.IService
{
    public interface IProductService : IBaseService<Product>
    {
        IEnumerable<Product> GetEntities(Func<Product, bool> p);
    }
}
