using CarManiacs.Business.Data;
using CarManiacs.Business.Data.Contracts;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarManiacs.WebClient.App_Start.NinjectModules
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x => x.From("CarManiacs.Business.Models").SelectAllClasses().BindToSelf());
            this.Bind<ICarManiacsDbContext>().To<CarManiacsDbContext>().InRequestScope();
            this.Bind(typeof(IEfRepository<>)).To(typeof(EfRepository<>));
            Bind<IUnitOfWork>().To<EfUnitOfWork>();
        }
    }
}