namespace Chi.MaybeTests
{
    using MbUnit.Framework;

    public class QueryExpressions
    {
        private readonly Maybe<int> value = 42;
        private readonly Maybe<int> other = 99;
        private readonly Maybe<int> empty = Maybe<int>.Empty;

        [Test, Description("This expression with a valued maybe should return maybe with described value.")]
        public void FromOneValue()
        {
            var result = from x in value
                         select x + 1;

            var expectedValue = value.Value + 1;
            
            Assert.IsInstanceOfType<Maybe<int>>(result);
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(expectedValue, result.Value);
        }

        [Test, Description("This expression with an empty maybe should return empty maybe.")]
        public void FromOneEmpty()
        {
            var result = from x in empty
                         select x + 1;

            Assert.IsInstanceOfType<Maybe<int>>(result);
            Assert.IsFalse(result.HasValue);
        }

        [Test, Description("This expression with two valued maybes should return maybe with described value.")]
        public void FromValueAndValue()
        {
            var result = from x in value
                         from y in other
                         select x + y;
            var expectedValue = value.Value + other.Value;

            Assert.IsInstanceOfType<Maybe<int>>(result);
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(expectedValue, result.Value);
        }

        [Test, Description("This expression with a valued maybe and an empty maybe should return an empty maybe.")]
        public void FromValueAndEmpty()
        {
            var result = from x in value
                         from y in empty
                         select x + y;

            Assert.IsInstanceOfType<Maybe<int>>(result);
            Assert.IsFalse(result.HasValue);
        }

        [Test, Description("This expression with an empty maybe and a valued maybe should return an empty maybe.")]
        public void FromEmptyAndValue()
        {
            var result = from x in value
                         from y in empty
                         select x + y;

            Assert.IsInstanceOfType<Maybe<int>>(result);
            Assert.IsFalse(result.HasValue);
        }

        [Test, Description("This expression with an empty maybe and an empty maybe should return an empty maybe.")]
        public void FromEmptyAndEmpty()
        {
            var result = from x in value
                         from y in empty
                         select x + y;

            Assert.IsInstanceOfType<Maybe<int>>(result);
            Assert.IsFalse(result.HasValue);
        }

        [Test, Description("This expression with three valued maybes should return maybe with described value.")]
        public void FromTripleValues()
        {
            Maybe<int> third = 3;

            var result = from x in value
                         from y in other
                         from z in third
                         select x + y + z;

            var expectedValue = value.Value + other.Value + third.Value;

            Assert.IsInstanceOfType<Maybe<int>>(result);
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(expectedValue, result.Value);
        }

        [Test, Description("This expression with two valued maybes and one empty maybe should return an empty maybe.")]
        public void FromTwoValuesAndThirdEmpty()
        {
            Maybe<int> third = Maybe<int>.Empty;

            var result = from x in value
                         from y in other
                         from z in third
                         select x + y + z;

            Assert.IsInstanceOfType<Maybe<int>>(result);
            Assert.IsFalse(result.HasValue);
        }

        [Test, Description("This expression selects from a maybe with a value that does not pass the where filter. It should return an empty maybe.")]
        public void FromOneValueWhereFalse()
        {
            var result = from x in value
                         where x != value.Value
                         select x;

            Assert.IsInstanceOfType<Maybe<int>>(result);
            Assert.IsFalse(result.HasValue);
        }

        [Test, Description("This expression selects from a maybe with a value that passes the where filter. It should return a maybe with the described value.")]
        public void FromOneValueWhereTrue()
        {
            var result = from x in value
                         where x == value.Value
                         select x;

            Assert.IsInstanceOfType<Maybe<int>>(result);
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(value, result);
        }

        [Test, Description("This expression prevents division by zero. Since the denominator is 0, it should return an empty maybe.")]
        public void DivisionByZeroGuardAndValuesFail()
        {
            Maybe<int> numerator = 10;
            Maybe<int> denominator = 0;

            var result = from x in numerator
                         from y in denominator
                         where y != 0
                         select x / y;

            Assert.IsInstanceOfType<Maybe<int>>(result);
            Assert.IsFalse(result.HasValue);
        }

        [Test, Description("This expression prevents division by zero. Since the denominator is not 0, it should return a maybe with the described value.")]
        public void DivisionByZeroGuardAndValuesPass()
        {
            Maybe<int> numerator = 0;
            Maybe<int> denominator = 10;

            var result = from x in numerator
                         from y in denominator
                         where y != 0
                         select x / y;

            Assert.IsInstanceOfType<Maybe<int>>(result);
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(0, result.Value);
        }
    }
}