using System.Reflection;
using Xunit;

namespace M2.Utils.Test.Validator
{
    public class ZipeCodeTest
    {
        [Fact]
        public void Should_Be_Zipe_Code_Valid()
        {
            var _zipeCode = "89825-000";
            var zipeCode = new M2.Utils.Validators.ZipeCode(_zipeCode);  
            Assert.True(zipeCode.IsValid())  ;
        }

        [Fact]
        public void Should_Be_Zipe_Code_Invalid(){
            var _zipeCode = "00000-000";
            var zipeCode = new M2.Utils.Validators.ZipeCode(_zipeCode);  
            Assert.True(! zipeCode.IsValid());
        }
    }
}