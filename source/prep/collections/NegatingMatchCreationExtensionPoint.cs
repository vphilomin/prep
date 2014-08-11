using prep.matching;

namespace prep.collections
{
    public class NegatingMatchCreationExtensionPoint<ItemToMatch, AttributeType>
    {
        public IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> accessor { get; set; }

        public NegatingMatchCreationExtensionPoint(IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> accessor)
        {
            this.accessor = accessor;
        }
    }
}