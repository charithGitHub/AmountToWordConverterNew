using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TFNValidator.DAL.DataModel {
    public class TFNGlobals {        
        public int SysId { get; set; }
        public string SysName { get; set; }
        public string SysVersion { get; set; }
        public string AppId { get; set; }
        public string Variable { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime TouchDate { get; set; }
        public string TouchBy { get; set; }
    }
}
