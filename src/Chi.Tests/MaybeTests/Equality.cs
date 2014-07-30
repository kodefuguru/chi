namespace Chi.MaybeTests
{
    using MbUnit.Framework;

    public class Equality
    {
        private readonly int value = 42;
        private readonly int differentValue = 99;
        private readonly string obj = "asdf";

        [Test]
        public void MaybeWithValueShouldEqualValue()
        {
            Maybe<int> maybe = value;
            Assert.IsTrue(maybe.Equals(value));
        }

        [Test]
        public void MaybeWithValueShouldNotEqualObject()
        {
            Maybe<int> maybe = value;
            Assert.IsFalse(maybe.Equals(obj));
        }

        [Test]
        public void MaybeWithValueShouldNotEqualNull()
        {
            Maybe<int> maybe = value;
            Assert.IsFalse(maybe.Equals(null));
        }

        [Test]
        public void MaybeWithDifferentValueShouldNotEqualValue()
        {
            Maybe<int> maybe = differentValue;
            Assert.IsFalse(maybe.Equals(value));
        }

        [Test]
        public void EmptyMaybeShouldNotEqualValue()
        {
            Assert.IsFalse(Maybe<int>.Empty.Equals(value));
        }

        [Test]
        public void EmptyMaybeShouldNotEqualObject()
        {
            Assert.IsFalse(Maybe<int>.Empty.Equals(obj));
        }

        [Test]
        public void EmptyMaybeShouldEqualNull()
        {
            Assert.IsTrue(Maybe<int>.Empty.Equals(null));
        }
    }
}