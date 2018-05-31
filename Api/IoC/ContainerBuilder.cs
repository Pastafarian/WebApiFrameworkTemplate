using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Api.IoC
{
    public static class ContainerBuilder
    {
        public static Container BuildContainer()
        {
            return new Container
            {
                Options =
                {
                    DefaultLifestyle = Lifestyle.Scoped,
                    DefaultScopedLifestyle = new AsyncScopedLifestyle() ,
                    ConstructorResolutionBehavior = new LeastGreedyConstructorBehavior()
                }
            };
        }
    }
}
