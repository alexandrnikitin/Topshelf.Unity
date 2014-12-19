using System;

using Microsoft.Practices.Unity;

namespace Topshelf.Unity.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create your container
            var container = new UnityContainer();
            container.RegisterType<ISampleDependency, SampleDependency>();
            container.RegisterType<SampleService>();

            HostFactory.Run(c =>
            {
                // Pass it to Topshelf
                c.UseUnityContainer(container);

                c.Service<SampleService>(s =>
                {
                    // Let Topshelf use it
                    s.ConstructUsingUnityContainer();
                    s.WhenStarted((service, control) => service.Start());
                    s.WhenStopped((service, control) => service.Stop());
                });
            });

        }
    }

    public class SampleService
    {
        private readonly ISampleDependency _sample;

        public SampleService(ISampleDependency sample)
        {
            _sample = sample;
        }

        public bool Start()
        {
            Console.WriteLine("Sample Service Started.");
            Console.WriteLine("Sample Dependency: {0}", _sample);
            return _sample != null;
        }

        public bool Stop()
        {
            return _sample != null;
        }
    }

    public interface ISampleDependency
    {
    }

    public class SampleDependency : ISampleDependency
    {
    }

}
