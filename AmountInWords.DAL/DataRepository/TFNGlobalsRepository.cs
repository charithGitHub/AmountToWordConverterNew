using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TFNValidator.DAL.DataModel;
using TFNValidator.DAL.DataStore;
using TFNValidator.DAL.DataInterfaces;

namespace TFNValidator.DAL.DataRepository {
    public class TFNGlobalsRepository : ITFNGlobals, IDisposable  {
        private TFNValidatorContext context;
        public TFNGlobalsRepository(TFNValidatorContext _context) {
            context = _context;
        }

        public int DeleteTFNGlobals(int id) {
            TFNGlobals tFNGlobals = context.TFNGlobals.FirstOrDefault(g => g.SysId == id);
            if (tFNGlobals == null) {
                return -1;
            }
            context.TFNGlobals.Remove(tFNGlobals);
            return context.SaveChanges();
        }

        public List<TFNGlobals> GetAllTFNGlobals() {
            return context.TFNGlobals.ToList();
        }

        public TFNGlobals GetTFNGlobals(int id) {
            return context.TFNGlobals.FirstOrDefault(g => g.SysId == id);
        }

        public int SaveTFNGlobals(int id, TFNGlobals tFNGlobals) {
            bool _newRow = false;
            if (tFNGlobals.SysId == 0)
                _newRow = true;

            if (_newRow)
                context.TFNGlobals.Add(tFNGlobals);
            else
                context.Entry(tFNGlobals).State = EntityState.Modified;

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
