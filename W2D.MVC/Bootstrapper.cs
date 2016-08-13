using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using W2D.Service.Concrete;
using W2D.Service.Contracts;

namespace W2D.MVC
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();            
            container.RegisterType<IPersonService, PersonService>(); 

            return container;
        }
    }
}