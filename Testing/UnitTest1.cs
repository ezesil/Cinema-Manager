using NUnit.Framework;
using BaseServices.Services;
using BaseServices.Domain;

namespace Testing
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var session = ServiceContainer.Get<SessionService>();

            var user = new User(
                new System.Guid(), 
                "admin", 
                "administrador", 
                "correo@correo.com", 
                "nombrecompleto", 
                "40000000");

            session.RegisterUser(user);
            Assert.Pass();
        }
    }
}