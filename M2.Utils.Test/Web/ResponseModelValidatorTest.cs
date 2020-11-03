using M2.Utils.Web.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace M2.Utils.Test.Web
{
    public class ResponseModelValidatorTest
    {
        [Fact]
        public void  Should_Be_Set_A_Error()
        {
            var response = new ResponseModelValidator();
            response.SetError("Test", "Error Test");
            Assert.True(response.Errors.Count == 1);
        }

        [Fact]
        public void Should_Be_Valid_Response()
        {
            var response = new ResponseModelValidator();
            Assert.True(response.IsValid());
        }

        [Fact]
        public void Should_Be_Invalid_Response()
        {
            var response = new ResponseModelValidator();
            response.SetError("Test", "Error Test");
            Assert.True(! response.IsValid());
        }
    }
}
