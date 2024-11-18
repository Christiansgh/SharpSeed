namespace SharpSeed.Adapters;

public static class FlatAdapter {
    public static List<IEnumerable<object>> Collection { get; set; } = new();

    public static string FormatItem(object item) {
        // If the item is a List<object>, convert it into a comma-separated list
        if (item is List<object> list) {
            return $"[{string.Join(", ", list)}]";
        }

        // Otherwise, just return the item's string representation
        return item.ToString();
    }

    // Generalized method to generate Cartesian Product
    public static List<List<object>> GetCartesianProduct() {
        var result = new List<List<object>> { new() };

        foreach (IEnumerable<object> collection in Collection) {
            result = result.SelectMany(
                currentCombination => collection,
                (currentCombination, item) => {
                    var newCombination = new List<object>(currentCombination) { item };
                    return newCombination;
                }).ToList();
        }

        return result;
    }
}
