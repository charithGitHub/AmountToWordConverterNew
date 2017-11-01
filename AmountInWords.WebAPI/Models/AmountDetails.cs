using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmountInWords.WebAPI.Models {
    public class AmountDetails {
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string Requester { get; set; }
        public string AppCode { get; set; }
    }
}