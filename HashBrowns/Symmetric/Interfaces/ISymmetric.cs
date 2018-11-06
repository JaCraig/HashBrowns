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

using HashBrowns.Hashing.Enums;
using System.Security.Cryptography;

namespace HashBrowns.Symmetric.Interfaces
{
    /// <summary>
    /// Symmetric interface
    /// </summary>
    public interface ISymmetric
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; }

        /// <summary>
        /// Creates the initial vector.
        /// </summary>
        /// <returns>The initial vector.</returns>
        byte[] CreateInitialVector();

        /// <summary>
        /// Creates the key.
        /// </summary>
        /// <returns>The key.</returns>
        byte[] CreateKey();

        /// <summary>
        /// Decrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="key">The key.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="hashingAlgorithm">The hashing algorithm.</param>
        /// <param name="passwordIterations">The password iterations.</param>
        /// <param name="initialVector">The initial vector. 16 ASCII characters long.</param>
        /// <param name="keySize">
        /// Size of the key. Can be 64 (DES only), 128 (AES), 192 (AES and Triple DES), or 256 (AES)
        /// </param>
        /// <returns>The decrypted data.</returns>
        byte[] Decrypt(byte[] data, byte[] key, byte[] salt, HashingAlgorithms hashingAlgorithm, int passwordIterations, byte[] initialVector, int keySize);

        /// <summary>
        /// Decrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="key">The key.</param>
        /// <param name="keySize">
        /// Size of the key. Can be 64 (DES only), 128 (AES), 192 (AES and Triple DES), or 256 (AES)
        /// </param>
        /// <returns>The decrypted data.</returns>
        byte[] Decrypt(byte[] data, PasswordDeriveBytes key, byte[] initialVector, int keySize);

        /// <summary>
        /// Encrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="key">The key.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="hashingAlgorithm">The hashing algorithm.</param>
        /// <param name="passwordIterations">The password iterations.</param>
        /// <param name="initialVector">The initial vector. 16 ASCII characters long.</param>
        /// <param name="keySize">
        /// Size of the key. Can be 64 (DES only), 128 (AES), 192 (AES and Triple DES), or 256 (AES)
        /// </param>
        /// <returns>The encrypted data.</returns>
        byte[] Encrypt(byte[] data, byte[] key, byte[] salt, HashingAlgorithms hashingAlgorithm, int passwordIterations, byte[] initialVector, int keySize);

        /// <summary>
        /// Encrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="key">The key.</param>
        /// <param name="initialVector">The initial vector. 16 ASCII characters long.</param>
        /// <param name="keySize">
        /// Size of the key. Can be 64 (DES only), 128 (AES), 192 (AES and Triple DES), or 256 (AES)
        /// </param>
        /// <returns>The encrypted data.</returns>
        byte[] Encrypt(byte[] data, PasswordDeriveBytes key, byte[] initialVector, int keySize);
    }
}