using Hospital.DataAccessLayer;
using Hospital.DataAccessLayer.EF;
using Hospital.Model;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.DataAccessLayer.Dapper;

namespace Hospital.BusinessLogical
{
    /// <summary>
    /// Настраивает зависимости приложения.
    /// </summary>
    public class SimpleConfigModule : NinjectModule
    {
        /// <summary>
        /// Регистрирует реализацию репозитория врачей.
        /// </summary>
        public override void Load()
        {
            Bind<IRepository<Doctor>>().To<DapperRepository<Doctor>>().InSingletonScope();
        }
    }
}
