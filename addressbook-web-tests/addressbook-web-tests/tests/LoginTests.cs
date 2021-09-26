using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentions()
        {
            app.Auth.Logout();
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentions()
        {
            app.Auth.Logout();
            Thread.Sleep(100);//если запускать абсолютно все тесты, без этого слипа последний ассерт в этом тесте упадёт, не нашел времени разобраться почему 
            AccountData account = new AccountData("admin", "123456");
            app.Auth.Login(account);
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
