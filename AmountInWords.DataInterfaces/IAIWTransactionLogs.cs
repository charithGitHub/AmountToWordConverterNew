using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmountInWords.DataModel;

namespace AmountInWords.DataInterfaces {
    public interface IAIWTransactionLogs : IDisposable {
        List<AIWTransactionLog> GetAIWTransactionLogs();
        AIWTransactionLog GetAIWTransactionLog(int id);
        int SaveAIWTransactionLog(AIWTransactionLog tFNTransactionLog);
        List<AIWTransactionLog> GetLatestTransactions(int secondsBefore, string requestedBy);
    }
}
