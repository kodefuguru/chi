# [Chi](http://kodefuguru.com/chi)

Types and extensions for declarative data transformations.

## Quick start

Install GlyphIcon by running the following command in Package Manager Console

    PM> Install-Package chi

## Types

### Maybe

Maybe&lt;T&gt; is an option type similar to Nullable&lt;T&gt;, and a Maybe&lt;T&gt; variable may or may not hold a value. Unlike Nullable&lt;T&gt;, Maybe&lt;T&gt; is without generic type restrictions, working with both value and reference types.

#### Coalescing

The null coalescing operator cannot be overridden, so Maybe&lt;T&gt; takes the JavaScript approach by using the `|` operator.

    int value = maybeA | maybeB | 0;

#### Parsing

Use the static parsing methods to safely convert strings. There's no need to specify `out` parameters or catch parsing exceptions.

    var result = Maybe.Int(str) | 1;

#### Fail-safe Chaining

You can use the LINQ operators implemented by Maybe&lt;T&gt; to chain functions together. If it loses its value in the course of execution, the remaining functions in the chain will not execute.

    Maybe<int> maybe = 1;
    var noneOrOdd = maybe.Select(x => x + liftedValue)
                         .Where(x => x % 2 == 0)
                         .Select(x => x + 1);

#### Query Expressions

The Query Expression syntax is available with maybe to create guarded expressions.

    var result = from x in maybeA
                 from y in maybeB
                 where y != 0
                 select x / y;

