using HashBrowns.Hashing;
using HashBrowns.Hashing.Interfaces;
using HashBrowns.Tests.BaseClasses;
using System;
using Xunit;

namespace HashBrowns.Tests.Hashing
{
    public class HashTests : TestBaseClass
    {
        protected override Type ObjectType { get; set; }

        public static readonly TheoryData<IHash> TestData = new TheoryData<IHash>
        {
            {new HMACMD5Hasher()},
            {new HMACSHA1Hasher()},
            {new HMACSHA256Hasher()},
            {new HMACSHA384Hasher()},
            {new HMACSHA512Hasher()},
            {new MD5()},
            {new SHA1()},
            {new SHA256()},
            {new SHA384()},
            {new SHA512()}
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void CreateInitialVector(IHash testObject)
        {
            Assert.NotNull(testObject.Hash(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));
        }
    }
}