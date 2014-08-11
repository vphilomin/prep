using prep.matching;

namespace prep.collections
{
  public class NeverMatches<ItemToMatch> : IMatchA<ItemToMatch>
  {
    public bool matches(ItemToMatch item)
    {
      return false;
    }
  }
}