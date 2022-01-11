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
using HashBrowns.Symmetric.Enums;
using System;
using System.Security.Cryptography;
using System.Text;

namespace HashBrowns
{
    /// <summary>
    /// Extension methods.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Decrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="key">The key.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="hashingAlgorithm">The hashing algorithm.</param>
        /// <param name="passwordIterations">The password iterations.</param>
        /// <param name="initialVector">The initial vector with a length of 16 bytes.</param>
        /// <param name="keySize">Size of the key. (64, 128, 192, 256, etc.)</param>
        /// <returns>The decrypted data.</returns>
        public static byte[] Decrypt(this byte[] data,
                    byte[] key,
                    byte[] salt,
                    HashingAlgorithms hashingAlgorithm,
                    int passwordIterations,
                    byte[] initialVector,
                    int keySize,
                    SymmetricAlgorithms algorithm)
        {
            if (data is null || string.IsNullOrEmpty(algorithm) || key is null)
                return Array.Empty<byte>();
            initialVector ??= Array.Empty<byte>();
            salt ??= Array.Empty<byte>();
            return Canister.Builder.Bootstrapper?.Resolve<CryptoManager>()?.Decrypt(
                data,
                key,
                salt,
                hashingAlgorithm,
                passwordIterations,
                initialVector,
                keySize,
                algorithm) ?? Array.Empty<byte>();
        }

        /// <summary>
        /// Decrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="key">The key.</param>
        /// <param name="initialVector">The initial vector with a length of 16 bytes.</param>
        /// <param name="keySize">Size of the key. (64, 128, 192, 256, etc.)</param>
        /// <param name="algorithm">The algorithm.</param>
        /// <returns>The decrypted data.</returns>
        public static byte[] Decrypt(this byte[] data,
                    PasswordDeriveBytes key,
                    byte[] initialVector,
                    int keySize,
                    SymmetricAlgorithms algorithm)
        {
            if (data is null || string.IsNullOrEmpty(algorithm) || key is null)
                return Array.Empty<byte>();
            initialVector ??= Array.Empty<byte>();
            return Canister.Builder.Bootstrapper?.Resolve<CryptoManager>()?.Decrypt(
                data,
                key,
                initialVector,
                keySize,
                algorithm) ?? Array.Empty<byte>();
        }

        /// <summary>
        /// Decrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="key">The key.</param>
        /// <param name="initialVector">The initial vector with a length of 16 bytes.</param>
        /// <param name="keySize">Size of the key. (64, 128, 192, 256, etc.)</param>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>The decrypted data.</returns>
        public static byte[] Decrypt(this string data,
                    PasswordDeriveBytes key,
                    byte[] initialVector,
                    int keySize,
                    SymmetricAlgorithms algorithm,
                    Encoding? encoding = null)
        {
            return data.ToByteArray(encoding)
                       .Decrypt(key, initialVector, keySize, algorithm);
        }

        /// <summary>
        /// Decrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="key">The key.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="hashingAlgorithm">The hashing algorithm.</param>
        /// <param name="passwordIterations">The password iterations.</param>
        /// <param name="initialVector">The initial vector with a length of 16 bytes.</param>
        /// <param name="keySize">Size of the key. (64, 128, 192, 256, etc.)</param>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="encoding">The encoding of the string (defaults to UTF8).</param>
        /// <returns>The decrypted data.</returns>
        public static byte[] Decrypt(this string data,
                    byte[] key,
                    byte[] salt,
                    HashingAlgorithms hashingAlgorithm,
                    int passwordIterations,
                    byte[] initialVector,
                    int keySize,
                    SymmetricAlgorithms algorithm,
                    Encoding? encoding = null)
        {
            return data.ToByteArray(encoding)
                       .Decrypt(key, salt, hashingAlgorithm, passwordIterations, initialVector, keySize, algorithm);
        }

