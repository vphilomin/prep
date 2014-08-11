using System;
using prep.matching;

namespace prep.collections
{
	public class Match<ItemForMatch>
	{
		public static MatchForAttribute<ItemForMatch, AtrributeType> with_attribute<AtrributeType>(
			Func<ItemForMatch, AtrributeType> attributeGetter)
		{
			return new MatchForAttribute<ItemForMatch, AtrributeType>(attributeGetter);
		}
	}


	public delegate AtrributeType MatchForAttribute<in ItemForMatch, out AtrributeType>(ItemForMatch item);

	public static class MatchExtentions
	{
		public static IMatchA<ItemToMatch> equal_to<ItemToMatch, AtrributeType>(
			this MatchForAttribute<ItemToMatch, AtrributeType> attribute,
			AtrributeType value)
		{
			return new ConditionalSpecification<ItemToMatch>(m => object.Equals(m, value));
		}
	}
}