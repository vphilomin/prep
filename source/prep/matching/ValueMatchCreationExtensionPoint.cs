namespace prep.matching
{
  public class ValueMatchCreationExtensionPoint<Value> : IProvideAccessToMatchCreationExtensions<Value, Value, IMatchA<Value>>
  {
    public IMatchA<Value> create_dsl_result(IMatchA<Value> value_condition)
    {
      return value_condition;
    }

    class NegatingValueMatchCreationExtensionPoint : IProvideAccessToMatchCreationExtensions<Value, Value, IMatchA<Value>>
    {
      IProvideAccessToMatchCreationExtensions<Value, Value, IMatchA<Value>> original;

      public NegatingValueMatchCreationExtensionPoint(IProvideAccessToMatchCreationExtensions<Value, Value, IMatchA<Value>> original)
      {
        this.original = original;
      }

      public IMatchA<Value> create_dsl_result(IMatchA<Value> value_condition)
      {
        return original.create_dsl_result(value_condition).not();
      }
    }
  }
}