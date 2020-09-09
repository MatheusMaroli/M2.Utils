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
            string CNPJ = _cnpj.Replace(".", "");

      CNPJ = CNPJ.Replace("/", "");

      CNPJ = CNPJ.Replace("-", "");

 

      int[] digitos, soma, resultado;

      int nrDig;

      string ftmt;

      bool[] CNPJOk;

 

      ftmt = "6543298765432";

      digitos = new int[14];

      soma = new int[2];

      soma[0] = 0;

      soma[1] = 0;

      resultado = new int[2];

      resultado[0] = 0;

      resultado[1] = 0;

      CNPJOk = new bool[2];

      CNPJOk[0] = false;

      CNPJOk[1] = false;

 

      try

      {

          for (nrDig = 0; nrDig < 14; nrDig++)

            {

                digitos[nrDig] = int.Parse(

                    CNPJ.Substring(nrDig, 1));

                  if (nrDig <= 11)

soma[0] += (digitos[nrDig] *

  int.Parse(ftmt.Substring(

  nrDig + 1, 1)));

                  if (nrDig <= 12)

soma[1] += (digitos[nrDig] *

  int.Parse(ftmt.Substring(

  nrDig, 1)));

}

 

            for (nrDig = 0; nrDig < 2; nrDig++)

            {

                resultado[nrDig] = (soma[nrDig] % 11);

                  if ((resultado[nrDig] == 0) || (

                       resultado[nrDig] == 1))

                       CNPJOk[nrDig] = (

                       digitos[12 + nrDig] == 0);

                  else

CNPJOk[nrDig] = (

digitos[12 + nrDig] == (

11 - resultado[nrDig]));

            }

return (CNPJOk[0] && CNPJOk[1]);

}

      catch

      {

          return false;

      }
        }
/*
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
*/
        public static string MountMask(string aCnpj)
        {
            return System.Convert.ToUInt64(aCnpj).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}