        /// <summary>
        /// Encrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="key">The key.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="hashingAlgorithm">The hashing algorithm.</param>
        /// <param name="passwordIterations">The password iterations.</param>
        /// <param name="initialVector">The initial vector with a length of 16 bytes.</param>
        /// <param name="keySize">Size of the key. (64, 128, 192, 256, etc.)</param>
        /// <returns>The encrypted data.</returns>
        public static byte[] Encrypt(this byte[] data,
                    byte[] key,
                    byte[] salt,
                    HashingAlgorithms hashingAlgorithm,
                    int passwordIterations,
                    byte[] initialVector,
                    int keySize,
                    SymmetricAlgorithms algorithm)
        {
            if (data is null || string.IsNullOrEmpty(algorithm) || key is null)
                return Array.Empty<byte>();
            initialVector ??= Array.Empty<byte>();
            salt ??= Array.Empty<byte>();
            return Canister.Builder.Bootstrapper?.Resolve<CryptoManager>()?.Encrypt(
                data,
                key,
                salt,
                hashingAlgorithm,
                passwordIterations,
                initialVector,
                keySize,
                algorithm) ?? Array.Empty<byte>();
        }

        /// <summary>
        /// Encrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="key">The key.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="hashingAlgorithm">The hashing algorithm.</param>
        /// <param name="passwordIterations">The password iterations.</param>
        /// <param name="initialVector">The initial vector with a length of 16 bytes.</param>
        /// <param name="keySize">Size of the key. (64, 128, 192, 256, etc.)</param>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="encoding">The encoding of the string (defaults to UTF8).</param>
        /// <returns>The encrypted data.</returns>
        public static byte[] Encrypt(this string data,
                    byte[] key,
                    byte[] salt,
                    HashingAlgorithms hashingAlgorithm,
                    int passwordIterations,
                    byte[] initialVector,
                    int keySize,
                    SymmetricAlgorithms algorithm,
                    Encoding? encoding = null)
        {
            return data.ToByteArray(encoding)
                       .Encrypt(key, salt, hashingAlgorithm, passwordIterations, initialVector, keySize, algorithm);
        }

        /// <summary>
        /// Encrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="key">The key.</param>
        /// <param name="initialVector">The initial vector with a length of 16 bytes.</param>
        /// <param name="keySize">Size of the key. (64, 128, 192, 256, etc.)</param>
        /// <param name="algorithm">The algorithm.</param>
        /// <returns>The encrypted data.</returns>
        public static byte[] Encrypt(this byte[] data,
                    PasswordDeriveBytes key,
                    byte[] initialVector,
                    int keySize,
                    SymmetricAlgorithms algorithm)
        {
            if (data is null || string.IsNullOrEmpty(algorithm) || key is null)
                return Array.Empty<byte>();
            initialVector ??= Array.Empty<byte>();

            return Canister.Builder.Bootstrapper?.Resolve<CryptoManager>()?.Encrypt(
                data,
                key,
                initialVector,
                keySize,
                algorithm) ?? Array.Empty<byte>();
        }

        /// <summary>
        /// Encrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="key">The key.</param>
        /// <param name="initialVector">The initial vector with a length of 16 bytes.</param>
        /// <param name="keySize">Size of the key. (64, 128, 192, 256, etc.)</param>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="encoding">The encoding of the string (defaults to UTF8).</param>
        /// <returns>The encrypted data.</returns>
        public static byte[] Encrypt(this string data,
                    PasswordDeriveBytes key,
                    byte[] initialVector,
                    int keySize,
                    SymmetricAlgorithms algorithm,
                    Encoding? encoding = null)
        {
            return data.ToByteArray(encoding)
                       .Encrypt(key, initialVector, keySize, algorithm);
        }

        /// <summary>
        /// Hashes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="algorithm">The algorithm.</param>
        /// <returns>The hashed result.</returns>
        public static byte[] Hash(this byte[] data, HashingAlgorithms algorithm)
        {
            if (data is null || string.IsNullOrEmpty(algorithm))
                return Array.Empty<byte>();
            return Canister.Builder.Bootstrapper?.Resolve<CryptoManager>()?.Hash(data, algorithm) ?? Array.Empty<byte>();
        }

        /// <summary>
        /// Hashes the specified algorithm.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="encoding">The encoding of the text (defaults to UTF8).</param>
        /// <returns>The hashed result.</returns>
        public static byte[] Hash(this string data, HashingAlgorithms algorithm, Encoding? encoding = null)
        {
            if (string.IsNullOrEmpty(data) || string.IsNullOrEmpty(algorithm))
                return Array.Empty<byte>();
            return Canister.Builder.Bootstrapper?.Resolve<CryptoManager>()?.Hash(data.ToByteArray(encoding), algorithm) ?? Array.Empty<byte>();
        }
    }
}