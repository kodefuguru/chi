namespace Chi.MaybeTests.LinqOperators
{
    using System;
    using MbUnit.Framework;

    public class SelectMany
    {
        private readonly int value = 42;
        private readonly int otherValue = 99;
        private readonly Func<int, int, string> selector = (x, y) => (x + y).ToString();
        private readonly Func<int, int, string> failOnExecute = (x, y) => 
        {
            Assert.Fail();
            return (x + y).ToString();
        };

        private TResult GetExpectedValueWithGuard<T, T2, TResult>(Func<T, T2, TResult> func, T left, T2 right)
        {
            var result = func(left, right);
            Assert.IsNotNull(result, "The selector must return a non-null value for the test to be valid.");
            return result;
        }

        private void AssertProjectedType<T, T2, TResult>(Func<T, T2, TResult> func, object maybe)
        {
            AssertProjectedType((T2 a) => func(default(T), a), maybe);
        }

        private void AssertProjectedType<T, TResult>(Func<T, TResult> func, object maybe)
        {
            Assert.IsNotNull(func, "The func parameter is solely used for generic inference. This assertion makes code analysis happy.");
            Assert.IsInstanceOfType<Maybe<TResult>>(maybe);
        }

        [Test, Description("SelectMany with a valued maybe and another valued maybe should return maybe with the mapped value")]
        public void ValuedMaybeAndValuedMaybe()
        {
            Maybe<int> maybe = value;
            Maybe<int> other = otherValue;
            Func<int, int, string> selector = (x, y) => (x + y).ToString();
            var expectedValue = selector(value, otherValue);
            var result = maybe.SelectMany(other, selector);

            Assert.IsNotNull(expectedValue, "selector result must not be null");
            Assert.IsInstanceOfType<Maybe<string>>(result);
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(expectedValue, result.Value);
        }

        [Test, Description("SelectMany with a valued maybe and an empty maybe should not execute the selector should return an empty maybe of selector's result type")]
        public void ValuedMaybeAndEmptyMaybe()
        {
            Maybe<int> maybe = value;
            Maybe<int> other = Maybe<int>.Empty;
            Func<int, int, string> selector = (x, y) =>
            {
                Assert.Fail();
                return "";
            };
            var result = maybe.SelectMany(other, selector);

            Assert.IsInstanceOfType<Maybe<string>>(result);
            Assert.IsFalse(result.HasValue);
        }

        [Test, Description("SelectMany with an empty maybe and a valued maybe should not execute the selector should return an empty maybe of the selector's result type")]
        public void EmptyMaybeAndValuedMaybe()
        {
            var maybe = Maybe<int>.Empty;
            Maybe<int> other = otherValue;
            Func<int, int, string> selector = (x, y) =>
            {
                Assert.Fail();
                return "";
            };
            var result = maybe.SelectMany(other, selector);

            Assert.IsInstanceOfType<Maybe<string>>(result);
            Assert.IsFalse(result.HasValue);
        }

        [Test, Description("SelectMany with an empty maybe and another empty maybe should not execute the selector and should return an empty maybe of the selector's result type")]
        public void EmptyMaybeAndEmptyMaybe()
        {
            var maybe = Maybe<int>.Empty;
            var other = Maybe<int>.Empty;
            Func<int, int, string> selector = (x, y) =>
            {
                Assert.Fail();
                return "";
            };
            var result = maybe.SelectMany(other, selector);

            Assert.IsInstanceOfType<Maybe<string>>(result);
            Assert.IsFalse(result.HasValue);
        }
    }
}