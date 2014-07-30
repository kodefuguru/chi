namespace Chi.MaybeTests
{
    using MbUnit.Framework;

    public class AllowingAndDenyingExecution
    {
        [Test, Description("Do should execute if maybe has a value")]
        public void Value()
        {
            Maybe<int> maybe = 42;
            var executed = false;
            maybe.Do(i => executed = true);
            Assert.IsTrue(executed);
        }

        [Test, Description("Do should not execute if maybe is empty")]
        public void Empty()
        {
            Maybe<int> maybe = Maybe<int>.Empty;
            var executed = false;
            maybe.Do(i => executed = true);
            Assert.IsFalse(executed);
        }
    }
}