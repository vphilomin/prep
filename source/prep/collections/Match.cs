using prep.matching;

namespace prep.collections
{
  public class Match<ItemForMatch>
  {
    public static IGetTheValueOfAnAttribute<ItemForMatch, AttributeType> 
      with_attribute<AttributeType>(IGetTheValueOfAnAttribute<ItemForMatch, AttributeType> accessor)
    {
      return accessor;
    }
  }

}