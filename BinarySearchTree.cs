namespace Labb7BinarySearchTree
{
    public class BinarySearchTree
    {
        private TreeNode? root;

        public BinarySearchTree() => root = null;

        // Add a value to the BST using recursive approach
        public void AddRecursive(int value)
        {
            root = AddRecursiveHelper(root, value);
        }

        private TreeNode AddRecursiveHelper(TreeNode current, int value)
        {
            if (current == null)
            {
                return new TreeNode(value);
            }

            if (value < current.Value)
            {
                current.Left = AddRecursiveHelper(current.Left, value);
            }
            else if (value > current.Value)
            {
                current.Right = AddRecursiveHelper(current.Right, value);
            }

            return current;
        }

        // Add a value to the BST using iterative approach
        public void AddIterative(int value)
        {
            if (root == null)
            {
                root = new TreeNode(value);
                return;
            }

            TreeNode current = root;
            TreeNode? parent = null;

            while (current != null)
            {
                parent = current;
                if (value < current.Value)
                {
                    current = current.Left;
                }
                else if (value > current.Value)
                {
                    current = current.Right;
                }
                else
                {
                    return; // Value already exists in the tree
                }
            }

            if (value >= parent.Value)
            {
                parent.Right = new TreeNode(value);
            }
            else
            {
                parent.Left = new TreeNode(value);
            }
        }

        // Search for a value in the BST using recursive approach
        public bool SearchRecursive(int value)
        {
            return SearchRecursiveHelper(root, value);
        }

        private bool SearchRecursiveHelper(TreeNode current, int value)
        {
            if (current == null)
            {
                return false;
            }

            if (value == current.Value)
            {
                return true;
            }

            return value < current.Value
                ? SearchRecursiveHelper(current.Left, value)
                : SearchRecursiveHelper(current.Right, value);
        }

        // Search for a value in the BST using iterative approach
        public bool SearchIterative(int value)
        {
            TreeNode current = root;

            while (current != null)
            {
                if (value == current.Value)
                {
                    return true;
                }
                if (value < current.Value)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return false;
        }

        // Delete a value from the BST using recursive approach
        public void DeleteRecursive(int value)
        {
            root = DeleteRecursiveHelper(root, value);
        }

        private TreeNode DeleteRecursiveHelper(TreeNode current, int value)
        {
            if (current == null)
            {
                return null;
            }

            if (value < current.Value)
            {
                current.Left = DeleteRecursiveHelper(current.Left, value);
            }
            else if (value > current.Value)
            {
                current.Right = DeleteRecursiveHelper(current.Right, value);
            }
            else
            {
                if (current.Left == null && current.Right == null)
                {
                    return null;
                }
                else if (current.Left == null)
                {
                    return current.Right;
                }
                else if (current.Right == null)
                {
                    return current.Left;
                }
                else
                {
                    TreeNode smallestValue = FindSmallestValue(current.Right);
                    current.Value = smallestValue.Value;
                    current.Right = DeleteRecursiveHelper(current.Right, smallestValue.Value);
                }
            }

            return current;
        }

        private TreeNode FindSmallestValue(TreeNode root)
        {
            return root.Left == null ? root : FindSmallestValue(root.Left);
        }

        // Delete a value from the BST using iterative approach
        public void DeleteIterative(int value)
        {
            TreeNode current = root;
            TreeNode parent = null;

            while (current != null && current.Value != value)
            {
                parent = current;
                if (value < current.Value)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            if (current == null)
            {
                return;
            }

            if (current.Left == null && current.Right == null)
            {
                if (current == root)
                {
                    root = null;
                }
                else if (parent.Left == current)
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }
            }
            else if (current.Left == null)
            {
                if (current == root)
                {
                    root = current.Right;
                }
                else if (parent.Left == current)
                {
                    parent.Left = current.Right;
                }
                else
                {
                    parent.Right = current.Right;
                }
            }
            else if (current.Right == null)
            {
                if (current == root)
                {
                    root = current.Left;
                }
                else if (parent.Left == current)
                {
                    parent.Left = current.Left;
                }
                else
                {
                    parent.Right = current.Left;
                }
            }
            else
            {
                TreeNode smallestValue = FindSmallestValue(current.Right);
                int smallestValueData = smallestValue.Value;
                DeleteIterative(smallestValue.Value);
                current.Value = smallestValueData;
            }
        }

        // In-order traversal (recursive)
        public void InOrderTraversalRecursive(Action<int> action)
        {
            InOrderTraversalRecursiveHelper(root, action);
        }

        private void InOrderTraversalRecursiveHelper(TreeNode node, Action<int> action)
        {
            if (node != null)
            {
                InOrderTraversalRecursiveHelper(node.Left, action);
                action(node.Value);
                InOrderTraversalRecursiveHelper(node.Right, action);
            }
        }

        // In-order traversal (iterative)
        public void InOrderTraversalIterative(Action<int> action)
        {
            if (root == null) return;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                current = stack.Pop();
                action(current.Value);
                current = current.Right;
            }
        }
    }

    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
}

