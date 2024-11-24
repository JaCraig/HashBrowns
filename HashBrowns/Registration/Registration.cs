/*
Copyright 2018 James Craig

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using BigBook.Registration;
using Canister.Interfaces;
using HashBrowns;
using HashBrowns.Hashing.Interfaces;
using HashBrowns.Symmetric.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Registration extension methods
    /// </summary>
    public static class HashRegistration
    {
        /// <summary>
        /// Registers the library with the bootstrapper.
        /// </summary>
        /// <param name="bootstrapper">The bootstrapper.</param>
        /// <returns>The bootstrapper</returns>
        public static ICanisterConfiguration? RegisterHashBrowns(this ICanisterConfiguration? bootstrapper)
        {
            return bootstrapper?.AddAssembly(typeof(HashRegistration).Assembly)
                               .RegisterBigBookOfDataTypes();
        }

        /// <summary>
        /// Registers the HashBrowns services with the specified IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to add the services to.</param>
        /// <returns>The IServiceCollection with the registered services.</returns>
        public static IServiceCollection? RegisterHashBrowns(this IServiceCollection? services)
        {
            if (services.Exists<CryptoManager>())
                return services;
            return services?.AddAllTransient<IHash>()
                         ?.AddAllTransient<ISymmetric>()
                         ?.AddSingleton<CryptoManager>()
                         ?.RegisterBigBookOfDataTypes();
        }
    }
}