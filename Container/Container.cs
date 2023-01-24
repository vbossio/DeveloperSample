using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Linq;

namespace DeveloperSample.Container
{
    public class Container
    {
        ServiceCollection serviceCollection = new ServiceCollection();
        public void Bind(Type interfaceType, Type implementationType)
        {
            serviceCollection.AddSingleton(interfaceType, implementationType);
        }
    
        public T Get<T>()
        {
            var containerService = serviceCollection.Where(x => x.ServiceType == typeof(T)).SingleOrDefault();
            return (T)Activator.CreateInstance(containerService.ImplementationType);
        }
            
    }
}