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

using BigBook;
using HashBrowns.Hashing.Enums;
using HashBrowns.Symmetric.Interfaces;
using System;
using System.IO;
using System.Security.Cryptography;

namespace HashBrowns.Symmetric.BaseClasses
{
    /// <summary>
    /// Symmetric base class
    /// </summary>
    /// <seealso cref="ISymmetric"/>
    public abstract class SymmetricBaseClass : ISymmetric
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricBaseClass"/> class.
        /// </summary>
        protected SymmetricBaseClass()
        {
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public abstract string Name { get; }

        /// <summary>
        /// Creates the initial vector.
        /// </summary>
        /// <returns>The initial vector.</returns>
        public byte[] CreateInitialVector()
        {
            using var Algorithm = GetAlgorithm();
            Algorithm.GenerateIV();
            return Algorithm.IV;
        }

        /// <summary>
        /// Creates the key.
        /// </summary>
        /// <returns>The key.</returns>
        public byte[] CreateKey()
        {
            using var Algorithm = GetAlgorithm();
            Algorithm.GenerateKey();
            return (byte[])Algorithm.Key.Clone();
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
        public byte[] Decrypt(byte[] data, byte[] key, byte[] salt, HashingAlgorithms hashingAlgorithm, int passwordIterations, byte[] initialVector, int keySize)
        {
            if (data == null || key == null || salt == null || initialVector == null)
                return Array.Empty<byte>();
            using PasswordDeriveBytes TempKey = new PasswordDeriveBytes(key, salt, hashingAlgorithm.ToString(), passwordIterations);
            return Decrypt(data, TempKey, initialVector, keySize);
        }

        /// <summary>
        /// Decrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="key">The key.</param>
        /// <param name="keySize">
        /// Size of the key. Can be 64 (DES only), 128 (AES), 192 (AES and Triple DES), or 256 (AES)
        /// </param>
        /// <returns>The decrypted data.</returns>
        public byte[] Decrypt(byte[] data, PasswordDeriveBytes key, byte[] initialVector, int keySize)
        {
            using SymmetricAlgorithm SymmetricKey = GetAlgorithm();
            byte[] PlainTextBytes = Array.Empty<byte>();
            if (SymmetricKey != null)
            {
                SymmetricKey.Mode = CipherMode.CBC;
                using (ICryptoTransform Decryptor = SymmetricKey.CreateDecryptor(key.GetBytes(keySize / 8), initialVector))
                {
                    using MemoryStream MemStream = new MemoryStream(data);
                    using CryptoStream CryptoStream = new CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read);
                    PlainTextBytes = CryptoStream.ReadAllBinary();
                }
                SymmetricKey.Clear();
            }
            return PlainTextBytes;
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
        public byte[] Encrypt(byte[] data, byte[] key, byte[] salt, HashingAlgorithms hashingAlgorithm, int passwordIterations, byte[] initialVector, int keySize)
        {
            if (data == null || key == null || salt == null || initialVector == null)
                return Array.Empty<byte>();
            using PasswordDeriveBytes TempKey = new PasswordDeriveBytes(key, salt, hashingAlgorithm.ToString(), passwordIterations);
            return Encrypt(data, TempKey, initialVector, keySize);
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
        /// <returns>The encrypted data.</returns>
        public byte[] Encrypt(byte[] data, PasswordDeriveBytes key, byte[] initialVector, int keySize)
        {
            using SymmetricAlgorithm SymmetricKey = GetAlgorithm();
            byte[] CipherTextBytes = Array.Empty<byte>();
            if (SymmetricKey != null)
            {
                SymmetricKey.Mode = CipherMode.CBC;
                using (ICryptoTransform Encryptor = SymmetricKey.CreateEncryptor(key.GetBytes(keySize / 8), initialVector))
                {
                    using MemoryStream MemStream = new MemoryStream();
                    using CryptoStream CryptoStream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write);
                    CryptoStream.Write(data, 0, data.Length);
                    CryptoStream.FlushFinalBlock();
                    CipherTextBytes = MemStream.ToArray();
                }
                SymmetricKey.Clear();
            }
            return CipherTextBytes;
        }

        /// <summary>
        /// Gets the algorithm.
        /// </summary>
        /// <returns>The algorithm to use.</returns>
        protected abstract SymmetricAlgorithm GetAlgorithm();
    }
}