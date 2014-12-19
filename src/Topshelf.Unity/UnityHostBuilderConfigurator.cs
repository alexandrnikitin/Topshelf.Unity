using System;
using System.Collections.Generic;

using Microsoft.Practices.Unity;

using Topshelf.Builders;
using Topshelf.Configurators;
using Topshelf.HostConfigurators;

namespace Topshelf.Unity
{
    public class UnityHostBuilderConfigurator : HostBuilderConfigurator
    {
        private static IUnityContainer unityContainer;

        public UnityHostBuilderConfigurator(IUnityContainer unityContainer)
        {
            if (unityContainer == null)
            {
                throw new ArgumentNullException("unityContainer");
            }

            UnityHostBuilderConfigurator.unityContainer = unityContainer;
        }

        public static IUnityContainer UnityContainer
        {
            get { return unityContainer; }
        }

        public HostBuilder Configure(HostBuilder builder)
        {
            return builder;
        }

        public IEnumerable<ValidateResult> Validate()
        {
            yield break;
        }
    }
}