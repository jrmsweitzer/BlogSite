using NUnit.Framework;
using Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSiteTests.Services
{
    [TestFixture]
    public class EncryptionServiceTests
    {
        [Test]
        public void BlankHashedPasswordTest()
        {
            var service = new EncryptionService();
            var hashedForEmpty = "";

            Assert.AreEqual(hashedForEmpty, service.CreateHash(""));
        }

    }
}
