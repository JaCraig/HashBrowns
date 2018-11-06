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
using HashBrowns.Hashing.Interfaces;
using HashBrowns.Symmetric.Enums;
using HashBrowns.Symmetric.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace HashBrowns
{
    /// <summary>
    /// Crypto manager
    /// </summary>
    public class CryptoManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CryptoManager"/> class.
        /// </summary>
        /// <param name="hashes">The hashes.</param>
        /// <param name="symmetrics">The symmetrics.</param>
        public CryptoManager(IEnumerable<IHash> hashes, IEnumerable<ISymmetric> symmetrics)
        {
            Hashes = hashes ?? Array.Empty<IHash>();
            Symmetrics = symmetrics ?? Array.Empty<ISymmetric>();
        }

        /// <summary>
        /// Gets the hashes.
        /// </summary>
        /// <value>The hashes.</value>
        public IEnumerable<IHash> Hashes { get; }

        /// <summary>
        /// Gets the symmetrics.
        /// </summary>
        /// <value>The symmetrics.</value>
        public IEnumerable<ISymmetric> Symmetrics { get; }

        /// <summary>
        /// Creates a PasswordDeriveBytes key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="hashingAlgorithm">The hashing algorithm.</param>
        /// <param name="passwordIterations">The password iterations.</param>
        /// <returns>The resulting key.</returns>
        public PasswordDeriveBytes CreateKey(byte[] key,
                    byte[] salt,
                    HashingAlgorithms hashingAlgorithm,
                    int passwordIterations)
        {
            return new PasswordDeriveBytes(key, salt, hashingAlgorithm, passwordIterations);
        }

        /// <summary>
        /// Creates the initial vector.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <returns>The initial vector.</returns>
        public byte[] CreateRandomInitialVector(SymmetricAlgorithms algorithm)
        {
            var SymmetricAlgorithm = Symmetrics.FirstOrDefault(x => string.Equals(x.Name, algorithm.ToString(), StringComparison.OrdinalIgnoreCase));
            if (SymmetricAlgorithm == null)
                return Array.Empty<byte>();
            return SymmetricAlgorithm.CreateInitialVector();
        }

        /// <summary>
        /// Creates a key.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <returns>The key</returns>
        public byte[] CreateRandomKey(SymmetricAlgorithms algorithm)
        {
            var SymmetricAlgorithm = Symmetrics.FirstOrDefault(x => string.Equals(x.Name, algorithm.ToString(), StringComparison.OrdinalIgnoreCase));
            if (SymmetricAlgorithm == null)
                return Array.Empty<byte>();
            return SymmetricAlgorithm.CreateKey();
        }

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
        public byte[] Decrypt(
                    byte[] data,
                    byte[] key,
                    byte[] salt,
                    HashingAlgorithms hashingAlgorithm,
                    int passwordIterations,
                    byte[] initialVector,
                    int keySize,
                    SymmetricAlgorithms algorithm)
        {
            var SymmetricAlgorithm = Symmetrics.FirstOrDefault(x => string.Equals(x.Name, algorithm.ToString(), StringComparison.OrdinalIgnoreCase));
            if (SymmetricAlgorithm == null)
                return Array.Empty<byte>();
            key = (byte[])key.Clone();
            return SymmetricAlgorithm.Decrypt(data, key, salt, hashingAlgorithm, passwordIterations, initialVector, keySize);
        }

        /// <summary>
        /// Decrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="key">The key.</param>
        /// <param name="initialVector">The initial vector. 16 ASCII characters long.</param>
        /// <param name="keySize">
        /// Size of the key. Can be 64 (DES only), 128 (AES), 192 (AES and Triple DES), or 256 (AES)
        /// </param>
        /// <param name="algorithm">The algorithm.</param>
        /// <returns>The decrypted data.</returns>
        public byte[] Decrypt(
                    byte[] data,
                    PasswordDeriveBytes key,
                    byte[] initialVector,
                    int keySize,
                    SymmetricAlgorithms algorithm)
        {
            var SymmetricAlgorithm = Symmetrics.FirstOrDefault(x => string.Equals(x.Name, algorithm.ToString(), StringComparison.OrdinalIgnoreCase));
            if (SymmetricAlgorithm == null)
                return Array.Empty<byte>();
            return SymmetricAlgorithm.Decrypt(data, key, initialVector, keySize);
        }

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
        public byte[] Encrypt(
                    byte[] data,
                    byte[] key,
                    byte[] salt,
                    HashingAlgorithms hashingAlgorithm,
                    int passwordIterations,
                    byte[] initialVector,
                    int keySize,
                    SymmetricAlgorithms algorithm)
        {
            var SymmetricAlgorithm = Symmetrics.FirstOrDefault(x => string.Equals(x.Name, algorithm.ToString(), StringComparison.OrdinalIgnoreCase));
            if (SymmetricAlgorithm == null)
                return Array.Empty<byte>();
            key = (byte[])key.Clone();
            return SymmetricAlgorithm.Encrypt(data, key, salt, hashingAlgorithm, passwordIterations, initialVector, keySize);
        }

        /// <summary>
        /// Encrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="key">The key.</param>
        /// <param name="initialVector">The initial vector. 16 ASCII characters long.</param>
        /// <param name="keySize">
        /// Size of the key. Can be 64 (DES only), 128 (AES), 192 (AES and Triple DES), or 256 (AES)
        /// </param>
        /// <param name="algorithm">The algorithm.</param>
        /// <returns>The encrypted data.</returns>
        public byte[] Encrypt(
                    byte[] data,
                    PasswordDeriveBytes key,
                    byte[] initialVector,
                    int keySize,
                    SymmetricAlgorithms algorithm)
        {
            var SymmetricAlgorithm = Symmetrics.FirstOrDefault(x => string.Equals(x.Name, algorithm.ToString(), StringComparison.OrdinalIgnoreCase));
            if (SymmetricAlgorithm == null)
                return Array.Empty<byte>();
            return SymmetricAlgorithm.Encrypt(data, key, initialVector, keySize);
        }

        /// <summary>
        /// Hashes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="algorithm">The algorithm to use.</param>
        /// <returns>The hash of the data.</returns>
        public byte[] Hash(byte[] data, HashingAlgorithms algorithm)
        {
            var HashingAlgorithm = Hashes.FirstOrDefault(x => string.Equals(x.Name, algorithm.ToString(), StringComparison.OrdinalIgnoreCase));
            if (HashingAlgorithm == null)
                return Array.Empty<byte>();
            return HashingAlgorithm.Hash(data);
        }
    }
}