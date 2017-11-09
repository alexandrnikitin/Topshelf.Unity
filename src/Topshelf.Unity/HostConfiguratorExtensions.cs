using Topshelf.HostConfigurators;
using Unity;

namespace Topshelf.Unity
{
    public static class HostConfiguratorExtensions
    {
        public static HostConfigurator UseUnityContainer(
            this HostConfigurator configurator, 
            IUnityContainer unityContainer)
        {
            configurator.AddConfigurator(new UnityHostBuilderConfigurator(unityContainer));
            return configurator;
        }
    }
}