using prep.matching;

namespace prep.collections
{
  public interface IProvideAccessToMatchCreationExtensions<in ItemToMatch, out AttributeType, out ReturnType>
  {
    ReturnType create_dsl_result(IMatchA<AttributeType> value_condition);
  }
}