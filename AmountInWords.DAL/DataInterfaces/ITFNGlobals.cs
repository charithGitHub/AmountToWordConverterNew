using System;
using System.Collections.Generic;
using TFNValidator.DAL.DataModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFNValidator.DAL.DataInterfaces {
    public interface ITFNGlobals :IDisposable {
        TFNGlobals GetTFNGlobals(int id);
        int SaveTFNGlobals(int id, TFNGlobals tFNGlobals);
        int DeleteTFNGlobals(int id);
        List<TFNGlobals> GetAllTFNGlobals();
    }
}
