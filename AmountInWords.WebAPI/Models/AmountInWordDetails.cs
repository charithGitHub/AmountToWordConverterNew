using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmountInWords.WebAPI.Models {
    public class AmountInWordDetails {        
        public string Words { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public int ValidationStatus { get; set; }
    }
}