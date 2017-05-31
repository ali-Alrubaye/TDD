using NUnit.Framework;
using ValidationEngine;

namespace ValidationEngineTests
{
    [TestFixture]
    public class ValidationTests
    {
        [Test]
        public void TrueForValidAddress()
        {
            var sut = new Validator();
            
            Assert.IsTrue(sut.ValidateEmailAddress("mike@edument.se"));
            Assert.IsFalse(sut.ValidateEmailAddress("name@test"));
            Assert.IsTrue(sut.ValidateEmailAddress("name@test2015.com"));
        }

        [Test]
        public void MailHasADotBeforeReturnFalse()
        {
            var sut = new Validator();
            var r = sut.ValidateEmailAddress("test.test@com");
            Assert.IsFalse(r);
        }
        [Test]
        public void MailHasNummberInNameReturnFalse()
        {
            var sut = new Validator();
            var r = sut.ValidateEmailAddress("Name2015@test.com");
            Assert.IsTrue(r);
        }
        [Test]
        public void ThrowCustomException()
        {
            var sut = new Validator();
            //sut.ValidateEmailAddress("");
           Assert.Throws<InvalidContentsException>(() =>  sut.ValidateEmailAddress(""),"Exception not Throws");
            //Assert.Fail("Expected exception not thrown");
        }
    }
}
