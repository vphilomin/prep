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

    public class NegateMatches<ItemToMatch> : IMatchA<ItemToMatch>
    {
        IMatchA<ItemToMatch> matchToNegate;

        public NegateMatches(IMatchA<ItemToMatch> matchToNegate)
        {
            this.matchToNegate = matchToNegate;
        }

        public bool matches(ItemToMatch item)
        {
            return !matchToNegate.matches(item);
        }
    }
}