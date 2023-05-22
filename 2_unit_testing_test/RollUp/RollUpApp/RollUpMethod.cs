namespace RollUpApp;

public class RollUpMethod
{
    public List<Output> RollUpMeth(List<Product> products)
    {
        List<Product> lowestGtin;
        List<Product> lowestVariant = new List<Product>();
        IEnumerable<Output> eliminatedOutputs = new List<Output>();
        List<Output> outputs = new List<Output>();
        var differentProductsNames = products.Select(p => p.ProductName).Distinct();
        foreach (var productName in differentProductsNames)
        {
            lowestGtin = new List<Product>();
            var differentVariants = products.Where(p => p.ProductName == productName).Select(p => p.VariantName).Distinct();
            foreach (var variantName in differentVariants)
            {
                var differentGtinProducts = products.Where(p => p.VariantName == variantName && p.ProductName == productName);
                var AllLowestGtin = differentGtinProducts.GetLowest();
                lowestGtin.Add(AllLowestGtin.ToList()[new Random().Next(AllLowestGtin.Count())]);
                eliminatedOutputs = differentGtinProducts.GetEliminated().Select(p => new Output(p.GtinName, p.price));
                if (eliminatedOutputs is not null && eliminatedOutputs.Count() > 0)
                {
                    outputs.AddRange(eliminatedOutputs);
                }

            }
            var allLowestVariants = lowestGtin.GetLowest();
            if (!allLowestVariants.Any(p => p.price is null))
            {
                lowestVariant.Add(allLowestVariants.ToList()[new Random().Next(allLowestVariants.Count())]);
            }
            eliminatedOutputs = lowestGtin.GetEliminated().Select(p => new Output(p.VariantName, p.price));
            if (eliminatedOutputs is not null && eliminatedOutputs.Count() > 0)
            {
                outputs.AddRange(eliminatedOutputs);
            }
        }
        outputs.AddRange(lowestVariant.Select(p => new Output(p.ProductName, p.price)));
        foreach (var output in outputs)
        {
            Console.WriteLine(output.ToString());
        }
        return outputs;
    }


}
