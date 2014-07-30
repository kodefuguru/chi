namespace Chi.MaybeTests
{
    using MbUnit.Framework;

    public class Operators
    {
        private readonly int value = 42;
        private readonly int differentValue = 99;

        [Test, Description("Maybe with value or different value should return value.")]
        public void MaybeWithValueOrDifferentValue()
        {
            Maybe<int> maybe = value;
            var result = maybe | differentValue;
            Assert.IsInstanceOfType<int>(result);
            Assert.AreEqual(value, result);
        }

        [Test, Description("Maybe with value or maybe with different value should return maybe with value.")]
        public void MaybeWithValueOrMaybeWithDifferentValue()
        {
            Maybe<int> maybe = value;
            Maybe<int> differentMaybe = differentValue;
            var result = maybe | differentMaybe;
            Assert.IsInstanceOfType<Maybe<int>>(result);
            Assert.AreEqual(maybe, result);
        }

        [Test, Description("Maybe with value or empty maybe should return value.")]
        public void MaybeWithValueOrEmptyMaybe()
        {
            Maybe<int> maybe = value;
            var result = maybe | differentValue;
            Assert.IsInstanceOfType<int>(result);
            Assert.AreEqual(value, result);
        }

        [Test, Description("Empty maybe or value should return value.")]
        public void EmptyMaybeOrValue()
        {
            var result = Maybe<int>.Empty | value;
            Assert.IsInstanceOfType<int>(result);
            Assert.AreEqual(value, result);
        }

        [Test, Description("Empty maybe or empty maybe should return empty maybe.")]
        public void EmptyMaybeOrEmptyMaybe()
        {
            var result = Maybe<int>.Empty | Maybe<int>.Empty;
            Assert.IsInstanceOfType<Maybe<int>>(result);
            Assert.AreEqual(Maybe<int>.Empty, result);
        }
    }
}