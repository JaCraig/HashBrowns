using BigBook;
using HashBrowns.Hashing.Enums;
using HashBrowns.Symmetric.Enums;
using HashBrowns.Tests.BaseClasses;
using Xunit;

namespace HashBrowns.Tests
{
    public class CryptoManagerTests : TestBaseClass
    {
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

        private readonly CryptoManager TestObject = Canister.Builder.Bootstrapper.Resolve<CryptoManager>();

        [Theory]
        [MemberData(nameof(SymmetricTestData))]
        public void CreateInitialVector(SymmetricAlgorithms algorithms, int keySize)
        {
            Assert.NotNull(TestObject.CreateRandomInitialVector(algorithms));
        }

        [Theory]
        [MemberData(nameof(SymmetricTestData))]
        public void CreateKey(SymmetricAlgorithms algorithms, int keySize)
        {
            Assert.NotNull(TestObject.CreateRandomKey(algorithms));
        }

        [Theory]
        [MemberData(nameof(SymmetricTestData))]
        public void Decrypt(SymmetricAlgorithms algorithms, int keySize)
        {
            var Key = TestObject.CreateRandomKey(algorithms);
            var IV = TestObject.CreateRandomInitialVector(algorithms);
            Assert.NotNull(TestObject.Decrypt(
                TestObject.Encrypt(
                    new byte[] { 0, 1, 2, 3, 4, 5 },
                    (byte[])Key.Clone(),
                    "Salt".ToByteArray(),
                    HashingAlgorithms.SHA512,
                    2,
                    IV,
                    keySize,
                    algorithms),
                (byte[])Key.Clone(),
                "Salt".ToByteArray(),
                HashingAlgorithms.SHA512,
                2,
                IV,
                keySize,
                algorithms));
        }

        [Theory]
        [MemberData(nameof(SymmetricTestData))]
        public void Encrypt(SymmetricAlgorithms algorithms, int keySize)
        {
            var Key = TestObject.CreateRandomKey(algorithms);
            var IV = TestObject.CreateRandomInitialVector(algorithms);
            Assert.NotNull(TestObject.Encrypt(
                    new byte[] { 0, 1, 2, 3, 4, 5 },
                    (byte[])Key.Clone(),
                    "Salt".ToByteArray(),
                    HashingAlgorithms.SHA512,
                    2,
                    IV,
                    keySize,
                    algorithms));
        }

        [Theory]
        [MemberData(nameof(HashTestData))]
        public void Hash(HashingAlgorithms algorithms)
        {
            Assert.NotNull(TestObject.Hash(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, algorithms));
        }
    }
}