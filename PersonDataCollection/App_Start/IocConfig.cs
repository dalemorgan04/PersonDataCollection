using Autofac;
using Autofac.Integration.Mvc;
using PersonDataCollection.DAL;
using PersonDataCollection.Services;
using System.Data.Entity;
using System.Web.Mvc;

namespace PersonDataCollection.App_Start
{
    public class IocConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Services - Could setup a common pattern but only one service is needed in this demo
            builder.RegisterType<PersonService>()
                .As<IPersonService>()
                .SingleInstance();

            //Database
            builder.RegisterType<PersonContext>()
                .As<IContext>()
                .InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}