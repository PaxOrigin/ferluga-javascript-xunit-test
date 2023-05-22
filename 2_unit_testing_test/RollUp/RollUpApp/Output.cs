namespace RollUpApp;

public class Output
{
    public Output(string productName, int? price)
    {
        this.productName = productName;
        this.price = price;
    }

    public string productName { get; private set; }
    public int? price { get; private set; }

    public override string? ToString()
    {
        return $"Product: {this.productName}   Price: {this.price}";
    }
}
