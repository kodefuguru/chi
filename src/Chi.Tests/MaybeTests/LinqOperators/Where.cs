namespace Chi.MaybeTests.LinqOperators
{
    using MbUnit.Framework;

    public class Where
    {
        private readonly int value = 42;

        [Test, Description("Where with a valued maybe and a true predicate should return the valued maybe.")]
        public void ValuedMaybeAndTruePredicate()
        {
            Maybe<int> maybe = value;
            var result = maybe.Where(x => x == value);
            Assert.AreEqual(maybe, result);
        }

        [Test, Description("Where with a valued maybe and a false predicate should return an empty maybe.")]
        public void ValuedMaybeAndFalsePredicate()
        {
            Maybe<int> maybe = value;
            var result = maybe.Where(x => x != value);
            Assert.AreEqual(Maybe<int>.Empty, result);
        }

        [Test, Description("Where with a empty maybe should not execute the predicate and should return an empty maybe.")]
        public void EmptyMaybe()
        {
            var result = Maybe<int>.Empty.Where(x =>
            {
                Assert.Fail("predicate should not execute");
                return true;
            });

            Assert.AreEqual(Maybe<int>.Empty, result);
        }
    }
}