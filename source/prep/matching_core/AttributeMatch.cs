namespace prep.matching_core
{
  public class AttributeMatch<ItemToMatch, AttributeType> : IMatchA<ItemToMatch>
  {
    IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> get_the_value;
    IMatchA<AttributeType> value_criteria;

    public AttributeMatch(IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> get_the_value,
      IMatchA<AttributeType> value_criteria)
    {
      this.get_the_value = get_the_value;
      this.value_criteria = value_criteria;
    }

    public bool matches(ItemToMatch item)
    {
      var value = get_the_value(item);
      return value_criteria.matches(value);
    }
  }
}