using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmountInWords.WebAPI.Models {
    /// <summary>
    /// Use this model to pass the information entered via browser
    /// </summary>
    public class TaxFileDetails {
        public int[] FileNumber { get; set; }
        public string Requester { get; set; }
        public string AppCode { get; set; }
    }
}