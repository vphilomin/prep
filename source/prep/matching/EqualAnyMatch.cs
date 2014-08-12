using System.Collections.Generic;
using prep.collections;

namespace prep.matching
{
  public class EqualAnyMatch<T> : IMatchA<T>
  {
    IList<T> values;

    public EqualAnyMatch(params T[] values)
    {
      this.values = new List<T>(values);
    }

    public bool matches(T item)
    {
      return values.Contains(item);
    }
  }

  public static class EqualAnyMatchExtensions
  {
    public static ReturnType equal_to_any<ItemToMatch, AttributeType, ReturnType>(
      this IProvideAccessToMatchCreationExtensions<ItemToMatch, AttributeType, ReturnType> extension_point,
      params AttributeType[] values)
    {
      return extension_point.create_dsl_result(new EqualAnyMatch<AttributeType>(values));
    }

    public static ReturnType equal_to<ItemToMatch, AttributeType, ReturnType>(
      this IProvideAccessToMatchCreationExtensions<ItemToMatch, AttributeType, ReturnType> extension_point,
      AttributeType value)
    {
      return extension_point.equal_to_any(value);
    }
  }
}