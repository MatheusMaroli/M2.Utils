using System;
using M2.Utils.DataAnnotations;

namespace M2.Utils.ClassExtensions
{
    public static class StringExtension
    {
        public static T ParseToEnum<T>(this string value)
        {
           if (string.IsNullOrEmpty(value))
           {
                var enumAtual = typeof(T);
                var enumFields = enumAtual.GetFields();
                foreach (var propertyAtual in enumFields)
                {
                    var anotatiion = propertyAtual.GetCustomAttributes(typeof(IsDefaultValue), false); 
                    if (anotatiion != null && anotatiion.Length > 0)
                        return (T)Enum.Parse(typeof(T), propertyAtual.Name, true);
                }

                throw new  Exception("Value is not defined and not have IsDefaultValue Annotation or value no pattern enum type props.");
           }

            return (T)Enum.Parse(typeof(T), value, true);
        }

        
        public static bool ParseToBool(this string value)
        {
            bool _true = true;
            return (value == _true.ToString());
        }


        public static bool? ParseToBoolOrDefault(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;
            return value.ParseToBool();
        }
    }
}