using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeShop.EFModel;
using WeShop.IRepository;
using WeShop.IService;

namespace WeShop.Service
{
    public class SearchHistoryService : BaseService<SearchHistory>, ISearchHistoryService
    {
        public SearchHistoryService(ISearchHistoryRepository baseRepository) : base(baseRepository)
        {
        }
    }
}
