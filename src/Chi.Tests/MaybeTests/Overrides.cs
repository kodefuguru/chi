namespace Chi.MaybeTests
{
    using System;
    using MbUnit.Framework;

    /// <remarks>
    /// Equals override is covered by the Equality tests
    /// </remarks>
    public class Overrides
    {
        private readonly int value = 42;

        [Test, Description("When it has a value, maybe.ToString() should equal value.ToString()")]
        public void ValuedMaybeToString()
        {
            Maybe<int> maybe = value;
            Assert.AreEqual(value.ToString(), maybe.ToString());
        }

        [Test, Description("When it has a value, maybe.GetHashCode() should equal value.GetHashCode()")]
        public void ValuedMaybeGetHashCode()
        {
            Maybe<int> maybe = value;
            Assert.AreEqual(value.GetHashCode(), maybe.GetHashCode());
        }
        
        [Test, Description("When it is empty, maybe.ToString() should return an empty string")]
        public void EmptyMaybeToString()
        {
            Assert.AreEqual(String.Empty, Maybe<int>.Empty.ToString());
        }

        [Test, Description("When it is empty, maybe.GetHashCode() should return 0")]
        public void EmptyMaybeGetHashCode()
        {
            Assert.AreEqual(0, Maybe<int>.Empty.GetHashCode());
        }
    }
}