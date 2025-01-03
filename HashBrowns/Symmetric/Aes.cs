﻿/*
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

using HashBrowns.Symmetric.BaseClasses;
using HashBrowns.Symmetric.Enums;
using System.Security.Cryptography;

namespace HashBrowns.Symmetric
{
    /// <summary>
    /// AES algorithm
    /// </summary>
    /// <seealso cref="SymmetricBaseClass"/>
    public class Aes : SymmetricBaseClass
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public override string Name => SymmetricAlgorithms.AES;

        /// <summary>
        /// Gets the algorithm.
        /// </summary>
        /// <returns>The algorithm to use.</returns>
        protected override SymmetricAlgorithm GetAlgorithm() => new AesManaged();
    }
}