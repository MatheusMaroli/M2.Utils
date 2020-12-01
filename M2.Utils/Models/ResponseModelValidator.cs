using System.Collections.Generic;
using System.Linq;
using M2.Utils.Models;

namespace M2.Utils.Models
{
    public class ResponseModelValidator 
    {
        public IList<ErrorMessage> Errors {get; private set;} = new List<ErrorMessage>();

        public void SetError(string propertyName, string message)
        {
            Errors.Add(new ErrorMessage(){PropertyName = propertyName, Message = message});
        }

        public bool IsValid()
        {
            return Errors.Count <= 0;
        }


    }
}