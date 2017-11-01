using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmountInWords.BusinessContract;

namespace AmountInWords.BusinessImplementation {
    public class AmountToEnglishWords : IAmountToWords {

        EnglishWordDetails numbersToWordsModel = new EnglishWordDetails();

        /// <summary>
        /// Logic to convert the number to English Words
        /// </summary>
        /// <param name="amount">Entered Amount</param>
        /// <returns>English WOrds</returns>
        public string ConvertAmountToWords(string amount) {
            string amountInEnglish = string.Empty;
            int num = 0;
            if (!string.IsNullOrEmpty(amount)) {
                //Checks whether amount has decimal places
                if (amount.Contains(".")) {
                    string[] amountWithDecimals = amount.Split('.');
                    //multiple . will be ignored and considers as invalid
                    if (amountWithDecimals.Length == 2) {
                        if (!string.IsNullOrEmpty(amountWithDecimals[0]) && int.TryParse(amountWithDecimals[0], out num)) {
                            amountInEnglish += ConvertNumberToWords(num);
                            amountInEnglish += " DOLLARS";
                        }
                        //Decimal places will be converted and build the cents words
                        if (!string.IsNullOrEmpty(amountWithDecimals[1]) && int.TryParse(amountWithDecimals[1], out num)) {
                            amountInEnglish += " AND";
                            amountInEnglish += ConvertNumberToWords(num);
                            if (amountInEnglish.Contains("-")) {
                                amountInEnglish.Replace("-", "");
                            }
                            amountInEnglish += " CENTS";
                        }
                    }
                } else {
                    if (int.TryParse(amount, out num)) {
                        amountInEnglish += ConvertNumberToWords(num);
                        amountInEnglish += " DOLLARS";
                    }
                }
            }

            return amountInEnglish;
        }
        /// <summary>
        /// Numeric value will be converted to English Words
        /// </summary>
        /// <param name="value">Number</param>
        /// <returns>Converted Words</returns>
        private string ConvertNumberToWords(int value) {

            string _words = string.Empty;
            
            //Ones
            if (value <= 9) {
                _words += numbersToWordsModel.Ones[value].Item2;
            }
            //Teens
            else if (value <= 19) {
                _words += numbersToWordsModel.Teens[value % 10].Item2;
            }
            //Tens
            else if (value <= 99) {
                int tens = (int)(Math.Floor((double)value / 10.0));
                int ones = value % 10;
                _words += numbersToWordsModel.Tens[tens].Item2 + "-";
                ConvertNumberToWords(ones);
            }
            //Hundreds
            else if (value <= 999) {
                int hundreds = (int)(Math.Floor((double)value / 100.0));
                int tens = (int)(Math.Floor((double)value % 100.0));

                _words += numbersToWordsModel.Ones[hundreds].Item2 + " " + numbersToWordsModel.Hundreds[0].Item2 + " ";
                ConvertNumberToWords(tens);
            }
            //Thousands
            else if (value <= 9999) {
                int thousands = (int)(Math.Floor((double)value / 1000.0));
                int hundreds = (int)(Math.Floor((double)value % 1000.0));

                _words += numbersToWordsModel.Ones[thousands].Item2 + " " + numbersToWordsModel.Hundreds[1].Item2 + " ";
                ConvertNumberToWords(hundreds);
            }
            //Ten Thousands
            else if (value <= 99999) {
                int tenthousands = (int)(Math.Floor((double)value / 10000.0));
                int thousands = (int)(Math.Floor((double)value % 10000.0));

                _words += numbersToWordsModel.Tens[tenthousands].Item2 + "-"; //+ numbersToWordsModel.Hundreds[1].Item2 + " "; ;
                ConvertNumberToWords(thousands);
            }
            //Hundred Thousands
            else if (value <= 999999) {
                int hundredthousands = (int)(Math.Floor((double)value / 100000.0));
                int tenthousands = (int)(Math.Floor((double)value % 100000.0));

                _words += numbersToWordsModel.Ones[hundredthousands].Item2 + " " + numbersToWordsModel.Hundreds[0].Item2 + " ";
                ConvertNumberToWords(tenthousands);
            }
            //Million
            else if (value <= 9999999) {
                int million = (int)(Math.Floor((double)value / 1000000.0));
                int hundredthousands = (int)(Math.Floor((double)value % 1000000.0));

                _words += numbersToWordsModel.Ones[million].Item2 + " " + numbersToWordsModel.Hundreds[2].Item2 + " ";
                ConvertNumberToWords(hundredthousands);
            }

            return FormatWords(_words);            
        }
        /// <summary>
        /// Formats the words
        /// </summary>
        /// <param name="_words">concatinated words</param>
        /// <returns>words after formating</returns>
        private string FormatWords(string _words) {
            _words = _words.TrimEnd().ToUpper();

            if (_words.Contains("TEN-ONE")) {
                _words = _words.Replace("TEN-ONE", numbersToWordsModel.Teens[1].Item2);
            } else if (_words.Contains("TEN-TWO")) {
                _words = _words.Replace("TEN-TWO", numbersToWordsModel.Teens[2].Item2);
            } else if (_words.Contains("TEN-THREE")) {
                _words = _words.Replace("TEN-THREE", numbersToWordsModel.Teens[3].Item2);
            } else if (_words.Contains("TEN-FOUR")) {
                _words = _words.Replace("TEN-FOUR", numbersToWordsModel.Teens[4].Item2);
            } else if (_words.Contains("TEN-FIVE")) {
                _words = _words.Replace("TEN-FIVE", numbersToWordsModel.Teens[5].Item2);
            } else if (_words.Contains("TEN-SIX")) {
                _words = _words.Replace("TEN-SIX", numbersToWordsModel.Teens[6].Item2);
            } else if (_words.Contains("TEN-SEVEN")) {
                _words = _words.Replace("TEN-SEVEN", numbersToWordsModel.Teens[7].Item2);
            } else if (_words.Contains("TEN-EIGHT")) {
                _words = _words.Replace("TEN-EIGHT", numbersToWordsModel.Teens[8].Item2);
            } else if (_words.Contains("TEN-NINE")) {
                _words = _words.Replace("TEN-NINE", numbersToWordsModel.Teens[9].Item2);
            }

            return _words;
        }
    }
    /// <summary>
    /// Holds the english words. These could have been stored in database with the language code.
    /// </summary>
    public class EnglishWordDetails {
        public IList<Tuple<int, string>> Ones { get; set; }

