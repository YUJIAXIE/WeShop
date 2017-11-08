using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeShop.EFModel;

namespace WeShop.Wexin.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<Sort> YiSort { get; set; }
        public IEnumerable<Sort> ErSort { get; set; }

        /// <summary>
        /// 综合
        /// </summary>
        public IEnumerable<Product> ComProduct { get; set; }
        /// <summary>
        /// 销量
        /// </summary>
        public IEnumerable<Product> SvProduct { get; set; }
        /// <summary>
        /// 评价
        /// </summary>
        public IEnumerable<Product> EvaProduct { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public IEnumerable<Product> PriProduct { get; set; }
    }
}