using ECommerce.API.DataAccess;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.Configuration;

using System.Data.SqlClient;
using ECommerce.API.Models;
using NUnit.Framework.Internal;

namespace NUnit_Testing
{
    [TestFixture]
    public class Tests

    { 
          private DataAccess dataAccess;

            [SetUp]
            public void SetUp()
            {
                var configuration = new ConfigurationBuilder()
                    .AddInMemoryCollection(new Dictionary<string, string>
                    {
                   { "ConnectionStrings:DB", "Data Source=LAPTOP-FN225GT7\\SQLEXPRESS;Initial Catalog=EcommerceProject; TrustServerCertificate=true;Integrated Security=true;" },
                    { "Constants:DateFormat", "dd/MM/yyyy" }
                    })
                    .Build();

                dataAccess = new DataAccess(configuration);
            }

           
            [Test]
            public void GetActiveCartOfUser_ShouldReturnEmptyCartForNonExistentUser()
            {
                int userid = 100;
                Cart cart = dataAccess.GetActiveCartOfUser(userid);

                Assert.That(cart, Is.Not.Null);
                Assert.That(cart.Id, Is.EqualTo(0));
         
                Assert.That(cart.Ordered, Is.False);
                Assert.That(cart.OrderedOn, Is.EqualTo(""));
                Assert.That(cart.CartItems, Is.Empty);
            }
        [Test]
        public void GetAllPreviousCartsOfUser_ShouldReturnAllPreviousCartsOfUser()
        {
            // Arrange
            var userid = 1;

            // Act
            var result = dataAccess.GetAllPreviousCartsOfUser(userid);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Cart>>(result);
        }

        [Test]
        public void GetCart_ShouldReturnCartWithGivenId()
        {
            // Arrange
            var cartid = 1;

            // Act
            var result = dataAccess.GetCart(cartid);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Cart>(result);
        }


    }
    




        }
    








       
