using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmountInWords.DataRepository;
using AmountInWords.DataModel;
using AmountInWords.DataInterfaces;
using AmountInWords.BusinessContract;
using AmountInWords.Utilities;

namespace AmountInWords.BusinessImplementation
{
    public class TransactionLog : ITransactionLog
    {
        IAIWTransactionLogs _transactionLog;
        public TransactionLog() {
            _transactionLog = new AIWTransactionLogsRepository();
        }   
             
        /// <summary>
        /// Save transaction log for maintainence
        /// </summary>
        /// <param name="currrentTransaction">Transaction Details</param>
        /// <returns>saved transaction id</returns>
        public int SaveTransaction(AIWTransactionLog currrentTransaction) {
            if (currrentTransaction == null) {
                throw new Exception("Transaction details not found");
            }
            return _transactionLog.SaveAIWTransactionLog(currrentTransaction);
        }
        
    }
}
