using CarManiacs.Business.Data;
using CarManiacs.Business.Data.Contracts;

using Ninject.Extensions.Conventions;
using Ninject.Modules;
using Ninject.Web.Common;

namespace CarManiacs.WebClient.App_Start.NinjectModules
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x => x.From("CarManiacs.Business.Models").SelectAllClasses().BindToSelf());
            this.Bind(x => x.From("CarManiacs.Business.DTOs").SelectAllClasses().BindToSelf());

            this.Bind<ICarManiacsDbContext>().To<CarManiacsDbContext>().InRequestScope();
            this.Bind(typeof(IEfRepository<>)).To(typeof(EfRepository<>));
            this.Bind<IEfUnitOfWork>().To<EfUnitOfWork>();
        }
    }
}