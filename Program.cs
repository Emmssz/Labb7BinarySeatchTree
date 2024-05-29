using Labb7BinarySearchTree;


public class Program
{
    public static void Main(string[] args)
    {
        BinarySearchTree bst = new BinarySearchTree();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Binary Search Tree Menu");
            Console.WriteLine("1. Add Node (Recursive)");
            Console.WriteLine("2. Add Node (Iterative)");
            Console.WriteLine("3. Search Node (Recursive)");
            Console.WriteLine("4. Search Node (Iterative)");
            Console.WriteLine("5. Delete Node (Recursive)");
            Console.WriteLine("6. Delete Node (Iterative)");
            Console.WriteLine("7. In-order Traversal (Recursive)");
            Console.WriteLine("8. In-order Traversal (Iterative)");
            Console.WriteLine("9. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter the value to add (Recursive): ");
                    int addValueRecursive = int.Parse(Console.ReadLine());
                    bst.AddRecursive(addValueRecursive);
                    break;
                case "2":
                    Console.Write("Enter the value to add (Iterative): ");
                    int addValueIterative = int.Parse(Console.ReadLine());
                    bst.AddIterative(addValueIterative);
                    break;
                case "3":
                    // Search Node (Recursive) Logic
                    break;
                case "4":
                    // Search Node (Iterative) Logic
                    break;
                case "5":
                    // Delete Node (Recursive) Logic
                    break;
                case "6":
                    // Delete Node (Iterative) Logic
                    break;
                case "7":
                    Console.WriteLine("In-order Traversal (Recursive):");
                    bst.InOrderTraversalRecursive(value => Console.WriteLine(value));
                    break;
                case "8":
                    Console.WriteLine("In-order Traversal (Iterative):");
                    bst.InOrderTraversalIterative(value => Console.WriteLine(value));
                    break;

                case "9":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}


















