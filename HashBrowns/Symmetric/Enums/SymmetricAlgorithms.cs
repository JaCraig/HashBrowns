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

using BigBook.Patterns.BaseClasses;

namespace HashBrowns.Symmetric.Enums
{
    /// <summary>
    /// Symmetric algorithms
    /// </summary>
    /// <seealso cref="StringEnumBaseClass{SymmetricAlgorithms}"/>
    public class SymmetricAlgorithms : StringEnumBaseClass<SymmetricAlgorithms>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricAlgorithms"/> class.
        /// </summary>
        public SymmetricAlgorithms()
            : base("")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricAlgorithms"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public SymmetricAlgorithms(string name)
            : base(name)
        {
        }

        /// <summary>
        /// The aes
        /// </summary>
        public static SymmetricAlgorithms AES = new SymmetricAlgorithms("AES");

        /// <summary>
        /// The DES
        /// </summary>
        public static SymmetricAlgorithms DES = new SymmetricAlgorithms("DES");

        /// <summary>
        /// The rc2
        /// </summary>
        public static SymmetricAlgorithms RC2 = new SymmetricAlgorithms("RC2");

        /// <summary>
        /// The rijndael
        /// </summary>
        public static SymmetricAlgorithms Rijndael = new SymmetricAlgorithms("RIJNDAEL");

        /// <summary>
        /// The triple DES
        /// </summary>
        public static SymmetricAlgorithms TripleDES = new SymmetricAlgorithms("TRIPLEDES");
    }
}