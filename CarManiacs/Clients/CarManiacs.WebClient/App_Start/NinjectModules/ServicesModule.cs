using Ninject.Extensions.Conventions;
using Ninject.Modules;
using Ninject.Web.Common;

namespace CarManiacs.WebClient.App_Start.NinjectModules
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x =>
                x.From("CarManiacs.Business.Services")
                .SelectAllClasses()
                .BindDefaultInterface()
                .Configure(c => c.InRequestScope()));
        }
    }
}