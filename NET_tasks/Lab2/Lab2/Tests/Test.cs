using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3;

namespace DataTests
{
    [TestClass]
    public class StringCheckersTests
    {
        [TestMethod]
        public void CheckEmail()
        {
            Assert.AreEqual(true, EmailChecker.IsEmail("a@b.cc"));
            Assert.AreEqual(true, EmailChecker.IsEmail("yuri.gubanov@mail.ru"));
            Assert.AreEqual(true, EmailChecker.IsEmail("my@domain.info"));
            Assert.AreEqual(true, EmailChecker.IsEmail("_.1@mail.com"));
            Assert.AreEqual(true, EmailChecker.IsEmail("yurik@hermitage.museum"));
            Assert.AreEqual(false, EmailChecker.IsEmail("a..b@mail.ru"));
            Assert.AreEqual(false, EmailChecker.IsEmail("a.b@mail.longru"));
        }

        [TestMethod]
        public void CheckPostalCode()
        {
            Assert.AreEqual(true, PostalCodeChecker.IsPostalCode("650065"));
            Assert.AreEqual(true, PostalCodeChecker.IsPostalCode("83703-83728"));
            Assert.AreEqual(false, PostalCodeChecker.IsPostalCode("8370383728"));
        }

        [TestMethod]
        public void CheckPhone()
        {
            Assert.AreEqual(true, PhoneNumberChecker.IsPhoneNumber("+7(123)4567890"));
            Assert.AreEqual(true, PhoneNumberChecker.IsPhoneNumber("89876543210"));
            Assert.AreEqual(true, PhoneNumberChecker.IsPhoneNumber("123456"));
            Assert.AreEqual(true, PhoneNumberChecker.IsPhoneNumber("911"));
        }
    }
}
