using Xunit;

namespace M2.Utils.Test.Validator
{
    public class CpfTest
    {
        [Fact]
        public void Should_Be_Cpf_Valid(){
            var cpf = "10195080947";
            var resultExcept = true;
            var cpfValidator = new M2.Utils.Validators.Cpf(cpf);
            Assert.Equal(resultExcept, cpfValidator.IsValid());    
        }

        [Fact]
        public void Should_Be_Cpf_Invalid(){
            var cpf = "10195080900";
            var resultExcept = false;
            var cpfValidator = new M2.Utils.Validators.Cpf(cpf);
            Assert.Equal(resultExcept, cpfValidator.IsValid());    
        }

        [Fact]
        public void Should_Mask_Cfp(){
            var cpf = "10195080900";
            var resultExcept = "101.950.809-00";
            Assert.Equal(resultExcept, M2.Utils.Validators.Cpf.MountMask(cpf));    
        }

    }
}