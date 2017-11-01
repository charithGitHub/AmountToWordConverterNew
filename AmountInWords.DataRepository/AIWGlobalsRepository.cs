using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AmountInWords.DataModel;
using AmountInWords.DataStore;
using AmountInWords.DataInterfaces;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace AmountInWords.DataRepository {
    public class AIWGlobalsRepository : IAIWGlobals, IDisposable  {
        private AmountInWordsContext context;
        public AIWGlobalsRepository() {
            context = new AmountInWordsContext();
        }

        public int DeleteAIWGlobals(int id) {
            AIWGlobals tFNGlobals = context.AIWGlobals.FirstOrDefault(g => g.SysId == id);
            if (tFNGlobals == null) {
                return -1;
            }
            context.AIWGlobals.Remove(tFNGlobals);
            return context.SaveChanges();
        }

        public List<AIWGlobals> GetAllAIWGlobals() {
            return context.AIWGlobals.ToList();
        }

        public AIWGlobals GetAIWGlobals(int id) {
            return context.AIWGlobals.FirstOrDefault(g => g.SysId == id);
        }

        public int SaveAIWGlobals(int id, AIWGlobals aIWGlobals) {
            bool _newRow = false;
            if (aIWGlobals.SysId == 0)
                _newRow = true;

            if (_newRow)
                context.AIWGlobals.Add(aIWGlobals);          
            else
                context.Entry(aIWGlobals).State = EntityState.Modified;

            return context.SaveChanges();
        }

        public string GetApplicationId() {
            string appId = string.Empty;
            AIWGlobals _appGlobal =  context.AIWGlobals.Where(g => g.Variable == "APPAIW").FirstOrDefault();
            if (_appGlobal != null) {
                appId = _appGlobal.AppId;
            }
            return appId;
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
