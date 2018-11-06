using BigBook;
using HashBrowns.Hashing.Enums;
using HashBrowns.Registration;
using HashBrowns.Symmetric.Enums;
using System.Text;
using Xunit;

namespace HashBrowns.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Canister.Builder.CreateContainer(null).RegisterHashBrowns().Build();
            var Manager = Canister.Builder.Bootstrapper.Resolve<CryptoManager>();
            var InitialVector = Manager.CreateRandomInitialVector(SymmetricAlgorithms.Rijndael);
            var Key = Manager.CreateRandomKey(SymmetricAlgorithms.Rijndael);
            var FinalData = Manager.Encrypt("This is a test of the system. Hopefully very simple.".ToByteArray(), Key, "Kosher".ToByteArray(), HashingAlgorithms.SHA1, 2, InitialVector, 256, SymmetricAlgorithms.Rijndael);
            FinalData = Manager.Decrypt(FinalData, Key, "Kosher".ToByteArray(), HashingAlgorithms.SHA1, 2, InitialVector, 256, SymmetricAlgorithms.Rijndael);
            var Result = FinalData.ToString(Encoding.UTF8);
            Assert.Equal("This is a test of the system. Hopefully very simple.", Result);
        }
    }
}