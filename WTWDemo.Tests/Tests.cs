
using System;
using NUnit.Framework;
using WTWDemo.DIModules;

namespace WTWDemo.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ShouldResolveObject()
        {
            var container = new Container();

            container.Register<ITypeToResolve, ConcreteType>();

            var instance = container.Resolve<ITypeToResolve>();

            Assert.That(instance, Is.InstanceOf<ConcreteType>());
        }

        [Test]
        public void ShouldThrowExceptionIfTypeNotRegistered()
        {
            var container = new Container();

            Exception exception = null;
            try
            {
                container.Resolve<ITypeToResolve>();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.That(exception, Is.InstanceOf<TypeNotRegisteredException>());
        }

        [Test]
        public void ShouldResolveObjectWithRegisteredConstructorParameters()
        {
            var container = new Container();

            container.Register<ITypeToResolve, ConcreteType>();
            container.Register<ITypeToResolveWithConstructorParams, ConcreteTypeWithConstructorParams>();

            var instance = container.Resolve<ITypeToResolveWithConstructorParams>();

            Assert.That(instance, Is.InstanceOf<ConcreteTypeWithConstructorParams>());
        }

        [Test]
        public void ShouldCreateTransientInstanceByDefault()
        {
            var container = new Container();

            container.Register<ITypeToResolve, ConcreteType>();

            var instance = container.Resolve<ITypeToResolve>();

            Assert.That(container.Resolve<ITypeToResolve>(), Is.Not.SameAs(instance));
        }

        [Test]
        public void CanCreateSingletonInstance()
        {
            var container = new Container();

            container.Register<ITypeToResolve, ConcreteType>(LifeCycle.Singleton);

            var instance = container.Resolve<ITypeToResolve>();

            Assert.That(container.Resolve<ITypeToResolve>(), Is.SameAs(instance));
        }

        [Test]
        public void CanCreateTransientInstance()
        {
            var container = new Container();

            container.Register<ITypeToResolve, ConcreteType>(LifeCycle.Transient);

            var instance = container.Resolve<ITypeToResolve>();

            Assert.That(container.Resolve<ITypeToResolve>(), Is.Not.SameAs(instance));
        }
    }

    public interface ITypeToResolve
    {
    }

    public class ConcreteType : ITypeToResolve
    {
    }

    public interface ITypeToResolveWithConstructorParams
    {
    }

    public class ConcreteTypeWithConstructorParams : ITypeToResolveWithConstructorParams
    {
        public ConcreteTypeWithConstructorParams(ITypeToResolve typeToResolve)
        {
        }
    }
}
