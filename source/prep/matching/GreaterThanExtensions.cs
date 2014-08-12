using System;
using prep.collections;

namespace prep.matching
{
  public static class GreaterThanExtensions
  {
    public static ReturnType greater_than<ItemToMatch, AttributeType, ReturnType>(
      this IProvideAccessToMatchCreationExtensions<ItemToMatch, AttributeType, ReturnType> extension_point,
      AttributeType value)
      where AttributeType : IComparable<AttributeType>
    {
      return extension_point.create_dsl_result(new GreaterThan<AttributeType>(value));
    }
  }
}