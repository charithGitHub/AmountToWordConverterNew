using System;
using System.Collections.Generic;
using System.Linq;
using AmountInWords.DataModel;
using AmountInWords.DataStore;
using AmountInWords.DataInterfaces;
using System.Data;

namespace AmountInWords.DataRepository {
    public class AIWTransactionLogsRepository : IAIWTransactionLogs, IDisposable {
        private AmountInWordsContext context;
        public AIWTransactionLogsRepository() {
            context = new AmountInWordsContext();
        }        

        public AIWTransactionLog GetAIWTransactionLog(int id) {
            return context.AIWTransactionLogs.FirstOrDefault(t => t.TransactionLog_ID == id);
        }

        public List<AIWTransactionLog> GetAIWTransactionLogs() {
            return context.AIWTransactionLogs.ToList();
        }

        public int SaveAIWTransactionLog(AIWTransactionLog tFNTransactionLog) {
            bool _newRow = false;
            if (tFNTransactionLog.TransactionLog_ID == 0)
                _newRow = true;

            if (_newRow)
                context.AIWTransactionLogs.Add(tFNTransactionLog);
            else
                context.Entry(tFNTransactionLog).State = EntityState.Modified;

            return context.SaveChanges();
        }

        public List<AIWTransactionLog> GetLatestTransactions(int secondsBefore, string requestedBy) {
            DateTime from = DateTime.Now.AddSeconds(-secondsBefore);
            DateTime to = DateTime.Now;

            return context.AIWTransactionLogs.Where(t => t.CreateDate >= from && t.CreateDate < to && t.CreateBy == requestedBy).ToList();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
