using prep.matching;

namespace prep.collections
{
    public static class NegatingMatchCreationExtensions
    {
        public static IMatchA<ItemToMatch> equal_to<ItemToMatch, AttributeType>(this NegatingMatchCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, AttributeType value)
        {
            return extension_point.for_value_matcher(new EqualAnyMatch<AttributeType>(new[] {value}));
        }

        private static IMatchA<ItemToMatch> for_value_matcher<ItemToMatch, AttributeType>(this NegatingMatchCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, IMatchA<AttributeType> value_condition)
        {
            return new AttributeMatch<ItemToMatch, AttributeType>(extension_point.accessor, value_condition.not());
        }
    }
}