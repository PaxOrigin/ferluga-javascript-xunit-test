namespace RollUpApp;

internal static class RollUpExtensionMethods
{
    public static IEnumerable<Product> GetLowest(this IEnumerable<Product> products)
    {
        if (products.Any(p => p.price is null))
        {
            return products.Where(p => p.price is null);
        }
        return products.Where(p => p.price == products.Min(p => p.price));
    }

    public static IEnumerable<Product> GetEliminated(this IEnumerable<Product> products)
    {
        if (products.Any(p => p.price is null))
        {
            return products.Where(p => p.price is not null);
        }
        return products.Where(p => p.price != products.Min(p => p.price));
    }

    public static Product GetRandomElement(this IEnumerable<Product>? products)
        => products.ToList()[new Random().Next(products.Count())];



}
