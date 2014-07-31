namespace Chi.MaybeTests
{
    using MbUnit.Framework;

    public class AllowingAndDenyingExecution
    {
        [Test, Description("Do should execute if maybe has a value and return the same maybe.")]
        public void Value()
        {
            Maybe<int> maybe = 42;
            var executed = false;
            var result = maybe.Do(i => executed = true);
            Assert.IsTrue(executed);
            Assert.AreEqual(maybe, result);
        }

        [Test, Description("Do should not execute if maybe is empty and return the same maybe.")]
        public void Empty()
        {
            Maybe<int> maybe = Maybe<int>.Empty;
            var executed = false;
            var result = maybe.Do(i => executed = true);
            Assert.IsFalse(executed);
            Assert.AreEqual(maybe, result);
        }
    }
}