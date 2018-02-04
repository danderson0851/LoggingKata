using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LoggingKata.Test
{
    [TestFixture]
    public class TacoParserTestFixture
    {
        [Test]
        public void EmptyStringReturnsNull()
        {
            //Arrange

            var empty = "";
            var emptyStringTest = new TacoParser();

            //Act
            var valueReturned = emptyStringTest.Parse(empty);

            //Assert
            Assert.IsNull(valueReturned);
        }

        [Test]
        public void NullStringReturnsNull()
        {
            //Arrange

            const string  empty = null;
            var emptyStringTest = new TacoParser();

            //Act
            var valueReturned = emptyStringTest.Parse(empty);

            //Assert
            Assert.IsNull(valueReturned);
        }




        [Test]
        public void ShouldParseLine()
        {
            //Arrange
            var sampleData = "-84.677017,34.073638,Taco Bell Acwort";
            var sampleDataTest = new TacoParser();
            //Act
            var valueReturned = (sampleDataTest.Parse(sampleData));
            //Assert
            Assert.IsNotNull(valueReturned);
        }
    }
}

