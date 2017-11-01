using System;
using System.Collections.Generic;
using System.Linq;
using TFNValidator.DAL.DataModel;
using TFNValidator.DAL.DataStore;
using TFNValidator.DAL.DataInterfaces;
using System.Data;

namespace TFNValidator.DAL.DataRepository {
    public class TFNTransactionLogsRepository : ITFNTransactionLogs, IDisposable {
        private TFNValidatorContext context;
        public TFNTransactionLogsRepository(TFNValidatorContext _context) {
            context = _context;
        }
        public int DeleteTFNTransactionLog(int id) {
            TFNTransactionLog tFNTransactionLog = context.TFNTransactionLogs.FirstOrDefault(t => t.TFNTransactionLog_ID == id);
            if (tFNTransactionLog == null) {
                return -1;
            }
            context.TFNTransactionLogs.Remove(tFNTransactionLog);
            return context.SaveChanges();
        }

        public TFNTransactionLog GetTFNTransactionLog(int id) {
            return context.TFNTransactionLogs.FirstOrDefault(t => t.TFNTransactionLog_ID == id);
        }

        public List<TFNTransactionLog> GetTFNTransactionLogs() {
            return context.TFNTransactionLogs.ToList();
        }

        public int SaveTFNTransactionLog(TFNTransactionLog tFNTransactionLog) {
            bool _newRow = false;
            if (tFNTransactionLog.TFNTransactionLog_ID == 0)
                _newRow = true;

            if (_newRow)
                context.TFNTransactionLogs.Add(tFNTransactionLog);
            else
                context.Entry(tFNTransactionLog).State = EntityState.Modified;

            return context.SaveChanges();
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
