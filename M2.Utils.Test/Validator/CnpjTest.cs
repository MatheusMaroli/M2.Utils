using System.Reflection;
using Xunit;

namespace M2.Utils.Test.Validator
{
    public class CnpjTest 
    {
        [Fact]
        public void Should_Be_CNPJ_Valid(){
            var cnpj  ="27.865.757/0001-02";
            var cnpjValidator = new M2.Utils.Validators.Cnpj(cnpj);
            Assert.True(cnpjValidator.IsValid());
        }


        [Fact]
        public void Should_Be_CNPJ_Invalid(){
            var cnpj  ="12.123.123/1234-12"; 
            var cnpjValidator = new M2.Utils.Validators.Cnpj(cnpj);
            var result = ! cnpjValidator.IsValid();
            Assert.True(result);
        }

        [Fact]
        public void Should_Mask_Cnpj(){
            var cnpj = "27865757000102";
            var resultExcept = "27.865.757/0001-02";
            Assert.Equal(resultExcept, M2.Utils.Validators.Cnpj.MountMask(cnpj));    
        }
    }
}