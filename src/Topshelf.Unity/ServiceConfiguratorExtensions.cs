using Microsoft.Practices.Unity;

using Topshelf.ServiceConfigurators;

namespace Topshelf.Unity
{
    public static class ServiceConfiguratorExtensions
    {
        public static ServiceConfigurator<T> ConstructUsingUnityContainer<T>(this ServiceConfigurator<T> configurator)
            where T : class
        {
            configurator.ConstructUsing(serviceFactory => UnityHostBuilderConfigurator.UnityContainer.Resolve<T>());
            return configurator;
        }
    }
}