using Xunit;
using M2.Utils.ClassExtensions;
using M2.Utils.DataAnnotations;

namespace M2.Utils.Test.ClassExtensions
{
    public class StringExtensionTest
    {

        public enum Test {
            Test1, 
            Test2, 
            [IsDefaultValue]
            Test3
        }

        [Fact]
        public void Should_Convert_Enum_To_String_Value(){
            var _enum = "Test1";
            var resultExcept= Test.Test1;
            var result = _enum.ParseToEnum<Test>();
            Assert.Equal(resultExcept, result);

        }

        [Fact]
        public void Should_Convert_Enum_To_String_Default_Value ()
        {
            var _enum = "";
            var resultExcept= Test.Test3;
            var result = _enum.ParseToEnum<Test>();
            Assert.Equal(resultExcept, result);
        }

        [Fact]
        public void Should_Convert_String_To_Bool_True_Value()
        {
            var _true = "True";
            var resultExcept = true ;
            var result = _true.ParseToBool();
            Assert.Equal(resultExcept, result);
        }

        [Fact]
        public void Should_Convert_String_To_Bool_False_Value()
        {
            var _false = "False";
            var resultExcept = false ;
            var result = _false.ParseToBool();
            Assert.Equal(resultExcept, result);
        }

        [Fact]
        public void Should_Convert_String_To_Bool_Null_Value() 
        {
            var _null = "";
            bool? resultExcept = null ;
            var result = _null.ParseToBoolOrDefault();
            Assert.Equal(resultExcept, result);
        }
    }
}