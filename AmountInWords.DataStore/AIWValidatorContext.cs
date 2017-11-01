using System.Data.Entity;
using AmountInWords.DataModel;
using AmountInWords.Utilities;


namespace AmountInWords.DataStore {
    public class AmountInWordsContext : DbContext {
        public AmountInWordsContext() : base(ConfigSettings.ConnectionString) {
            Database.SetInitializer(new AmountInWordsDBInitializer());
        }

        public System.Data.Entity.DbSet<AIWGlobals> AIWGlobals { get; set; }

        public System.Data.Entity.DbSet<AIWTransactionLog> AIWTransactionLogs { get; set; }
    }
}
