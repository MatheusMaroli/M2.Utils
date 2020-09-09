using System.Security.Cryptography;
using System.Text;

namespace M2.Utils.Crypt
{
    public class Md5Crypt : ICrypt
    {
        private MD5 md5 = MD5.Create();
        private StringBuilder resultString = new StringBuilder();
        private byte[] byteCript;

        private void ConvertByteCriptToResultString()
        {
            for (var i = 0; i < byteCript.Length; i++)
                resultString.Append(byteCript[i].ToString());
        }

        private void ClearResultString()
        {
            resultString.Clear();
        }
        public string Crypt(string str)
        {
           try
            {
                ClearResultString();
                byteCript = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                ConvertByteCriptToResultString();
                return resultString.ToString();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public string DeCrypt(string str)
        {
            throw new System.NotImplementedException();
        }
    }
}