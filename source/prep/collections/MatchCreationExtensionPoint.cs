using prep.matching;

namespace prep.collections
{
  public interface IProvideAccessToMatchCreationExtensions<in ItemToMatch, out AttributeType>
  {
    IMatchA<ItemToMatch> create_matcher(IMatchA<AttributeType> value_condition);
  }

  public class MatchCreationExtensionPoint<ItemToMatch, AttributeType> : IProvideAccessToMatchCreationExtensions<ItemToMatch, AttributeType>
  {
    IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> accessor { get; set; }

    class NegatingMatchCreationExtensionPoint : IProvideAccessToMatchCreationExtensions<ItemToMatch,AttributeType>
    {
      IProvideAccessToMatchCreationExtensions<ItemToMatch, AttributeType> original;

      public NegatingMatchCreationExtensionPoint(IProvideAccessToMatchCreationExtensions<ItemToMatch, AttributeType> original)
      {
        this.original = original;
      }

      public IMatchA<ItemToMatch> create_matcher(IMatchA<AttributeType> value_condition)
      {
        return original.create_matcher(value_condition).not();
      }
    }

    public IProvideAccessToMatchCreationExtensions<ItemToMatch, AttributeType> not
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

    public IMatchA<ItemToMatch> create_matcher(IMatchA<AttributeType> value_condition)
    {
      return new AttributeMatch<ItemToMatch, AttributeType>(accessor, value_condition);
    }
  }
}