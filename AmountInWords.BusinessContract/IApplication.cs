using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmountInWords.BusinessContract {
    public interface IApplication {
        bool IsValidApplication(string appCode);
        void ResolveDependencies();
    }
}
