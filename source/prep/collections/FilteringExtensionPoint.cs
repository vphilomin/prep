using System.Collections.Generic;
using prep.infrastructure;
using prep.matching;

namespace prep.collections
{
  public class FilteringExtensionPoint<Item, AttributeType> :
    IProvideAccessToMatchCreationExtensions<Item, AttributeType,
      IEnumerable<Item>>
  {
    IEnumerable<Item> items;
    IProvideAccessToMatchCreationExtensions<Item, AttributeType, IMatchA<Item>> filter_extensions;

    public FilteringExtensionPoint(
      IProvideAccessToMatchCreationExtensions<Item, AttributeType, IMatchA<Item>> filter_extensions,
      IEnumerable<Item> items)
    {
      this.filter_extensions = filter_extensions;
      this.items = items;
    }

    public IEnumerable<Item> create_dsl_result(IMatchA<AttributeType> value_condition)
    {
      var matcher = filter_extensions.create_dsl_result(value_condition);
      return items.filter(matcher);
    }

    public IProvideAccessToMatchCreationExtensions<Item, AttributeType, IEnumerable<Item>> not
    {
      get { return new NegatingFilteringExtensionPoint(this); }
    }

    class NegatingFilteringExtensionPoint : IProvideAccessToMatchCreationExtensions<Item, AttributeType,
      IEnumerable<Item>>
    {
      IProvideAccessToMatchCreationExtensions<Item, AttributeType, IEnumerable<Item>> original;

      public NegatingFilteringExtensionPoint(
        IProvideAccessToMatchCreationExtensions<Item, AttributeType, IEnumerable<Item>> original)
      {
        this.original = original;
      }

      public IEnumerable<Item> create_dsl_result(IMatchA<AttributeType> value_condition)
      {
        return original.create_dsl_result(value_condition.not());
      }
    }
  }
}