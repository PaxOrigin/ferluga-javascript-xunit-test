namespace RollUpApp;

public class RollUpMethod
{

    private List<Output> outputs = new List<Output>();
    public List<Output> RollUpMeth(List<Product> products)
    {
        List<Product> lowestGtin;
        List<Product> lowestVariant = new List<Product>();
        IEnumerable<Output> eliminatedOutputs = new List<Output>();

        var differentProductsNames = products.Select(p => p.ProductName).Distinct();
        foreach (var productName in differentProductsNames)
        {
            lowestGtin = new List<Product>();
            var differentVariants = products.Where(p => p.ProductName == productName).Select(p => p.VariantName).Distinct();
            foreach (var variantName in differentVariants)
            {
                var differentGtinProducts = products.Where(p => p.VariantName == variantName && p.ProductName == productName);
                var AllLowestGtin = differentGtinProducts.GetLowest();
                lowestGtin.Add(AllLowestGtin.GetRandomElement());
                eliminatedOutputs = differentGtinProducts.GetEliminated().Select(p => new Output(p.GtinName, p.price));
                AddIfExists(eliminatedOutputs);

            }
            var allLowestVariants = lowestGtin.GetLowest();
            if (!allLowestVariants.Any(p => p.price is null))
            {
                lowestVariant.Add(allLowestVariants.GetRandomElement());
            }
            eliminatedOutputs = lowestGtin.GetEliminated().Select(p => new Output(p.VariantName, p.price));
            AddIfExists(eliminatedOutputs);

        }
        outputs.AddRange(lowestVariant.Select(p => new Output(p.ProductName, p.price)));
        return outputs;
    }

    private void AddIfExists(IEnumerable<Output> outputs)
    {
        if (outputs is not null && outputs.Count() > 0)
        {
            this.outputs.AddRange(outputs);
        }
    }


}
