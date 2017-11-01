using System.Data.Entity;
using TFNValidator.DAL.DataModel;
using TFNValidator.Utilities;


namespace TFNValidator.DAL.DataStore {
    public class TFNValidatorContext : DbContext {
        public TFNValidatorContext() : base(ConfigSettings.ConnectionString) {
        }

        public System.Data.Entity.DbSet<TFNGlobals> TFNGlobals { get; set; }

        public System.Data.Entity.DbSet<TFNTransactionLog> TFNTransactionLogs { get; set; }
    }
}
