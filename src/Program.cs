using SharpSeed.Adapters;
using SharpSeed.Models;
using SharpSeed.Nodes;

var brandSeries = new HashSet<KeyValuePair<string, object>>() {
    new("Nike", new List<string> { "Air", "Max", "Jordan" }),
    new("Adidas", new List<string> { "Ultraboost", "Superstar" }),
    new("Puma", "RS-X") // Single value
};

var colors = new List<object> { "White", "Blue", "Red", "Black", "Beige", "Yellow" };

//This is the variant "root".
var sizes = new List<object> { 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46 };

//var prices = new List<object> { 200, 250, 300, 350, 400, 450, 500 };

//var stockAmounts = new List<object> { };

var brandsSeriesCombo = new CombinationNode("Brand", "Series", NODE_TYPE.ALL, brandSeries);
var colorsAll = new RandomNode("Colors", 0, true, colors);
//var sizesOne = new RandomNode("Sizes", 1, false, sizes);
//var pricesOne = new RandomNode("Prizes", 1, false, prizes);

List<IEnumerable<object>> collection = new() {
    brandsSeriesCombo.HandleNode(),
    colorsAll.HandleNode()
    //sizesOne.HandleNode(),
    //prizesOne.HandleNode()
};

FlatAdapter.Collection = collection;

// Get the Cartesian Product result
List<List<object>> result = FlatAdapter.GetCartesianProduct();

// Output the result
Console.WriteLine("Results:");
foreach (List<object> combo in result) {
    // Print the combination, ensuring that collections are properly formatted
    Console.WriteLine(string.Join(", ", combo.Select(item => FlatAdapter.FormatItem(item))));
}

