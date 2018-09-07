using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NebulaApi.Models
{
    public class DishBase
    {
        public string _id { get; set; }
        public string extId { get; set; }
        public string shopID { get; set; }
        public string barcode { get; set; }
        [Display(Name = "Название")]
        public string name { get; set; }
        public string nameFull { get; set; }
        public string VAT { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Display(Name = "Цена")]
        public decimal? sellingPrice { get; set; }
        public bool useGroupMarginRule { get; set; }
        public bool isAlcohol { get; set; }
        public string alcoholCode { get; set; }
        public string ownMarginRule { get; set; }
        public DateTime modified { get; set; } //01.01.0001
        public int __v { get; set; }
        public bool isService { get; set; }
        public string uuid { get; set; }
        public bool isDelete { get; set; }
        public string code { get; set; }
        public bool isBeer { get; set; }
    }
}