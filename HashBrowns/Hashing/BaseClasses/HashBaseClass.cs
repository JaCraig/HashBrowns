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

using HashBrowns.Hashing.Interfaces;
using System;
using System.Security.Cryptography;

namespace HashBrowns.Hashing.BaseClasses
{
    /// <summary>
    /// Hash base class
    /// </summary>
    /// <seealso cref="IHash"/>
    public abstract class HashBaseClass : IHash
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public abstract string Name { get; }

        /// <summary>
        /// Hashes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>The hash of the data.</returns>
        public byte[] Hash(byte[] data)
        {
            using (HashAlgorithm Algorithm = GetAlgorithm())
            {
                if (Algorithm == null)
                    return Array.Empty<byte>();
                var Result = Algorithm.ComputeHash(data);
                Algorithm.Clear();
                return Result;
            }
        }

        /// <summary>
        /// Gets the hash algorithm.
        /// </summary>
        /// <returns>The hash algorithm to use</returns>
        protected abstract HashAlgorithm GetAlgorithm();
    }
}