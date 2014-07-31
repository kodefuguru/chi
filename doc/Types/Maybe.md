### Maybe

Maybe&lt;T&gt; is an option type similar to Nullable&lt;T&gt;, and a Maybe&lt;T&gt;; variable may or may not hold a value. Unlike Nullable&lt;T&gt;, Maybe&lt;T&gt; is without generic type restrictions, working with both value and reference types.

#### Valued

Maybe&lt;T&gt; is an immutable value type, and its value can be assigned from an instance of T.

    Maybe&lt;int&gt; maybe = 42;
		
You may prefer to use a factory method to take advantage of generic inference.

    var maybe = Maybe.Create(42);

If a maybe has a value, its HasValue property is true, and its Value property returns the value.

	int val = maybe.HasValue ? maybe.Value : default(int);
	
#### Empty

Maybe&lt;T&gt; is an option type, so it may not have a value. Attempting to access the Value property when HasValue is false will throw an `InvalidOperationException`.

Using the default constructor or the `default` keyword creates an empty maybe.

	var empty = new Maybe&lt;int&gt;();
	var alsoEmpty = default(Maybe&lt;int&gt;);

Using the Empty static property is the recommended way to obtain an empty maybe.

    var maybe = Maybe&lt;int&gt;.Empty;
	
#### Coalescing

The null coalescing operator cannot be overridden, so Maybe&lt;T&gt; takes the JavaScript approach by using the `|` operator.

	int value = maybeA | maybeB | 0;

#### Parsing

Use the static parsing methods to safely convert strings. There's no need to specify `out` parameters or catch parsing exceptions. Success results in a valued maybe, and failure results in an empty maybe.

	var a = Maybe.Bool(str);
	var b = Maybe.Byte(str);
	var c = Maybe.DateTime(str);
	var d = Maybe.Decimal(str);
	var e = Maybe.Double(str);
	var f = Maybe.Enum&lt;EnumType&gt;(str);
	var g = Maybe.Float(str);
	var h = Maybe.Guid(str);
	var i = Maybe.Int(str);
	var j = Maybe.Long(str);
	var k = Maybe.Short(str);
	var k = Maybe.TimeSpan(str);

#### Fail-safe Chaining

You can use the LINQ operators implemented by Maybe&lt;T&gt; to chain functions together. The functions are only executed on valued maybes.

	Maybe&lt;int&gt; maybe = 1;
	var noneOrOdd = maybe.Select(x =&gt; x + liftedValue)
						 .Where(x =&gt; x % 2 == 0)
						 .Select(x =&gt; x + 1);
						 
If you need a chainable, LINQ-style operator to perform side-effects, use the `Do` method.

	var executed = false;
	var result = maybe.Where(x =&gt; x % 2 == 0)
					  .Do(x =&gt; executed = true)
					  .Select(x =&gt; x + 1);

#### Query Expressions

You can use query expressions to create guarded calculations.

	var result = from x in maybeA
				 from y in maybeB
				 where y != 0
				 select x / y;