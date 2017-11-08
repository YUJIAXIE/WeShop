using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeShop.EFModel;

namespace WeShop.Wexin.Models
{
    public class MyOrderViewModel
    {
        /// <summary>
        /// 全部
        /// </summary>
        public IEnumerable<OrderBillFath> WholeOrder { get; set; }
        /// <summary>
        /// 待收货
        /// </summary>
        public List<OrderBillFath> PendingPayment { get; set; }
        /// <summary>
        /// 待发货
        /// </summary>
        public List<OrderBillFath> PendingShipment { get; set; }
        /// <summary>
        /// 待收货
        /// </summary>
        public List<OrderBillFath> PendingReceipt { get; set; }
        /// <summary>
        /// 待评价
        /// </summary>
        public List<OrderBillFath> PendingEvaluation { get; set; }
    }
}