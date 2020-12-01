using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace M2.Utils.DataAnnotations
{
    public class EnumDescription : Attribute
    {
        private string _description;

        public EnumDescription(string description)
        {
            _description = description;
        }

        public static string Get(Enum _enum)
        {
            Type type = _enum.GetType();
            MemberInfo[] memberInfo = type.GetMember(_enum.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attributes = memberInfo[0].GetCustomAttributes(typeof(EnumDescription), false);

                if (attributes != null && attributes.Length > 0)
                    return ((EnumDescription)attributes[0])._description;

            }
            return _enum.ToString();
        }
    }
}