        public IList<Tuple<int, string>> Tens { get; set; }

        public IList<Tuple<int, string>> Teens { get; set; }

        public IList<Tuple<int, string>> Hundreds { get; set; }

        public EnglishWordDetails() {
            Ones = new List<Tuple<int, string>>();
            Ones.Add(new Tuple<int, string>(0, ""));
            Ones.Add(new Tuple<int, string>(1, "One"));
            Ones.Add(new Tuple<int, string>(2, "Two"));
            Ones.Add(new Tuple<int, string>(3, "Three"));
            Ones.Add(new Tuple<int, string>(4, "Four"));
            Ones.Add(new Tuple<int, string>(5, "Five"));
            Ones.Add(new Tuple<int, string>(6, "Six"));
            Ones.Add(new Tuple<int, string>(7, "Seven"));
            Ones.Add(new Tuple<int, string>(8, "Eight"));
            Ones.Add(new Tuple<int, string>(9, "Nine"));

            Teens = new List<Tuple<int, string>>();
            Teens.Add(new Tuple<int, string>(0, "Ten"));
            Teens.Add(new Tuple<int, string>(1, "Eleven"));
            Teens.Add(new Tuple<int, string>(2, "Twelve"));
            Teens.Add(new Tuple<int, string>(3, "Thirteen"));
            Teens.Add(new Tuple<int, string>(4, "Fourteen"));
            Teens.Add(new Tuple<int, string>(5, "Fifteen"));
            Teens.Add(new Tuple<int, string>(6, "Sixteen"));
            Teens.Add(new Tuple<int, string>(7, "Seventeen"));
            Teens.Add(new Tuple<int, string>(8, "Eighteen"));
            Teens.Add(new Tuple<int, string>(9, "Nineteen"));

            Tens = new List<Tuple<int, string>>();
            Tens.Add(new Tuple<int, string>(0, ""));
            Tens.Add(new Tuple<int, string>(1, "Ten"));
            Tens.Add(new Tuple<int, string>(2, "Twenty"));
            Tens.Add(new Tuple<int, string>(3, "Thirty"));
            Tens.Add(new Tuple<int, string>(4, "Forty"));
            Tens.Add(new Tuple<int, string>(5, "Fifty"));
            Tens.Add(new Tuple<int, string>(6, "Sixty"));
            Tens.Add(new Tuple<int, string>(7, "Seventy"));
            Tens.Add(new Tuple<int, string>(8, "Eighty"));
            Tens.Add(new Tuple<int, string>(9, "Ninety"));

            Hundreds = new List<Tuple<int, string>>();
            Hundreds.Add(new Tuple<int, string>(0, "hundred"));
            Hundreds.Add(new Tuple<int, string>(1, "thousand"));
            Hundreds.Add(new Tuple<int, string>(2, "million"));
        }
    }
}
