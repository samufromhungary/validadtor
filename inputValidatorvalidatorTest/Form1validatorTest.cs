using Microsoft.VisualStudio.TestTools.UnitTesting;
using inputValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inputValidator
{
    [TestClass]
    public class validatorTest
    {
        [TestMethod()]
        public void fullValid()
        {
            Assert.IsTrue(Form1.ValidName("valid"));
            Assert.IsTrue(Form1.ValidMail("va@lid.com"));
            Assert.IsTrue(Form1.ValidNumber("(555) 555-1234"));
        }

        [TestMethod()]
        public void fullInvalid()
        {
            Assert.IsFalse(Form1.ValidMail("invalid"));
            Assert.IsFalse(Form1.ValidMail("inva@lid.toolongtld"));
            Assert.IsFalse(Form1.ValidMail("@invalid.com"));
            Assert.IsFalse(Form1.ValidName("not'a'valid'name"));
            Assert.IsFalse(Form1.ValidName("n0t4v4l1dn4m3"));
            Assert.IsFalse(Form1.ValidName("not a valid name"));
            Assert.IsFalse(Form1.ValidNumber("clearly not a valid number"));
            Assert.IsFalse(Form1.ValidNumber("(555) 555-12345"));
        }

    }
}
