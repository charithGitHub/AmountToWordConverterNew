using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmountInWords.BusinessContract {
    public interface IAmountToWords {
        string ConvertAmountToWords(string amount);
    }
}
