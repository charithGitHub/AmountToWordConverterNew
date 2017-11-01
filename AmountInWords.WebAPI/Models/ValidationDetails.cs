using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmountInWords.WebAPI.Models {
    public class ValidationDetails {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public int ValidationStatus { get; set; }
    }
}