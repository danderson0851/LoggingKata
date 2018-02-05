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
        public void TwoOfThreeShouldParse()
        {
            //Arrange
            var empty = "";
            var TwoOfThreeTest = new TacoParser();
            //Act
            var valueReturned = TwoOfThreeTest.Parse("-82.225,31.004");
            //Assert
            Assert.IsNull(valueReturned);
        }

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
        public void LatOrLongNotNumberReturnsNull()
        {
            //Arrange
            var invalidInputTest = new TacoParser();
            var invalidInput = "words here,-83.23423, name goes here";
            var moreInvalidInput = "-83.2342, words here, name goes here";
            //Act
            var failWithInvalidInput = invalidInputTest.Parse(invalidInput);
            var failWithOtherInvalidInput = invalidInputTest.Parse(moreInvalidInput);
            //Assert
            Assert.IsNull(failWithInvalidInput);
            Assert.IsNull(failWithOtherInvalidInput);

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

