using _27_11_23_asp.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void emailIsNull()
        {
            var contactService = new ContactService();
            var email = "";
            var result = contactService.IsEmailValide(email);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void emailIsValide()
        {
            var contactService = new ContactService();
            var email = "@";
            var result = contactService.IsEmailValide(email);
            Assert.IsTrue(result);
        }
    }
}