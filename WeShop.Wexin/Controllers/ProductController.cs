using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeShop.IService;
using WeShop.Wexin.Models;
using WeShop.EFModel;

namespace WeShop.Wexin.Controllers
{
    public class ProductController : Controller
    {
        string openId = "7027";
        // GET: Product
        public IProductService ProductService { get; set; }
        public IProSortService ProSortService { get; set; }
        public ISearchHistoryService SearchHistoryService { get; set; }
        public ProductViewModel ProductViewModel { get; set; }
        public ICustomerService CustomerService { get; set; }
        /// <summary>
        /// 商品详情
        /// </summary>
        /// <param name="code">商品Code</param>
        public ActionResult ProDetails(string code)
        {
            ViewBag.Count = 200;//库存
            ViewData.Model = ProductService.GetEntity(p => p.Code == code);
            return View();
        }
        /// <summary>
        /// 级别分类
        /// </summary>
        public ActionResult Sort()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.YiSort = ProSortService.GetEntities(p => p.UpCode == "");
            productViewModel.ErSort = ProSortService.GetEntities(p => p.UpCode != "");
            return View(productViewModel);
        }
        public ActionResult Search()//搜索
        {
            ViewData.Model = CustomerService.GetEntity(c => c.OpenId == openId).SearchHistories.OrderByDescending(c => c.Datetime);
            return View();
        }

        /// <summary>
        /// 商品列表
        /// </summary>
        /// <param name="SortCode">分类Code</param>
        public ActionResult Search_List(string SortCode, string SearchType)
        {
            ProductViewModel PVM = new ProductViewModel();
            if (SearchType == "Sort")
            {
                PVM.ComProduct = ProSortService.GetEntity(p => p.Code==SortCode).Products;
                PVM.SvProduct = ProSortService.GetEntity(p => p.Code == SortCode).Products;
                PVM.EvaProduct = ProSortService.GetEntity(p => p.Code == SortCode).Products;
                PVM.PriProduct = ProSortService.GetEntity(p => p.Code == SortCode).Products;
            }

            else if (SearchType == "Search")
            {
                var History = SearchHistoryService.GetEntity(u => u.CusId == openId && u.SearchText == SortCode);
                if (History != null)
                {
                    History.Datetime = DateTime.Now;
                    SearchHistoryService.Modify(History);
                }
                else
                {
                    SearchHistoryService.Add(new SearchHistory() { CusId = openId, SearchText = SortCode, Datetime = DateTime.Now });
                }
                
                PVM.ComProduct = ProductService.GetEntities(p => p.Name.Contains(SortCode));
                PVM.SvProduct = ProductService.GetEntities(p => p.Name.Contains(SortCode));
                PVM.EvaProduct = ProductService.GetEntities(p => p.Name.Contains(SortCode));
                PVM.PriProduct = ProductService.GetEntities(p => p.Name.Contains(SortCode));
                //ProductViewModel.ComProduct = ProductService.GetEntities(p => p.Name.Contains(SortCode));
                //ProductViewModel.SvProduct = ProductService.GetEntities(p => p.Name.Contains(SortCode));
                ViewBag.Search_text = SortCode;
            }
            return View(PVM);
        }
        public ActionResult Delete_SearchHistory()//删除搜索历史
        {
            var deleteSearchHistory = CustomerService.GetEntity(c => c.OpenId == openId).SearchHistories;
            if (SearchHistoryService.Removes(deleteSearchHistory))
                return Content("200");
            else
                return Content("404");
        }
    }
}