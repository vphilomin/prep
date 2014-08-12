namespace prep.matching_core
{
  public delegate AttributeType IGetTheValueOfAnAttribute<in ItemToRetrieveAttributeFrom, out AttributeType>(
    ItemToRetrieveAttributeFrom target);
}