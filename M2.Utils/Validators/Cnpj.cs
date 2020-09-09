namespace M2.Utils.Validators
{
    public class Cnpj
    {
        public string _cnpj;
        public Cnpj(string aCnpj)
        {
            _cnpj =aCnpj;
        }

        public bool IsValid()
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma, resto;
            string digito, temp_cnpj;
            _cnpj = _cnpj.Trim();
            _cnpj = _cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (_cnpj.Length != 14)
                return false;
            temp_cnpj = _cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(temp_cnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            temp_cnpj = temp_cnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(temp_cnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            return _cnpj.EndsWith(digito);
        }

        public static string MountMask(string aCnpj)
        {
            return System.Convert.ToUInt64(aCnpj).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}