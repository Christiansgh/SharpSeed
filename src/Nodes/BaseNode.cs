namespace SharpSeed.Nodes;

public abstract class BaseNode {
    public string Name { get; set; }

    public BaseNode(string name) {
        Name = name;
    }

    public abstract List<object> HandleNode();
}
