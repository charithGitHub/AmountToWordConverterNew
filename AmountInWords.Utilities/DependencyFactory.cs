using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmountInWords.Utilities {
    public class DependencyFactory {
        private static IUnityContainer _container;
               

        static DependencyFactory() {
            _container = new UnityContainer();
        }

        public static void AddItemtoContainer<TFrom, TTo>() where TTo : TFrom {
            _container.RegisterType<TFrom, TTo>();
        }

        public static T Resolve<T>(params object[] p) {
            T ret = default(T);

            if (_container.IsRegistered(typeof(T))) {
                ret = _container.Resolve<T>();
            }

            return ret;
        }
    }
}
