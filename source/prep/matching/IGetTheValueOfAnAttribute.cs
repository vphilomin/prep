namespace prep.matching
{
  public delegate AttributeType IGetTheValueOfAnAttribute<in ItemToRetrieveAttributeFrom, out AttributeType>(
    ItemToRetrieveAttributeFrom target);
}