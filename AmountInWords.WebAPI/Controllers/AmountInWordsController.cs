using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AmountInWords.WebAPI.Models;
using AmountInWords.Utilities;
using AmountInWords.BusinessContract;
using AmountInWords.DataModel;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace AmountInWords.WebAPI.Controllers
{
    
    public class AmountInWordsController : ApiController
    {



        /// <summary>
        /// Post Method to Convert number into Words
        /// </summary>
        /// <param name="amountDetails">Name, Amount, Ip Address of the user, AppId</param>
        /// <returns>ErrorCode, status and error message</returns>
        [HttpPost]
        public IHttpActionResult ConvertAmountToWords([FromBody]AmountDetails amountDetails) {
            AmountInWordDetails convertedAmount = new AmountInWordDetails();
            Regex regexName = new Regex(@"^[a-zA-Z\s-]+$");
            Regex regexNumber = new Regex(@"^[0-9,\.]+$");
            try {
                if (DependencyFactory.Resolve<IApplication>().IsValidApplication(amountDetails.AppCode)) {
                    if (amountDetails == null) {
                        throw new HttpRequestException(NotificationMessages.InValidRequest);
                    }

                    if (string.IsNullOrEmpty(amountDetails.Name) || string.IsNullOrEmpty(amountDetails.Amount)) {
                        throw new HttpRequestException(NotificationMessages.InValidRequest);
                    }

                    if (!regexName.IsMatch(amountDetails.Name)) {
                        throw new HttpRequestException(NotificationMessages.InValidName);
                    }

                    if (!regexNumber.IsMatch(amountDetails.Amount)) {
                        throw new HttpRequestException(NotificationMessages.InValidAmount);
                    }

                    convertedAmount.Words = DependencyFactory.Resolve<IAmountToWordsConverter>().AmountConverter(amountDetails.Amount);
                    convertedAmount.ValidationStatus = 1;
                }

                AIWTransactionLog transaction = new AIWTransactionLog() {
                    CreateBy = amountDetails.Requester,
                    CreateDate = DateTime.Now,
                    Amount = amountDetails.Amount,
                    Name = amountDetails.Name,
                    Words = convertedAmount.Words
                };
                DependencyFactory.Resolve<ITransactionLog>().SaveTransaction(transaction);

                convertedAmount.ErrorMessage = (convertedAmount.ValidationStatus == 1 ? NotificationMessages.ConversionSuccess : NotificationMessages.InValidAmount);
            } catch (Exception ex) {
                convertedAmount.ErrorMessage = NotificationMessages.SystemError;
                Logger.LogError(ex.Message, ex);
            }
            return Ok(convertedAmount);
        }
    }
}
