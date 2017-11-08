using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeShop.EFModel;
using WeShop.IService;
using WeShop.IRepository;

namespace WeShop.Service
{
    public class OrderBillChiService : BaseService<OrderBillChi>, IOrderBillChiService
    {
        public OrderBillChiService(IOrderBillChiRepository baseRepository) : base(baseRepository)
        {
        }
    }
}
