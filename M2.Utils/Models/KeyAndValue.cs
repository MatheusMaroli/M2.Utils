using System;
using System.Collections.Generic;
using System.Text;

namespace M2.Utils.Models
{
    public class KeyAndValue
    {
        public string Key { get; set; }
        public object Value { get; set; }

        public KeyAndValue(string key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}
