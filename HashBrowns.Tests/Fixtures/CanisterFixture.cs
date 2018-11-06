using HashBrowns.Registration;
using System;
using System.Reflection;
using Xunit;

namespace HashBrowns.Tests.Fixtures
{
    [CollectionDefinition("Canister collection")]
    public class CanisterCollection : ICollectionFixture<CanisterFixture>
    {
    }

    public class CanisterFixture : IDisposable
    {
        public CanisterFixture()
        {
            if (Canister.Builder.Bootstrapper == null)
            {
                Canister.Builder.CreateContainer(null, typeof(CanisterFixture).GetTypeInfo().Assembly)
                   .RegisterHashBrowns()
                   .Build();
            }
        }

        public void Dispose()
        {
        }
    }
}