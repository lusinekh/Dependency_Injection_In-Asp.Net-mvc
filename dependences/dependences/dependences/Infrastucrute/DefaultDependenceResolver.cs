using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using dependences.Models;

namespace dependences.Infrastucrute
{
    public class DefaultDependenceResolver : IDependencyResolver
    {
        IKernel kernel;
        public DefaultDependenceResolver()
        {
            kernel = new StandardKernel();
            AddBind();
        }

        public void AddBind()
        {
            kernel.Bind<ITotalValueCalculator>().To<TotalValueCalculator>();
            kernel.Bind<IDiscount>().To<DefaultDiscount>();
            kernel.Bind<IDiscountSize>().To<DiscountSize>().WithPropertyValue("Size", 20m);
            kernel.Bind<IDiscount>().To<FlexiableDiscount>().WhenInjectedInto<TotalValueCalculator>();

        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}