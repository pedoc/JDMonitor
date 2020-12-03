using ServiceStack.DataAnnotations;

namespace JDMonitor.Entity
{
    public class Price : EntityBase
    {
        [ForeignKey(typeof(Record))]
        public int RecordId { get; set; }
        public float Value { get; set; }
        /// <summary>
        /// 优惠券
        /// </summary>
        public string Coupon { get; set; }

        /// <summary>
        /// 所属日期 形如 2020-06-05
        /// </summary>
        public string Date { get; set; }
    }
}
