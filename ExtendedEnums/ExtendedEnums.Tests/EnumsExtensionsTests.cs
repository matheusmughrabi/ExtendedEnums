using ExtendedEnums.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ExtendedEnums.Tests
{
    public enum CountriesEnum
    {
        [System.ComponentModel.Description("Brazil")]
        Brazil = 1,
        [System.ComponentModel.Description("United States of America")]
        UnitedStates = 2,
        Canada = 3
    }

    [TestClass]
    public class EnumsExtensionsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ExtendedEnumsException), "Enum value cannot be null.")]
        public void ShouldReturnNull_WhenNullReferenceIsPassed()
        {
            Enum enumValue = null;
            var enumDescription = enumValue.ToDescription();
        }

        [TestMethod]
        public void ShouldReturnTheDescriptionOfTheEnumValue()
        {
            CountriesEnum unitedStates = CountriesEnum.UnitedStates;

            var unitedStatesDescription = unitedStates.ToDescription();

            Assert.AreEqual("United States of America", unitedStatesDescription);
        }

        [TestMethod]
        public void ShouldReturnTheDescriptionNull_WhenTheSpecifiedValueHasNoDescription()
        {
            CountriesEnum canada = CountriesEnum.Canada;
            var canadaDescription = canada.ToDescription();

            Assert.AreEqual("Canada", canadaDescription);
        }

        [TestMethod]
        public void ShouldReturnAllValuesOfTheEnum()
        {
            var values = EnumsExtensions.GetValues<CountriesEnum>();

            Assert.AreEqual(3, values.Count());
            Assert.AreEqual(CountriesEnum.Brazil, values.ToList()[0]);
            Assert.AreEqual(CountriesEnum.UnitedStates, values.ToList()[1]);
            Assert.AreEqual(CountriesEnum.Canada, values.ToList()[2]);
        }

        [TestMethod]
        public void ShouldReturnTrue_WhenDefinedEnumIsPassed()
        {
            var value = (CountriesEnum)3;
            var isDefined = value.IsDefined();
            Assert.IsTrue(isDefined);
        }

        [TestMethod]
        public void ShouldReturnFalse_WhenUndefinedEnumIsPassed()
        {
            var value = (CountriesEnum)4;
            var isDefined = value.IsDefined();
            Assert.IsFalse(isDefined);
        }

        [TestMethod]
        public void ShouldReturnEnumResult()
        {
            var value = CountriesEnum.UnitedStates;
            var enumResult = value.ConvertToEnumResult();

            Assert.AreEqual(2, enumResult.Value);
            Assert.AreEqual("United States of America", enumResult.Description);
        }

        [TestMethod]
        public void ShouldReturnEnumResult_WithToStringDescription_WhenUndefinedEnumIsPassed()
        {
            var undefinedValue = (CountriesEnum)4;

            var undefinedValueDescription = undefinedValue.ToDescription();

            Assert.AreEqual("4", undefinedValueDescription);
        }

        [TestMethod]
        public void ShouldReturnAllValuesAsEnumResult()
        {
            var allValues = EnumsExtensions.GetValuesAsEnumResult<CountriesEnum>();

            Assert.AreEqual(3, allValues.ToList().Count);
            Assert.AreEqual(1, allValues.ToList()[0].Value);
            Assert.AreEqual("Brazil", allValues.ToList()[0].Description);
            Assert.AreEqual(2, allValues.ToList()[1].Value);
            Assert.AreEqual("United States of America", allValues.ToList()[1].Description);
            Assert.AreEqual(3, allValues.ToList()[2].Value);
            Assert.AreEqual("Canada", allValues.ToList()[2].Description);
        }
    }
}