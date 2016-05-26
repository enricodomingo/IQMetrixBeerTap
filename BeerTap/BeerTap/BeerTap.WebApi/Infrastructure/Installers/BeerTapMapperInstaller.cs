using System;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using IQ.Platform.Framework.Common.Mapping;
using IQ.Platform.Framework.WebApi.Services.Mapping;
using BeerTap.Facade;

namespace BeerTap.WebApi.Infrastructure.Installers
{
    public class BeerTapMapperInstaller : IWindsorInstaller
    {
        readonly Assembly _beerTapAssembly;
        public BeerTapMapperInstaller(Assembly beerTapAssembly)
        {
            if (beerTapAssembly == null)
                throw new ArgumentNullException("beerTapAssembly");
            _beerTapAssembly = beerTapAssembly;
        }
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var apiMappersAssemblyDesc = Classes.FromAssembly(_beerTapAssembly);

            container
                   .Register(apiMappersAssemblyDesc.BasedOn(typeof(IBeerTapService)).WithServiceAllInterfaces());
        }
    }
}