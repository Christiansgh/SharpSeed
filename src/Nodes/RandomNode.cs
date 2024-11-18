namespace SharpSeed.Nodes;

public class RandomNode : BaseNode {
    public int Amount { get; set; }
    public bool All { get; set; }
    public List<object> Collection { get; set; }

    public RandomNode(string name, int amount, bool all, List<object> collection) : base(name) {
        Amount = amount;
        All = all;
        Collection = collection;
    }

    public override List<object> HandleNode() {
        if (All || Amount > Collection.Count) {
            return Collection;
        }

        return Collection.OrderBy(_ => new Random().Next())
            .Take(Amount)
            .ToList();
    }
}
