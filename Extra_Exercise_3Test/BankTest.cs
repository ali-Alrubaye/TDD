using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extra_Exercise_3;
using NUnit.Framework.Internal;
using NUnit.Framework;
using NSubstitute;

namespace Extra_Exercise_3Test
{
    [TestFixture]
    public class BankTest
    {
        private IAuditLogger _iAuditLogger;
        private Account _account;
        private Bank sut;
        [SetUp]
        public void SetUp()
        {
            _iAuditLogger = Substitute.For<IAuditLogger>();
            _account = new Account
            {
                Name = "Ali",
                Number = "1",
                Balance = 0
            };
            sut = new Bank(_iAuditLogger);
        }
        [Test]
        public void CanCreateBankAccount()
        {

            sut.CreateAccount(_account);
            var result = sut.GetAccount("1");
            Assert.AreEqual("Ali", result.Name);
            Assert.AreEqual("1", result.Number);
            Assert.AreEqual(0, result.Balance);
        }

        [Test]
        public void CanNotCreateDuplicateAccounts()
        {

            sut.CreateAccount(_account);
            Assert.Throws<DuplicateAccount>(() => sut.CreateAccount(_account));
        }

        [Test]
        public void WhenCreatingAnAccount_AMessageIsWrittenToTheAuditLog()
        {
            sut.CreateAccount(_account);
            _iAuditLogger.Received().AddMessage(Arg.Is<string>(a => a.Contains(_account.Name) && a.Contains(_account.Number)));
        }

        [Test]
        public void WhenCreatingAnValidAccount_OneMessageAreWrittenToTheAuditLog()
        {
            sut.CreateAccount(_account);
            _iAuditLogger.Received(1).AddMessage(Arg.Is<string>(s => s.Contains(_account.Number) && s.Contains(_account.Name)));
        }

        [Test]
        public void WhenCreatingAnInvalidAccount_TwoMessagesAreWrittenToTheAuditLog()
        {
            var a2 = new Account
            {
                Name = "Aveen",
                Number = "2",
                Balance = 0
            };
            sut.CreateAccount(_account);
            sut.CreateAccount(a2);

            _iAuditLogger.Received(2).AddMessage(Arg.Any<string>());

        }

        [Test]
        public void WhenCreatingAnInvalidAccount_AWarn12AndErro45MessageIsWrittenToAuditLog()
        {
            var a2 = new Account
            {
                Name = "Aveen",
                Number = "a",
                Balance = 0
            };
            Assert.Throws<InvalidAccount>(() => sut.CreateAccount(a2));
            _iAuditLogger.Received(2).AddMessage(Arg.Is<string>(s => s.Contains("Warn12:") || s.Contains("Error45:")));
        }

        [Test]
        public void VerifyThat_GetAuditLog_GetsTheLogFromTheAuditLogger()
        {
            _iAuditLogger.GetLog().Returns(new List<string>() { "string1", "string2" });

            var result = sut.GetAuditLog();

            Assert.AreEqual("string1", result[0]);
            Assert.AreEqual("string2", result[1]);

        }
    }
}
