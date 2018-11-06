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

using HashBrowns.Hashing.BaseClasses;
using HashBrowns.Hashing.Enums;
using System.Security.Cryptography;

namespace HashBrowns.Hashing
{
    /// <summary>
    /// MD5
    /// </summary>
    /// <seealso cref="HashBaseClass"/>
    public class MD5 : HashBaseClass
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public override string Name => HashingAlgorithms.MD5;

        /// <summary>
        /// Gets the hash algorithm.
        /// </summary>
        /// <returns>The hash algorithm to use</returns>
        protected override HashAlgorithm GetAlgorithm()
        {
            return new MD5CryptoServiceProvider();
        }
    }
}