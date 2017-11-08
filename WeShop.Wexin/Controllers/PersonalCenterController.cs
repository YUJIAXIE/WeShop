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
    public class PersonalCenterController : Controller
    {
        // GET: PersonalCenter
        string openId = "7027";
        public ICustomerService CustomerService { get; set; }
        public IShopCartService ShopCartService { get; set; }

        public ActionResult Center()// 个人主页
        {
            ViewData.Model = CustomerService.GetEntity(c => c.OpenId == openId);
            return View();
        }
        public ActionResult Center_set()//个人资料-设置
        {
            ViewData.Model = CustomerService.GetEntity(c => c.OpenId == openId);
            return View();
        }
        public ActionResult ShopCart()//购物车
        {
            ViewBag.Count = 200;//库存
            ViewData.Model = CustomerService.GetEntity(c => c.OpenId == openId).ShoppingCarts;
            return View();
        }
        public ActionResult Add_ShopCart(string ProCode, int Qty)//商品详情页加入购物车
        {
            ShoppingCart ShopCartCount = ShopCartService.GetEntity(s => s.CusId == openId && s.ProCode == ProCode);
            if (ShopCartCount == null)
            {
                ShopCartService.Add(new ShoppingCart { CusId = openId, ProCode = ProCode, Qty = Qty, CreateTime = DateTime.Now });
            }
            else
            {
                if (ShopCartCount.Qty + Qty > 200)
                    return Content("商品已达到库存，不能添加了");
                ShopCartCount.Qty = ShopCartCount.Qty + Qty;
                ShopCartCount.CreateTime = DateTime.Now;
                ShopCartService.Modify(ShopCartCount);
            }
            return Content("添加成功");

        }
        public ActionResult ShopCartProCount(string ProCode, int Qty)//购物车加减数量
        {
            ShoppingCart ShopCartCount = ShopCartService.GetEntity(s => s.CusId == openId && s.ProCode == ProCode);
            ShopCartCount.Qty = Qty;
            ShopCartCount.CreateTime = DateTime.Now;
            ShopCartService.Modify(ShopCartCount);
            return Content("添加成功");
        }
        public ActionResult ShopCart_Delete(string ProCode)//删除购物车商品
        {
            if (ShopCartService.Remove(new ShoppingCart() { CusId = openId, ProCode = ProCode }))
                return Content("删除成功");
            else
                return Content("删除失败");
        }
        
    }
}