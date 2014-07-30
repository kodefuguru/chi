namespace Chi.MaybeTests
{
    using System;
    using MbUnit.Framework;

    public class Parsing
    {
        private readonly string validBool = true.ToString();
        private readonly string validByte = new Byte().ToString();
        private readonly string validDateTime = DateTime.Now.ToString();
        private readonly string validDecimal = new Decimal().ToString();
        private readonly string validDouble = new Double().ToString();
        private readonly string validEnum = new TestEnum().ToString();
        private readonly string validFloat = new float().ToString();
        private readonly string validGuid = Guid.NewGuid().ToString();
        private readonly string validInt = new int().ToString();
        private readonly string validLong = new long().ToString();
        private readonly string validShort = new short().ToString();
        private readonly string validTimeSpan = TimeSpan.FromMinutes(10).ToString();
        private readonly string invalid = "asdf";

        private enum TestEnum { One, Two, Three }

        [Test]
        public void ParseBoolValid()
        {
            var result = Maybe.Bool(validBool);
            Assert.IsTrue(result.HasValue);
        }

        [Test]
        public void ParseBoolInvalid()
        {
            var result = Maybe.Bool(invalid);
            Assert.IsFalse(result.HasValue);
        }


        [Test]
        public void ParseByteValid()
        {
            var result = Maybe.Byte(validByte);
            Assert.IsTrue(result.HasValue);
        }

        [Test]
        public void ParseByteInvalid()
        {
            var result = Maybe.Byte(invalid);
            Assert.IsFalse(result.HasValue);
        }

        [Test]
        public void ParseDateTimeValid()
        {
            var result = Maybe.DateTime(validDateTime);
            Assert.IsTrue(result.HasValue);
        }

        [Test]
        public void ParseDateTimeInvalid()
        {
            var result = Maybe.DateTime(invalid);
            Assert.IsFalse(result.HasValue);
        }


        [Test]
        public void ParseDecimalValid()
        {
            var result = Maybe.Decimal(validDecimal);
            Assert.IsTrue(result.HasValue);
        }

        [Test]
        public void ParseDecimalInvalid()
        {
            var result = Maybe.Decimal(invalid);
            Assert.IsFalse(result.HasValue);
        }

        [Test]
        public void ParseDoubleValid()
        {
            var result = Maybe.Double(validDouble);
            Assert.IsTrue(result.HasValue);
        }

        [Test]
        public void ParseDoubleInvalid()
        {
            var result = Maybe.Double(invalid);
            Assert.IsFalse(result.HasValue);
        }

        [Test]
        public void ParseEnumValid()
        {
            var result = Maybe.Enum<TestEnum>(validEnum);
            Assert.IsTrue(result.HasValue);
        }

        [Test]
        public void ParseEnumInvalid()
        {
            var result = Maybe.Enum<TestEnum>(invalid);
            Assert.IsFalse(result.HasValue);
        }

        [Test]
        public void ParseFloatValid()
        {
            var result = Maybe.Float(validFloat);
            Assert.IsTrue(result.HasValue);
        }

        [Test]
        public void ParseFloatInvalid()
        {
            var result = Maybe.Float(invalid);
            Assert.IsFalse(result.HasValue);
        }

        [Test]
        public void ParseGuidValid()
        {
            var result = Maybe.Guid(validGuid);
            Assert.IsTrue(result.HasValue);
        }

        [Test]
        public void ParseGuidInvalid()
        {
            var result = Maybe.Guid(invalid);
            Assert.IsFalse(result.HasValue);
        }

        [Test]
        public void ParseIntValid()
        {
            var result = Maybe.Int(validInt);
            Assert.IsTrue(result.HasValue);
        }

        [Test]
        public void ParseIntInvalid()
        {
            var result = Maybe.Int(invalid);
            Assert.IsFalse(result.HasValue);
        }

        [Test]
        public void ParseLongValid()
        {
            var result = Maybe.Long(validLong);
            Assert.IsTrue(result.HasValue);
        }

        [Test]
        public void ParseLongInvalid()
        {
            var result = Maybe.Long(invalid);
            Assert.IsFalse(result.HasValue);
        }

        [Test]
        public void ParseShortValid()
        {
            var result = Maybe.Short(validShort);
            Assert.IsTrue(result.HasValue);
        }

        [Test]
        public void ParseShortInvalid()
        {
            var result = Maybe.Short(invalid);
            Assert.IsFalse(result.HasValue);
        }

        [Test]
        public void ParseTimeSpanValid()
        {
            var result = Maybe.TimeSpan(validTimeSpan);
            Assert.IsTrue(result.HasValue);
        }

        [Test]
        public void ParseTimeSpanInvalid()
        {
            var result = Maybe.TimeSpan(invalid);
            Assert.IsFalse(result.HasValue);
        }
    }
}
