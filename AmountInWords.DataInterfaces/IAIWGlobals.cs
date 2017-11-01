using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmountInWords.DataModel;

namespace AmountInWords.DataInterfaces
{
    public interface IAIWGlobals : IDisposable {
        AIWGlobals GetAIWGlobals(int id);
        int SaveAIWGlobals(int id, AIWGlobals tFNGlobals);
        int DeleteAIWGlobals(int id);
        List<AIWGlobals> GetAllAIWGlobals();
        string GetApplicationId();
    }
}
