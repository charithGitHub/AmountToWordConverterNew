using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmountInWords.DataModel;
using AmountInWords.DataRepository;
using AmountInWords.DataInterfaces;
using AmountInWords.BusinessContract;
using AmountInWords.Utilities;

namespace AmountInWords.BusinessImplementation {
    public class Application : IApplication {
        IAIWGlobals _applicationGloabals;
        
        public Application() {
            _applicationGloabals = new AIWGlobalsRepository();
        }

        public bool IsValidApplication(string appCode) {
            bool isValid = false;
            if (!string.IsNullOrEmpty(appCode) && appCode.Trim() == _applicationGloabals.GetApplicationId()) {
                isValid = true;
            }
            return isValid;
        }

        public void ResolveDependencies() {
            DependencyFactory.AddItemtoContainer<IApplication, Application>();
            DependencyFactory.AddItemtoContainer<ITransactionLog, TransactionLog>();
            DependencyFactory.AddItemtoContainer<IAmountToWordsConverter, AmountToWordsConverter>();

        }
    }
}
