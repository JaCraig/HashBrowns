using BigBook;
using HashBrowns.Hashing.Enums;
using HashBrowns.Symmetric;
using HashBrowns.Symmetric.Interfaces;
using HashBrowns.Tests.BaseClasses;
using System;
using Xunit;

namespace HashBrowns.Tests.Symmetric
{
    public class SymmetricTests : TestBaseClass
    {
        protected override Type ObjectType { get; set; }

        public static readonly TheoryData<ISymmetric, int> TestData = new TheoryData<ISymmetric, int>
        {
            {new Aes(),256 },
            {new DES(),64 },
            {new RC2(),128 },
            {new Rijndael(),256 },
            {new TripleDES(),192 }
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void CreateInitialVector(ISymmetric testObject, int keySize)
        {
            Assert.NotNull(testObject.CreateInitialVector());
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void CreateKey(ISymmetric testObject, int keySize)
        {
            Assert.NotNull(testObject.CreateKey());
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Decrypt(ISymmetric testObject, int keySize)
        {
            var Key = testObject.CreateKey();
            var IV = testObject.CreateInitialVector();
            Assert.NotNull(testObject.Decrypt(
                testObject.Encrypt(
                    new byte[] { 0, 1, 2, 3, 4, 5 },
                    (byte[])Key.Clone(),
                    "Salt".ToByteArray(),
                    HashingAlgorithms.SHA512,
                    2,
                    IV,
                    keySize),
                (byte[])Key.Clone(),
                "Salt".ToByteArray(),
                HashingAlgorithms.SHA512,
                2,
                IV,
                keySize));
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Encrypt(ISymmetric testObject, int keySize)
        {
            Assert.NotNull(testObject.Encrypt(
                new byte[] { 0, 1, 2, 3, 4, 5 },
                testObject.CreateKey(),
                "Salt".ToByteArray(),
                HashingAlgorithms.SHA512,
                2,
                testObject.CreateInitialVector(),
                keySize));
        }
    }
}