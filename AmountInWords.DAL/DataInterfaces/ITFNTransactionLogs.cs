using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFNValidator.DAL.DataModel;

namespace TFNValidator.DAL.DataInterfaces {
    public interface ITFNTransactionLogs : IDisposable {
        List<TFNTransactionLog> GetTFNTransactionLogs();
        TFNTransactionLog GetTFNTransactionLog(int id);
        int SaveTFNTransactionLog(TFNTransactionLog tFNTransactionLog);
        int DeleteTFNTransactionLog(int id);
    }
}
