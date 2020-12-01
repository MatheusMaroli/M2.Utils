using M2.Utils.DataAnnotations;
using M2.Utils.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace M2.Utils.ClassExtensions
{
    public static class EnumExtension 
    {

        

        public static Dictionary<string, string> EnumValueAndDescriptionToDictionary<T>() where T : Enum
        {
            var result = new Dictionary<string, string>();
            foreach (var t in Enum.GetValues(typeof(T)))
                result.Add(t.ToString(), EnumDescription.Get((Enum)t));
            return result;
        }

        public static IEnumerable<KeyValuePair<string, string>> EnumValueAndDescriptionToKeyValuePier<T>() where T : Enum
        {
            var result = new List<KeyValuePair<string, string>>();
            foreach (var t in Enum.GetValues(typeof(T)))
                result.Add(new KeyValuePair<string, string>(t.ToString(),  EnumDescription.Get((Enum)t) ));
            return result;
        }

        public static IEnumerable<KeyAndValue> EnumValueAndDescriptionToKeyAndValue<T>() where T : Enum
        {
            var result = new List<KeyAndValue>();
            foreach (var t in Enum.GetValues(typeof(T)))
                result.Add(new KeyAndValue(t.ToString(), EnumDescription.Get((Enum)t)));
            return result;
        }
    }
}
