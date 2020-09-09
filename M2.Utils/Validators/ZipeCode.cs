using System.Text.RegularExpressions;

namespace M2.Utils.Validators
{
    public class ZipeCode
    {

        private string _zipeCode;
        public ZipeCode(string aZipeCode)
        {
                _zipeCode = aZipeCode;
        }

        public bool IsValid()
        {
            var zipToValidate = _zipeCode.Replace(".", "");
            zipToValidate = zipToValidate.Replace("-", "");
            zipToValidate = zipToValidate.Replace(" ", "");

            if(zipToValidate == "00000000")     return false;

            Regex Rgx = new Regex(@"^\d{8}$");
            if (!Rgx.IsMatch(zipToValidate))
                return false;

            return true;

        }
    }
}