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
            _zipeCode = _zipeCode.Replace(".", "");
            _zipeCode = _zipeCode.Replace("-", "");
            _zipeCode = _zipeCode.Replace(" ", "");

            Regex Rgx = new Regex(@"^\d{8}$");
            if (!Rgx.IsMatch(_zipeCode))
                return false;

            return true;

        }
    }
}