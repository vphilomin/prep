using prep.matching;

namespace prep.collections
{
  public class Match<ItemForMatch>
  {
    public static AttributeAccessor<ItemForMatch, AttributeType> 
      with_attribute<AttributeType>(IGetTheValueOfAnAttribute<ItemForMatch, AttributeType> accessor)
    {
		return new AttributeAccessor<ItemForMatch, AttributeType>(accessor);
    }
  }

	public class AttributeAccessor<ItemToRetrieveAttributeFrom, AttributeType>
	{
		private IGetTheValueOfAnAttribute<ItemToRetrieveAttributeFrom, AttributeType> accessor;

		public AttributeAccessor(IGetTheValueOfAnAttribute<ItemToRetrieveAttributeFrom, AttributeType> accessor)
		{
			this.accessor = accessor;
		}

		public IMatchA<ItemToRetrieveAttributeFrom> equal_to(AttributeType value)
		{
			return new ConditionalSpecification<ItemToRetrieveAttributeFrom>(x => accessor(x).Equals(value));
		} 
	}

}