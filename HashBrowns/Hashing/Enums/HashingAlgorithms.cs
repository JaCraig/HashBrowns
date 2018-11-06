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

namespace HashBrowns.Hashing.Enums
{
    /// <summary>
    /// Hashing algorithms.
    /// </summary>
    /// <seealso cref="StringEnumBaseClass{HashingAlgorithms}"/>
    public class HashingAlgorithms : StringEnumBaseClass<HashingAlgorithms>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HashingAlgorithms"/> class.
        /// </summary>
        public HashingAlgorithms()
            : base("")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HashingAlgorithms"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public HashingAlgorithms(string name)
            : base(name)
        {
        }

        /// <summary>
        /// The hmacmd5
        /// </summary>
        public static HashingAlgorithms HMACMD5 = new HashingAlgorithms("HMACMD5");

        /// <summary>
        /// The hmacsha1
        /// </summary>
        public static HashingAlgorithms HMACSHA1 = new HashingAlgorithms("HMACSHA1");

        /// <summary>
        /// The hmacsha256
        /// </summary>
        public static HashingAlgorithms HMACSHA256 = new HashingAlgorithms("HMACSHA256");

        /// <summary>
        /// The hmacsha384
        /// </summary>
        public static HashingAlgorithms HMACSHA384 = new HashingAlgorithms("HMACSHA384");

        /// <summary>
        /// The hmacsha512
        /// </summary>
        public static HashingAlgorithms HMACSHA512 = new HashingAlgorithms("HMACSHA512");

        /// <summary>
        /// The MD5
        /// </summary>
        public static HashingAlgorithms MD5 = new HashingAlgorithms("MD5");

        /// <summary>
        /// Gets the sha1.
        /// </summary>
        public static HashingAlgorithms SHA1 = new HashingAlgorithms("SHA1");

        /// <summary>
        /// The sha256
        /// </summary>
        public static HashingAlgorithms SHA256 = new HashingAlgorithms("SHA256");

        /// <summary>
        /// The sha384
        /// </summary>
        public static HashingAlgorithms SHA384 = new HashingAlgorithms("SHA384");

        /// <summary>
        /// The sha512
        /// </summary>
        public static HashingAlgorithms SHA512 = new HashingAlgorithms("SHA512");
    }
}