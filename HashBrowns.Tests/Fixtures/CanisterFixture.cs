using Microsoft.Extensions.DependencyInjection;
using System;
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
                new ServiceCollection().AddCanisterModules(x => x.AddAssembly(typeof(CanisterFixture).Assembly)
                   .RegisterHashBrowns());
            }
        }

        public void Dispose()
        {
        }
    }
}