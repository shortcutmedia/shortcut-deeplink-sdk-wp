using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shortcut.DeepLinking.Pcl;

namespace Test.ShortcutDeepLinkingPcl
{
    [TestClass]
    public class TestPcl
    {
        [TestMethod]
        public void RequestRegisterFirstOpen()
        {
            // arrange
            var session = new SCSession();
            var client = new SCServerRequestRegisterFirstOpen(session);

            // act
            var response = client.DoRequest();

            // assert
            Assert.IsNotNull(response);
            Assert.AreNotEqual(response, String.Empty);
            StringAssert.Contains(response, ":");
        }

        [TestMethod]
        public void RequestRegisterOpen()
        {
            // arrange
            var session = new SCSession("scdemo://shortcut.sc/demo/73734?sc_link_id=2cjog8");
            var client = new SCServerRequestRegisterOpen(session);

            // act
            var response = client.DoRequest();

            // assert
            Assert.IsNotNull(response);
            Assert.AreNotEqual(response, String.Empty);
            StringAssert.Contains(response, ":");
        }

        [TestMethod]
        public void RequestRegisterClose()
        {
            // arrange
            var session = new SCSession("scdemo://shortcut.sc/demo/73734?sc_link_id=2cjog8");
            var client = new SCServerRequestRegisterClose(session);

            // act
            var response = client.DoRequest();

            // assert
            Assert.IsNotNull(response);
            Assert.AreNotEqual(response, String.Empty);
            StringAssert.Contains(response, ":");
        }
    }
}
