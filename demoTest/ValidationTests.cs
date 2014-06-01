using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpValidatorClient;
using System.Linq;

namespace demoTest
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void TestHomePageIsValid()
        {
            var validator = new HTMLValidate("http://www.visitorsweb.local/index.aspx", "http://validator.local/w3c-validator/");
            bool result = validator.Validate(HTMLValidate.emptyEncoding, HTMLValidate.emptyDoctype);

            if (!result)
            {
                var firstError = validator.Errors.First();
                Assert.Fail("Home Page validation error - first error was: {0} at line {1}",
                    firstError.message, firstError.line);
            }
        }

        [Ignore]
        [TestMethod]
        public void TestHomePageIsValidHTML_401_TRANSITIONAL()
        {
            var validator = new HTMLValidate("http://www.visitorsweb.local/index.aspx", "http://validator.local/w3c-validator/");
            bool result = validator.Validate(HTMLValidate.emptyEncoding, HTMLValidate.HTML_401_TRANSITIONAL);

            if (!result)
            {
                var firstError = validator.Errors.First();
                Assert.Fail("Home Page validation error - first error was: {0} at line {1}",
                    firstError.message, firstError.line);
            }
        }

        [TestMethod]
        public void TestHomePageIsValidHTML5()
        {
            var validator = new HTMLValidate("http://www.visitorsweb.local/index.aspx", "http://validator.local/w3c-validator/");
            bool result = validator.Validate(HTMLValidate.emptyEncoding, HTMLValidate.HTML5);

            if (!result)
            {
                var firstError = validator.Errors.First();
                Assert.Fail("Home Page validation error - first error was: {0} at line {1}",
                    firstError.message, firstError.line);
            }
        }

        [TestMethod]
        public void TestHomePageIsValidHTML5AndUTF8()
        {
            var validator = new HTMLValidate("http://www.visitorsweb.local/index.aspx", "http://validator.local/w3c-validator/");
            bool result = validator.Validate(HTMLValidate.UTF8, HTMLValidate.HTML5);

            if (!result)
            {
                var firstError = validator.Errors.First();
                Assert.Fail("Home Page validation error - first error was: {0} at line {1}",
                    firstError.message, firstError.line);
            }
        }

    }
}
