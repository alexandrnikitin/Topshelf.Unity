Topshelf.Unity
================

Topshelf.Unity provides extensions to construct your service class from your Unity IoC container.

Install
-------
It's available via [nuget package](https://www.nuget.org/packages/topshelf.unity)  
PM> `Install-Package Topshelf.Unity`

Example Usage
-------------
```csharp
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
```
