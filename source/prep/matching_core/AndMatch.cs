namespace prep.matching_core
{
  public class AndMatch<ItemToMatch> : IMatchA<ItemToMatch>
  {
    IMatchA<ItemToMatch> left_side;
    IMatchA<ItemToMatch> right_side;

    public AndMatch(IMatchA<ItemToMatch> left_side, IMatchA<ItemToMatch> right_side)
    {
      this.left_side = left_side;
      this.right_side = right_side;
    }

    public bool matches(ItemToMatch item)
    {
      return left_side.matches(item) && right_side.matches(item);
    }
  }
}