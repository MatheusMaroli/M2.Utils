using Xunit;
using M2.Utils.ClassExtensions;

namespace M2.Utils.Test.ClassExtensions
{
    public class BoolExtensionTest
    {
        [Fact]
        public void Should_Convert_A_True_Value(){
            var _true = true;
            var resultExpect = "True";
            var result = _true.ParseToString();
            Assert.Equal(resultExpect, result);
        }

        [Fact]
        public void Should_Convert_A_False_Value(){
            var _true = false;
            var resultExpect = "False";
            var result = _true.ParseToString();
            Assert.Equal(resultExpect, result);
        }
    }
}