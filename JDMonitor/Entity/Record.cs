using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using ServiceStack.DataAnnotations;

namespace JDMonitor.Entity
{
    public class Record : EntityBase
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public bool IsEnable { get; set; } = true;

        public DateTime LastSyncAt { get; set; }
        public float NewestPrice { get; set; } = 0;
        public string ImageUrl { get; set; }

        public string ImageXPath { get; set; } = "/html/body/div[6]/div/div[1]/div/div[1]/img";
        public string PriceXPath { get; set; } = "/html/body/div[6]/div/div[2]/div[3]/div/div[1]/div[2]/span[1]/span[2]";
        public string CouponXPath { get; set; } = "/html/body/div[6]/div/div[2]/div[4]/div/div[3]/div[2]/dl/dd/a/span/span";
        public string NewestCoupon { get; set; }

        public List<string> PriceXPathArray()
        {
            if(string.IsNullOrEmpty(PriceXPath))return new List<string>();
            return PriceXPath.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries).ToList();
        }


        /// <summary>
        /// 商品预览图
        /// </summary>
        [Ignore]
        public Bitmap Image
        {
            get
            {
                if (string.IsNullOrEmpty(ImageUrl)) return null;
                else
                {
                    try
                    {
                        var wb = new WebClient();
                        var bitmapBytes = wb.DownloadData(ImageUrl);
                        if (bitmapBytes == null) return null;
                        using var ms = new MemoryStream(bitmapBytes);
                        var result = System.Drawing.Image.FromStream(ms);
                        return result as Bitmap;
                    }
                    catch(Exception ex)
                    {
                        //ignore
                        return null;
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"Record(Id={Id} Title={Title} Url={Url} IsEnable={IsEnable} PriceXPath={PriceXPath} CouponXPath={CouponXPath} ImageXPath={ImageXPath} NewestPrice={NewestPrice} NewestCoupon={NewestCoupon} LastSyncAt={LastSyncAt} CreateAt={CreateAt})";
        }

        public string Remark { get; set; }
    }
}
