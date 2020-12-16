using Beadando_sp2p8b;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestExample.Test
{
 
    
        public class SubscribeTestFixture
        {
            [Test,
            TestCase("pistike@probahu", false),
            TestCase("pistike.proba.hu", false),
            TestCase("pistike@gmail.com", true)
            ]
            public void TestValidateEmail(string email, bool expectedResult)
            {
            // Arrange
            var subscribe = new Subscribe();

            // Act
            var actualResult = subscribe.ValidateEmail(email);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            
            }
        }
    
}
