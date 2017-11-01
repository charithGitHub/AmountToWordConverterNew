using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmountInWords.DataModel
{
    public class AIWGlobals {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
