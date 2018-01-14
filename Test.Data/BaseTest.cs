using System;
using Data.Common.Contracts;
using Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Test.Data
{
    [TestClass]
    public abstract class BaseTest
    {
        protected IDataCommiter dataCommiter;
        protected ITemporaryInMemoryDataStore<Guid, User> userDataStore;
        protected ITemporaryInMemoryDataStore<Guid, Promotion> promotionDataStore;

        [TestInitialize]
        public void Init()
        {
            Container container = new Container();
            container.Options.DefaultLifestyle = Lifestyle.Singleton;

            IPackage[] packages = RegisterPackages();

            foreach (IPackage package in packages)
            {
                package.RegisterServices(container);
            }

            container.Verify();

            dataCommiter = container.GetInstance<IDataCommiter>();
            userDataStore = container.GetInstance<ITemporaryInMemoryDataStore<Guid, User>>();
            promotionDataStore = container.GetInstance<ITemporaryInMemoryDataStore<Guid, Promotion>>();
        }

        protected abstract IPackage[] RegisterPackages();
    }
}
