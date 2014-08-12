namespace prep.matching_core
{
  public interface IMatchA<in ItemToMatch>
  {
    bool matches(ItemToMatch item);
  }
}