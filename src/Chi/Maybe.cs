namespace Chi
{
    using System;

    public static class Maybe
    {
        public static Maybe<bool> Bool(string value)
        {
            bool result;
            return bool.TryParse(value, out result) ? result : Maybe<bool>.Empty;
        }

        public static Maybe<byte> Byte(string value)
        {
            byte result;
            return byte.TryParse(value, out result) ? result : Maybe<byte>.Empty;
        }

        public static Maybe<DateTime> DateTime(string value)
        {
            DateTime result;
            return System.DateTime.TryParse(value, out result) ? result : Maybe<DateTime>.Empty;
        }

        public static Maybe<decimal> Decimal(string value)
        {
            decimal result;
            return decimal.TryParse(value, out result) ? result : Maybe<decimal>.Empty;
        }

        public static Maybe<double> Double(string value)
        {
            double result;
            return double.TryParse(value, out result) ? result : Maybe<double>.Empty;
        }

        public static Maybe<TEnum> Enum<TEnum>(string value, bool ignoreCase = false) where TEnum : struct
        {
            TEnum result;
            return System.Enum.TryParse<TEnum>(value, ignoreCase, out result) ? result : Maybe<TEnum>.Empty;
        }

        public static Maybe<float> Float(string value)
        {
            float result;
            return float.TryParse(value, out result) ? result : Maybe<float>.Empty;
        }

        public static Maybe<Guid> Guid(string value)
        {
            Guid result;
            return System.Guid.TryParse(value, out result) ? result : Maybe<Guid>.Empty;
        }


        public static Maybe<int> Int(string value)
        {
            int result;
            return int.TryParse(value, out result) ? result : Maybe<int>.Empty;
        }

        public static Maybe<long> Long(string value)
        {
            long result;
            return long.TryParse(value, out result) ? result : Maybe<long>.Empty;
        }

        public static Maybe<short> Short(string value)
        {
            short result;
            return short.TryParse(value, out result) ? result : Maybe<short>.Empty;
        }

        public static Maybe<TimeSpan> TimeSpan(string value)
        {
            TimeSpan result;
            return System.TimeSpan.TryParse(value, out result) ? result : Maybe<TimeSpan>.Empty;
        }

        public static Maybe<T> Create<T>()
        {
            return Maybe<T>.Empty;
        }

        public static Maybe<T> Create<T>(T value)
        {
            return value;
        }

        public static Maybe<T> Create<T>(Maybe<T> maybe)
        {
            return maybe.HasValue ? maybe.Value : Maybe<T>.Empty;
        }
    }

    public struct Maybe<T> : IEquatable<Maybe<T>>, IEquatable<T>
    {
        public static Maybe<T> Empty
        {
            get { return new Maybe<T>(); }
        }

        private readonly T value;
        private readonly bool hasValue;

        public bool HasValue
        {
            get { return this.hasValue; }
        }

        public T Value
        {
            get
            {
                if (hasValue) return value;
                throw new InvalidOperationException();
            }
        }

        public Maybe(T value)
        {
            this.value = value;
            this.hasValue = value != null;
        }

        public bool Do(Action<T> action)
        {
            if (hasValue)
            { 
                action(value);
            }
            return hasValue;
        }

        public override string ToString()
        {
            return hasValue ? value.ToString() : String.Empty;
        }

        public Maybe<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            return hasValue ? selector(value) : Maybe<TResult>.Empty;
        }

        public Maybe<TResult> SelectMany<T2, TResult>(Maybe<T2> right, Func<T, T2, TResult> selector)
        {
            return right.hasValue ? SelectMany(right.value, selector) : Maybe<TResult>.Empty;
        }

        public Maybe<TResult> SelectMany<T2, TResult>(Func<T, Maybe<T2>> right, Func<T, T2, TResult> selector)
        {
            return hasValue ? SelectMany(right(value), selector) : Maybe<TResult>.Empty;
        }

        public Maybe<TResult> SelectMany<T2, TResult>(T2 right, Func<T, T2, TResult> selector)
        {
            return hasValue ? selector(value, right) : Maybe<TResult>.Empty;
        }

        public Maybe<T> Where(Func<T, bool> predicate)
        {
            if (hasValue && predicate(value))
            { 
                return value;
            }
            return Maybe<T>.Empty;
        }

        public override bool Equals(object obj)
        {
            if (obj is Maybe<T>) return this.Equals((Maybe<T>)obj);
            if (obj is T) return this.Equals((T)obj);
            return hasValue ? value.Equals(obj) : obj == null;
        }

        public bool Equals(Maybe<T> other)
        {
            return hasValue ? value.Equals(other.value) : !other.hasValue;
        }

        public bool Equals(T other)
        {
            return hasValue ? value.Equals(other) : other == null;
        }

        public override int GetHashCode()
        {
            return hasValue ? value.GetHashCode() : 0;
        }

        public static explicit operator T(Maybe<T> maybe)
        {
            return maybe.Value;
        }
        
        public static implicit operator Maybe<T>(T item)
        {
            return new Maybe<T>(item);
        }

        public static T operator |(Maybe<T> left, T right)
        {
            return left.HasValue ? left.Value : right;
        }

        public static Maybe<T> operator |(Maybe<T> left, Maybe<T> right)
        {
            return left.HasValue ? left : right;
        }
    }
}
