using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmountInWords.BusinessContract;

namespace AmountInWords.BusinessImplementation {
    public class AmountToWordsConverter : IAmountToWordsConverter {
        /// <summary>
        /// Convert Amount into words based on the language
        /// </summary>
        /// <param name="amount">input amount</param>
        /// <param name="language">prefered language</param>
        /// <returns>converted amount in words</returns>
        public string AmountConverter(string amount, string language = "English") {
            string amountWords = string.Empty;
            
            switch (language) {
                case "English":
                    amountWords = new AmountToEnglishWords().ConvertAmountToWords(amount);
                    break;
                case "Spanish":
                    throw new NotImplementedException();                    
                default:
                    amountWords = new AmountToEnglishWords().ConvertAmountToWords(amount);
                    break;
            }

            return amountWords;
        }
    }
}
