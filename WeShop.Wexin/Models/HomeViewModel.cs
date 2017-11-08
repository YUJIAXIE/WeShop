using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeShop.EFModel;

namespace WeShop.Wexin.Models
{
    public class HomeViewModel
    {
        public int NoticeNum { get; set; }
        /// <summary>
        /// 轮播
        /// </summary>
        public IEnumerable<Banner> Banners { get; set; }
        /// <summary>
        /// 公告
        /// </summary>
        public IEnumerable<Notice> Notices { get; set; }
        /// <summary>
        /// 热销
        /// </summary>
        public IEnumerable<Product> NewProducts { get; set; }
        /// <summary>
        /// 推荐
        /// </summary>
        public IEnumerable<Product> RecProducts { get; set; }
    }
}