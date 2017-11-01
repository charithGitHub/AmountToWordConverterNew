using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmountInWords.DataModel;

namespace AmountInWords.BusinessContract
{
    public interface ITransactionLog
    {        
        int SaveTransaction(AIWTransactionLog currrentTransaction);
    }
}
