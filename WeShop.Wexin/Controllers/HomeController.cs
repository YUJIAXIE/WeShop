using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeShop.EFModel;
using WeShop.IService;
using WeShop.Wexin.Models;

namespace WeShop.Wexin.Controllers
{
    public class HomeController : Controller
    {
        public IBannerService BannerService { get; set; }
        public INoticeService NoticeService { get; set; }
        public IProductService ProdoctService { get; set; }
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.NoticeNum = NoticeService.GetCount(n => true);
            homeViewModel.Banners = BannerService.GetEntities(b => true);
            homeViewModel.Notices = NoticeService.GetEntityiesByPage(3, 1, false,n=>true, n => n.ModiTime);
            homeViewModel.NewProducts = ProdoctService.GetEntityiesByPage(3, 1, false, n => true, n => n.ModiTime);
            homeViewModel.RecProducts = ProdoctService.GetEntityiesByPage(3, 1, true, n => true, n => n.SellPrice);
            return View(homeViewModel);
        }
    }
}