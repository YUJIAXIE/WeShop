using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeShop.IService;

namespace WeShop.Wexin.Controllers
{
    public class NoticeController : Controller
    {
        // GET: Notice
        public INoticeService NoticeService { get; set; }
        public ActionResult NoticeList()
        {
            var noticeList = NoticeService.GetEntities(n => true);
            return View(noticeList);
        }
        public ActionResult NoticeDetails(int id)
        {
            var noticeList = NoticeService.GetEntity(u=>u.Id==id);
            return View(noticeList);
        }
    }
}