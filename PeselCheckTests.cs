using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using projekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class PeselCheckTests
    {
        [Test]
        public void IsValid_CorrectPesel_ReturnsTrue()
        {
            // Arrange
            string correctPesel = "75121968629";

            // Act
            bool result = PeselCheck.IsValid(correctPesel);

            // Assert
            Assert.IsTrue(result);
        }


        [Test]
        public void IsValid_IncorrectCheckSum_ReturnsFalse()
        {
            // Arrange
            string incorrectPesel = "01234567890";

            // Act
            bool result = PeselCheck.IsValid(incorrectPesel);

            // Assert
            Assert.IsFalse(result);
        }

     
    }
}
