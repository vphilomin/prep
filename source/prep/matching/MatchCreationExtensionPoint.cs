namespace prep.matching
{
  public class MatchCreationExtensionPoint<ItemToMatch, AttributeType> : IProvideAccessToMatchCreationExtensions<ItemToMatch, AttributeType, IMatchA<ItemToMatch>>
  {
    IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> accessor { get; set; }

    class NegatingMatchCreationExtensionPoint : IProvideAccessToMatchCreationExtensions<ItemToMatch,AttributeType, IMatchA<ItemToMatch>>
    {
      IProvideAccessToMatchCreationExtensions<ItemToMatch, AttributeType, IMatchA<ItemToMatch>> original;

      public NegatingMatchCreationExtensionPoint(IProvideAccessToMatchCreationExtensions<ItemToMatch, AttributeType, IMatchA<ItemToMatch>> original)
      {
        this.original = original;
      }

      public IMatchA<ItemToMatch> create_dsl_result(IMatchA<AttributeType> value_condition)
      {
        return original.create_dsl_result(value_condition).not();
      }
    }

    public IProvideAccessToMatchCreationExtensions<ItemToMatch, AttributeType, IMatchA<ItemToMatch>> not
    {
      get
      {
        return new NegatingMatchCreationExtensionPoint(this);
      }
    }

    public MatchCreationExtensionPoint(IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchA<ItemToMatch> create_dsl_result(IMatchA<AttributeType> value_condition)
    {
      return new AttributeMatch<ItemToMatch, AttributeType>(accessor, value_condition);
    }
  }
}