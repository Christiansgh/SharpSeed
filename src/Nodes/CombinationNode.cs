using SharpSeed.Models;

namespace SharpSeed.Nodes;

public class CombinationNode : BaseNode {
    public string ComboName { get; set; }
    public NODE_TYPE ComboType { get; set; }
    public HashSet<KeyValuePair<string, object>> Collection { get; set; }

    public CombinationNode(string name, string comboName, NODE_TYPE comboType, HashSet<KeyValuePair<string, object>> collection) : base(name) {
        ComboName = comboName;
        ComboType = comboType;
        Collection = collection;
    }

    public override List<object> HandleNode() {
        return Collection.SelectMany(pair => {
            if (pair.Value is IEnumerable<object> collection) {
                return collection.Select(item => (object)new List<object> { pair.Key, item });
            }

            return new List<object>[] { new() { pair.Key, pair.Value } };
        }).ToList();
    }
}
