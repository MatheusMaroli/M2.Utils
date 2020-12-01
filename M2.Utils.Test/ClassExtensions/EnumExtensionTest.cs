using M2.Utils.ClassExtensions;
using M2.Utils.DataAnnotations;
using System.Linq;
using Xunit;

namespace M2.Utils.Test.ClassExtensions
{

    public enum EnumTest
    {
        [EnumDescription("-")]
        None, 
        [EnumDescription("Value - 1")]
        Value1,
        [EnumDescription("Value - 2")]
        Value2
    }

    public class EnumExtensionTest
    {

        [Fact]
        public void Should_Get_Dictionary_With_All_Values_And_Description_Of_Enum_Test()
        {

            var descriptionsAndValues = EnumExtension.EnumValueAndDescriptionToDictionary<EnumTest>();
            var none = descriptionsAndValues.ContainsKey("None") && descriptionsAndValues.ContainsValue("-");
            var value1 = descriptionsAndValues.ContainsKey("Value1") && descriptionsAndValues.ContainsValue("Value - 1");
            var value2 = descriptionsAndValues.ContainsKey("Value2") && descriptionsAndValues.ContainsValue("Value - 2");
            
            Assert.True(none && value1 && value2);
        }

        [Fact]
        public void Should_Get_List_Key_Value_Pier_With_All_Values_And_Description_Of_Enum_Test()
        {

            var descriptionsAndValues = EnumExtension.EnumValueAndDescriptionToKeyValuePier<EnumTest>();
            var none = descriptionsAndValues.Any(f => f.Key == "None" && f.Value =="-");
            var value1 = descriptionsAndValues.Any(f => f.Key == "Value1" && f.Value == "Value - 1");
            var value2 = descriptionsAndValues.Any(f => f.Key == "Value2" && f.Value == "Value - 2");                  

            Assert.True(none && value1 && value2);
        }

        [Fact]
        public void Should_Get_List_Key_And_Value_With_All_Values_And_Description_Of_Enum_Test()
        {

            var descriptionsAndValues = EnumExtension.EnumValueAndDescriptionToKeyAndValue<EnumTest>();
            var none = descriptionsAndValues.Any(f => f.Key == "None" && f.Value.Equals("-"));
            var value1 = descriptionsAndValues.Any(f => f.Key == "Value1" && f.Value.Equals("Value - 1"));
            var value2 = descriptionsAndValues.Any(f => f.Key == "Value2" && f.Value.Equals("Value - 2"));

            Assert.True(none && value1 && value2);
        }

        [Fact]
        public void Should_Get_Description_Of_None_Value_In_Enum_Test()
        {
            var _enum = EnumTest.None;
            var descriptionNone = EnumDescription.Get(_enum);
            Assert.Equal("-", descriptionNone);
        }
    }
}
