using System;
using prep.collections;
using prep.matching;
namespace prep.ranges
{
    public static class RangeFactory
    {
        public static IStartContain<AttributeType> start_from<AttributeType>(AttributeType start) where AttributeType : IComparable<AttributeType>
        {
            return new StartFromContain<AttributeType>(start);
        }

        public static IContainValues<AttributeType> ends_at<AttributeType>(this IStartContain<AttributeType> containValue, AttributeType end) where AttributeType : IComparable<AttributeType>
        {
            return new EndAtContain<AttributeType>(containValue, end);
        }

        public static IContainValues<AttributeType> ends_at<AttributeType>(AttributeType end) where AttributeType : IComparable<AttributeType>
        {
            return new EndAtContain<AttributeType>(end);
        }
    }

    public interface IStartContain<AttributeType> : IContainValues<AttributeType> where AttributeType : IComparable<AttributeType>
    {
        IStartContain<AttributeType> inclusive { get; }
    }

    internal class StartFromContain<AttributeType> : IContainValues<AttributeType>, IStartContain<AttributeType> where AttributeType : IComparable<AttributeType>
    {
        private IMatchA<AttributeType> matcher;
        private readonly IMatchA<AttributeType> equalTo;

        public StartFromContain(AttributeType start)
        {
            var accessor = Match<AttributeType>.with_attribute(any => any);
            equalTo = accessor.equal_to(start);
            matcher = accessor.greater_than(start);
        }
        public bool contains(AttributeType value)
        {
            return matcher.matches(value);
        }

        IContainValues<AttributeType> IContainValues<AttributeType>.inclusive
        {
            get { return inclusive; }
        }

        public IStartContain<AttributeType> inclusive
        {
            get
            {
                matcher = matcher.or(equalTo);
                return this;
            }
        }
    }
    internal class EndAtContain<AttributeType> : IContainValues<AttributeType> where AttributeType : IComparable<AttributeType>
    {
        private readonly IContainValues<AttributeType> containValue;
        private IMatchA<AttributeType> matcher;
        private readonly IMatchA<AttributeType> equalTo;

        public EndAtContain(IContainValues<AttributeType> containValue, AttributeType end)
        {
            this.containValue = containValue;
            var accessor = Match<AttributeType>.with_attribute(any => any);
            equalTo = accessor.equal_to(end);
            matcher = accessor.less_than(end);
        }

        public EndAtContain(AttributeType end)
            : this(new DummyContain(), end)
        {

        }

        class DummyContain : IContainValues<AttributeType>
        {
            public bool contains(AttributeType value)
            {
                return true;
            }

            public IContainValues<AttributeType> inclusive
            {
                get { throw new NotImplementedException(); }
            }
        }

        public bool contains(AttributeType value)
        {
            return containValue.contains(value) && matcher.matches(value);
        }
        public IContainValues<AttributeType> inclusive
        {
            get
            {
                matcher = matcher.or(equalTo);
                return this;
            }
        }
    }

}