namespace RollUpApp;

public class Product
{
    public string ProductName { get; private set; }
    public string VariantName { get; private set; }
    public string GtinName { get; private set; }
    public int? price { get; private set; }

    public Product(string productName, string variantName, string gtinName, int? price)
    {
        ProductName = productName;
        VariantName = variantName;
        GtinName = gtinName;
        this.price = price;
    }
}
