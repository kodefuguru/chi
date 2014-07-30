namespace Chi.MaybeTests
{
    using MbUnit.Framework;

    public class Creation 
    {
        private readonly int value = 42;
        private readonly string obj = "42";

        private void AssertValue(Maybe<int> subject)
        {
            // First assertion must be true to compile.
            Assert.IsInstanceOfType<Maybe<int>>(subject);
            Assert.IsTrue(subject.HasValue);
            Assert.AreEqual(value, subject.Value);
        }

        private void AssertValue(Maybe<string> subject)
        {
            // First assertion must be true to compile.
            Assert.IsInstanceOfType<Maybe<string>>(subject);
            Assert.IsTrue(subject.HasValue);
            Assert.AreEqual(obj, subject.Value);
        }

        private void AssertEmpty(Maybe<int> subject)
        {
            // First assertion must be true to compile.
            Assert.IsInstanceOfType<Maybe<int>>(subject);
            Assert.IsFalse(subject.HasValue);
        }

        private void AssertEmpty(Maybe<string> subject)
        {
            // First assertion must be true to compile.
            Assert.IsInstanceOfType<Maybe<string>>(subject);
            Assert.IsFalse(subject.HasValue);
        }

        [Test, Description("Assigning a value should result in a maybe with that value")]
        public void AssignValue()
        {
            Maybe<int> result = value;
            AssertValue(result);
        }

        [Test, Description("Assigning null should result in an empty maybe")]
        public void AssignNull()
        {
            Maybe<string> result = null;
            AssertEmpty(result);
        }

        [Test, Description("The default maybe should be empty")]
        public void AssignDefault()
        {
            Maybe<int> result = default(Maybe<int>);
            AssertEmpty(result);
        }

        [Test, Description("Assigning a maybe should set variable to that maybe")]
        public void AssignMaybe()
        {
            Maybe<int> maybe = value;
            Maybe<int> result = maybe;
            AssertValue(result);
        }

        [Test, Description("Create with a value should return a maybe with that value")]
        public void CreateWithValue()
        {
            AssertValue(Maybe.Create(value));
        }

        [Test, Description("Create with a instance type value should return a maybe with that value")]
        public void CreateWithObject()
        {
            AssertValue(Maybe.Create(obj));
        }

        [Test, Description("Create without arguments should return an empty maybe ")]
        public void CreateWithoutArguments()
        {
            AssertEmpty(Maybe.Create<int>());
        }

        [Test, Description("Create with null should return an empty maybe")]
        public void CreateWithNull()
        {
            AssertEmpty(Maybe.Create<string>(null));
        }

        [Test, Description("Create with a valued maybe should return maybe of the same value")]
        public void CreateWithValuedMaybe()
        {
            var maybe = Maybe.Create(value);
            var result = Maybe.Create(maybe);
            AssertValue(result);
        }

        [Test, Description("Create with an empty maybe should return an empty maybe")]
        public void CreateWithEmptyMaybe()
        {
            var result = Maybe.Create(Maybe<int>.Empty);
            AssertEmpty(result);
        }

        [Test, Description("Instantiating maybe with a value should return a maybe with that value")]
        public void InstantiateWithValue()
        {
            AssertValue(new Maybe<int>(value));
        }

        [Test, Description("Instantiating without a value should return an empty maybe")]
        public void InstantiateWithoutValue()
        {
            AssertEmpty(new Maybe<int>());
        }

        [Test, Description("Instantiating with null should return an empty maybe")]
        public void InstantiateWithNull()
        {
            Maybe<string> result = new Maybe<string>(null);
            AssertEmpty(result);
        }

        [Test, Description("The Empty static property should be an empty maybe")]
        public void MaybeEmpty()
        {
            AssertEmpty(Maybe<int>.Empty);
        }
    }
}