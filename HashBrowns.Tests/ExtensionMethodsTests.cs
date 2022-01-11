using BigBook;
using HashBrowns.Hashing.Enums;
using HashBrowns.Symmetric.Enums;
using HashBrowns.Tests.BaseClasses;
using System;
using System.Text;
using Xunit;

namespace HashBrowns.Tests
{
    public class ExtensionMethodsTests : TestBaseClass
    {
        protected override Type ObjectType { get; set; } = typeof(ExtensionMethods);

        public static readonly TheoryData<HashingAlgorithms> HashTestData = new TheoryData<HashingAlgorithms>
        {
            {HashingAlgorithms.HMACMD5},
            {HashingAlgorithms.HMACSHA1},
            {HashingAlgorithms.HMACSHA256},
            {HashingAlgorithms.HMACSHA384},
            {HashingAlgorithms.HMACSHA512},
            {HashingAlgorithms.MD5},
            {HashingAlgorithms.SHA1},
            {HashingAlgorithms.SHA256},
            {HashingAlgorithms.SHA384},
            {HashingAlgorithms.SHA512},
        };

        public static readonly TheoryData<SymmetricAlgorithms, int> SymmetricTestData = new TheoryData<SymmetricAlgorithms, int>
        {
            {SymmetricAlgorithms.AES,256},
            {SymmetricAlgorithms.DES,64},
            {SymmetricAlgorithms.RC2,128},
            {SymmetricAlgorithms.Rijndael,256},
            {SymmetricAlgorithms.TripleDES,192},
        };

        [Theory]
        [MemberData(nameof(SymmetricTestData))]
        public void Decrypt(SymmetricAlgorithms algorithms, int keySize)
        {
            var Key = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var IV = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6 };
            Assert.Equal("Test String", "Test String".Encrypt((byte[])Key.Clone(),
                    "Salt".ToByteArray(),
                    HashingAlgorithms.SHA512,
                    2,
                    IV,
                    keySize,
                    algorithms)
                    .Decrypt((byte[])Key.Clone(),
                    "Salt".ToByteArray(),
                    HashingAlgorithms.SHA512,
                    2,
                    IV,
                    keySize,
                    algorithms).ToString(Encoding.UTF8));
        }

        [Theory]
        [MemberData(nameof(HashTestData))]
        public void Hash(HashingAlgorithms algorithms)
        {
            Assert.NotNull("Test String".Hash(algorithms));
        }
    }
}