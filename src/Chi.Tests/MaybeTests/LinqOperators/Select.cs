namespace Chi.MaybeTests.LinqOperators
{
    using System;
    using MbUnit.Framework;

    public class Select
    {
        private readonly int value = 42;

        [Test, Description("Select with valued maybe should return a maybe with the mapped value")]
        public void ValuedMaybe()
        {
            Maybe<int> maybe = value;
            Func<int, string> selector = x => (x + 1).ToString();
            var expectedValue = selector(value);
            var result = maybe.Select(selector);

            Assert.IsNotNull(expectedValue, "selector result must not be null");
            Assert.IsInstanceOfType<Maybe<string>>(result);
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(expectedValue, result.Value);
        }


        [Test, Description("Select with empty maybe should not execute the selector and should return an empty maybe of the selector's result type")]
        public void EmptyMaybe()
        {
            Func<int, string> selector = x =>
            {
                Assert.Fail("selector should not execute on an empty maybe");
                return (x + 1).ToString();
            };
            var result = Maybe<int>.Empty.Select(selector);

            Assert.IsInstanceOfType<Maybe<string>>(result);
            Assert.IsFalse(result.HasValue);
        }
    }
}