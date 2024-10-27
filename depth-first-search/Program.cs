public class Program
{
    //O(V+E) time; O(V) space
    public static void Main(string[] args)
    {
        // Display the number of command line arguments.
        Program.Node graph = new Program.Node("A");
        graph.AddChild("B").AddChild("C").AddChild("D");
        graph.children[0].AddChild("E").AddChild("F");
        graph.children[2].AddChild("G").AddChild("H");
        graph.children[0].children[1].AddChild("I").AddChild("J");
        graph.children[2].children[0].AddChild("K");
        string[] expected =
        {
          "A", "B", "E", "F", "I", "J",
          "C", "D", "G", "K", "H"
        };
        List<string> inputArray = new List<string>();
        Boolean res = compare(graph.DepthFirstSearch(inputArray), expected);
        Console.WriteLine(res);
    }

    public static bool compare(List<string> arr1, string[] arr2)
    {
        if (arr1.Count != arr2.Length)
        {
            return false;
        }
        for (int i = 0; i < arr1.Count; i++)
        {
            if (!arr1[i].Equals(arr2[i]))
            {
                return false;
            }
        }
        return true;
    }

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
