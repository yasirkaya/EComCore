namespace EComCore.Domain.Entities
{
    public class ProductVariantAttribute : BaseEntity
    {
        public int ProductVariantId { get; set; }
        public int AttributeId { get; set; }
        public int AttributeValueId { get; set; }
        public ProductVariant ProductVariant { get; set; }
        public CustomAttribute Attribute { get; set; }
        public AttributeValue AttributeValue { get; set; }
    }
}