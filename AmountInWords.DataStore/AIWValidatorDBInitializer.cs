using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmountInWords.DataStore {
    public class AmountInWordsDBInitializer : DropCreateDatabaseIfModelChanges<AmountInWordsContext> {
        protected override void Seed(AmountInWordsContext context) {

            var appId = context.AIWGlobals.Where(g => g.AppId == "APPTFN").FirstOrDefault();
            //Insert the default AppId
            if (appId == null) {
                context.AIWGlobals.Add(new DataModel.AIWGlobals() {
                    AppId = "APPAIW",
                    CreateBy = "SystemSeed",
                    CreateDate = DateTime.Now,
                    SysName = "Amount to Word Converter",
                    SysVersion = "Version 1.0",
                    Variable = "APPAIW",
                    TouchBy = "SystemSeed",
                    TouchDate = DateTime.Now
                });
            }
            base.Seed(context);
        }
    }
}
