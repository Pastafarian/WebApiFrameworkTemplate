using System;
using System.Linq;
using System.Reflection;
using SimpleInjector.Advanced;

namespace Api.IoC
{
    public class LeastGreedyConstructorBehavior : IConstructorResolutionBehavior
    {
        public ConstructorInfo GetConstructor(Type implementationType) => (
                from ctor in implementationType.GetConstructors()
                orderby ctor.GetParameters().Length
                select ctor)
            .First();
    }
}