using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmountInWords.Utilities {
    public static class Logger {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void LogError(string message, Exception ex) {
            Log.Error(message, ex);
        }
    }
}
