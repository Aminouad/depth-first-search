public class Program
{
    public static void Main(string[] args)
    {
        // Display the number of command line arguments.
        Program.Node graph = new Program.Node("A");
        graph.AddChild("B").AddChild("C").AddChild("D");
        graph.children[0].AddChild("E").AddChild("F");
        graph.children[2].AddChild("G").AddChild("H");
        graph.children[0].children[1].AddChild("I").AddChild("J");
        graph.children[2].children[0].AddChild("K");
        string[] expected = {
      "A", "B", "E", "F", "I", "J", "C", "D", "G", "K", "H"
    };
        List<string> inputArray = new List<string>();
        graph.DepthFirstSearch(inputArray);
    }
    // Do not edit the class below except
    // for the DepthFirstSearch method.
    // Feel free to add new properties
    // and methods to the class.
    public class Node
    {
        public string name;
        public List<Node> children = new List<Node>();

        public Node(string name)
        {
            this.name = name;
        }

        public List<string> DepthFirstSearch(List<string> array)
        {
            // Write your code here.

            if (this.children.Count == 0)
            {
                array.Add(this.name);
                return array;
            }

            else
            {
                array.Add(this.name);
                foreach (var node in this.children)
                {
                    array = node.DepthFirstSearch(array);
                }
            }

            return array;
        }

        public Node AddChild(string name)
        {
            Node child = new Node(name);
            children.Add(child);
            return this;
        }
    }
}
