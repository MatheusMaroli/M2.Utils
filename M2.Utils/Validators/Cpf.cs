using System;

namespace M2.Utils.Validators
{
    public class Cpf
    {
        private string _cpf;

        public Cpf(string aCpf)
        {
             _cpf = aCpf;   
        }

        public bool IsValid()
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string temp_cpf;
            string digito;
            int soma;
            int resto;
            _cpf = _cpf.Trim();
            _cpf = _cpf.Replace(".", "").Replace("-", "");
            if (_cpf.Length != 11)
                return false;
            temp_cpf = _cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(temp_cpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            temp_cpf = temp_cpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(temp_cpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return _cpf.EndsWith(digito);
        }

        public static string MountMask(string aCpf)
        {
            return Convert.ToUInt64(aCpf).ToString(@"000\.000\.000\-00");
        }
    }
}