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
    public class OrderController : Controller
    {
        // GET: Order
        string openId = "7027";
        public ICustomerService CustomerService { get; set; }
        public IProductService ProductService { get; set; }
        public IOrderBillFathService OrderBillFathService { get; set; }
        public IOrderBillChiService OrderBillChiService { get; set; }
        public IPaymentService PaymentService { get; set; }

        //[HttpPost]
        //public ActionResult Confirm_Order(string ProCodes, string ProCounts, string BuyType)
        //{
        //    Session["ProCodes"] = ProCodes.Substring(0, ProCodes.Length - 1);
        //    Session["ProCounts"] = ProCounts.Substring(0, ProCounts.Length - 1);
        //    Session["BuyType"] = BuyType;
        //    return Content("成功");
        //}

        public ActionResult Confirm_Order(string ProCode, string ProCount, string BuyType)
        {
            if (ProCode == null || ProCount == null)
                return View("Error");
            string[] ProCodes = ProCode.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            string[] ProCounts = ProCount.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<Product> proList = new List<Product>();
            decimal? total = 0;
            bool isPinkage = false;
            Session["Expressprice"] = 10;//运费
            var Counts = 0;//商品总个数
            for (int i = 0; i < ProCodes.Length; i++)
            {
                var product = ProductService.GetEntity(p => p.Code == ProCodes[i]);
                proList.Add(product);
                total += product.SellPrice * int.Parse(ProCounts[i]);//订单总价
                Counts += int.Parse(ProCounts[i]);//商品总个数
                if (product.IsPinkage == "是" && isPinkage == false)
                {
                    isPinkage = true;
                    Session["Expressprice"] = 0;
                }
            }
            Confirm_OrderViewModel covm = new Confirm_OrderViewModel();
            ViewBag.counts = Counts;
            covm.User = CustomerService.GetEntity(c => c.OpenId == openId);
            covm.Products = proList;
            covm.ProCounts = ProCounts;
            covm.OrderTotal = total;
            covm.Expressprice = Convert.ToInt32(Session["Expressprice"]);
            covm.IsPinkage = isPinkage;
            covm.BuyType = BuyType;
            Session["covm"] = covm;
            return View(covm);
        }
        //[HttpPost]
        //public ActionResult Pay_Order(string Memo)
        //{
        //    Session["Memo"] = Memo;
        //    return Content("成功");
        //}
        public ActionResult Pay_Order(string Memo)
        {
            if (Session["covm"] == null)
                return View("Error");
            Confirm_OrderViewModel covm = Session["covm"] as Confirm_OrderViewModel;
            if (covm.BuyType == "1")
            {
                WeShopDb db = new WeShopDb();
                string sql = "dbo.CreateOrder {0},{1},{2},{3},{4},{5}";
                try
                {
                    db.Database.ExecuteSqlCommand(sql, openId, covm.OrderTotal, covm.Expressprice,Memo, "YH", Session["ProCodes"]);
                }
                catch (Exception)
                {
                }
                ViewBag.Order = OrderBillFathService.GetEntities(o => o.CusId == openId).OrderByDescending(o => o.CreateTime).FirstOrDefault().Code;

                //OrderBillFathService.Add(new OrderBillFath { Code = Session["OrderId"].ToString(), CusId = openId, State = "1", OrderPrice = 30, ExpressPrice = 10, SumPrice = covm.Total, PaymentId = null, Memo = Session["Memo"].ToString(), CheckUser = covm.User.Name, CreateTime = DateTime.Now, PayTime = null, PostTime = null, ReceTime = null });
                //for (int i = 0; i < covm.Products.Count(); i++)
                //{
                //    OrderBillChiService.Add(new OrderBillChi { Code = Session["OrderId"].ToString(), ProCode = covm.Products[i].Code, UnitPrice = covm.Products[i].SellPrice, Qty = int.Parse(covm.ProCounts[i]), SumPrice = covm.Products[i].SellPrice * int.Parse(covm.ProCounts[i]), IsReview = "否" });
                //    ShopCartService.Removes(ShopCartService.GetEntities(s => s.CusId == openId && s.ProCode == covm.Products[i].Code));
                //}
            }
            else
            {
                WeShopDb db = new WeShopDb();
                string sql = "dbo.CreateOrder2 {0},{1},{2},{3},{4},{5},{6}";
                try
                {
                    db.Database.ExecuteSqlCommand(sql, openId, covm.OrderTotal, covm.Expressprice,Memo, "YH", Session["ProCodes"], Session["ProCounts"]);
                }
                catch (Exception)
                {
                }

                //OrderBillFathService.Add(new OrderBillFath { Code = Session["OrderId"].ToString(), CusId = openId, State = "1", OrderPrice = 30, ExpressPrice = 10, SumPrice = covm.Total, PaymentId = null, Memo = Session["Memo"].ToString(), CheckUser = covm.User.Name, CreateTime = DateTime.Now, PayTime = null, PostTime = null, ReceTime = null });
                //for (int i = 0; i < covm.Products.Count(); i++)
                //{
                //    OrderBillChiService.Add(new OrderBillChi { Code = Session["OrderId"].ToString(), ProCode = covm.Products[i].Code, UnitPrice = covm.Products[i].SellPrice, Qty = int.Parse(covm.ProCounts[i]), SumPrice = covm.Products[i].SellPrice * int.Parse(covm.ProCounts[i]), IsReview = "否" });
                //}
            }
            ViewBag.Order = OrderBillFathService.GetEntities(o => o.CusId == openId).OrderByDescending(o => o.CreateTime).FirstOrDefault().Code;//查询订单编号
            ViewBag.Total = OrderBillFathService.GetEntities(o => o.CusId == openId).OrderByDescending(o => o.CreateTime).FirstOrDefault().SumPrice;//查询订单总价
            ViewData.Model = PaymentService.GetEntities(p => true);//查询所有支付方式
            Session["ProCodes"] = null;
            Session["ProCounts"] = null;
            return View();
        }


        //[HttpPost]
        //public ActionResult Pay_Succeed(int? PaymentId)
        //{
        //    var Orderid = OrderBillFathService.GetEntities(o => o.CusId == openId).OrderByDescending(o => o.CreateTime).FirstOrDefault().Code;//查询订单编号
        //    var orderBillFath = OrderBillFathService.GetEntity(o => o.Code == Orderid);//根据订单编号查询订单主表
        //    orderBillFath.PaymentId = PaymentId;//支付方式ID
        //    orderBillFath.PayTime = DateTime.Now;//支付时间
        //    orderBillFath.State = 1;//修改订单状态
        //    OrderBillFathService.Modify(orderBillFath);

        //    Session["Expressprice"] = null;
        //    Session["BuyType"] = null;
        //    Session["covm"] = null;
        //    Session["Memo"] = null;
        //    return Content("成功");
        //}
        public ActionResult Pay_Succeed(int? PaymentId)
        {
            var Orderid = OrderBillFathService.GetEntities(o => o.CusId == openId).OrderByDescending(o => o.CreateTime).FirstOrDefault().Code;//查询订单编号
            var orderBillFath = OrderBillFathService.GetEntity(o => o.Code == Orderid);//根据订单编号查询订单主表
            orderBillFath.PaymentId = PaymentId;//支付方式ID
            orderBillFath.PayTime = DateTime.Now;//支付时间
            orderBillFath.State = 1;//修改订单状态
            OrderBillFathService.Modify(orderBillFath);

            Session["Expressprice"] = null;
            Session["BuyType"] = null;
            Session["covm"] = null;
            Session["Memo"] = null;

            ViewData.Model = OrderBillFathService.GetEntities(o => o.CusId == openId).OrderByDescending(o => o.CreateTime).FirstOrDefault().Code;//查询订单编号
            return View();
        }
        public ActionResult OrderDetails(string Code)
        {
             ViewData.Model= OrderBillFathService.GetEntity(o => o.CusId ==openId && o.Code== Code);//根据订单编号查询订单主表
            return View();
        }


        public ActionResult MyOrder()
        {
            MyOrderViewModel movm = new MyOrderViewModel();
            movm.WholeOrder = OrderBillFathService.GetEntityiesByPage(10, 1, false, n => true, n => n.CreateTime);
            //movm.WholeOrder = OrderBillFathService.GetEntities(o => o.CusId == openId);
            return View(movm);
        }
    }
}