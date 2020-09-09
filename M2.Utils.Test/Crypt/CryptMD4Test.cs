using M2.Utils.Crypt;
using Xunit;

namespace M2.Utils.Test.Crypt
{
    public class CryptMD4Test
    {
        [Fact]
        public void Should_Crypt_A_Value_And_Return_True()
        {
            const string valueToCrypt = "valueForCrypt";    
            const string valueExpected = "1269625422195213179552518142117665319216";
            var md5 = new Md5Crypt();
            var result  = md5.Crypt(valueToCrypt);
            System.Console.WriteLine(result);
            Assert.Equal(valueExpected, result);
        }
    }
}