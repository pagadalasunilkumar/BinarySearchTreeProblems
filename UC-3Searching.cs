using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeProblem
{
    internal class UC_3Searching
    {
        public class BinaryTreeNode<T>
        {
            public T Value { get; set; }
            public BinaryTreeNode<T> Left { get; set; }
            public BinaryTreeNode<T> Right { get; set; }

            public BinaryTreeNode(T value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        public class BinaryTree<T>
        {
            private BinaryTreeNode<T> root;

            public void Add(T value)
            {
                root = AddNode(root, value);
            }

            private BinaryTreeNode<T> AddNode(BinaryTreeNode<T> node, T value)
            {
                if (node == null)
                {
                    return new BinaryTreeNode<T>(value);
                }
                else
                {
                    if (node.Left == null)
                    {
                        node.Left = AddNode(node.Left, value);
                    }
                    else if (node.Right == null)
                    {
                        node.Right = AddNode(node.Right, value);
                    }
                    else
                    {
                        // If both left and right children are present,
                        // we can choose either side to add the new node.
                        // Here, we choose the left side.
                        node.Left = AddNode(node.Left, value);
                    }

                    return node;
                }
            }

            public bool Search(T value)
            {
                return SearchNode(root, value);
            }

            private bool SearchNode(BinaryTreeNode<T> node, T value)
            {
                if (node == null)
                {
                    return false;
                }

                if (node.Value.Equals(value))
                {
                    return true;
                }

                // Recursively search in the left and right subtrees
                bool leftSearch = SearchNode(node.Left, value);
                bool rightSearch = SearchNode(node.Right, value);

                // Return true if the value is found in either subtree
                return leftSearch || rightSearch;
            }
        }

        public class Program
        {
            public static void Main(string[] args)
            {
                BinaryTree<int> binaryTree = new BinaryTree<int>();

                binaryTree.Add(56);
                binaryTree.Add(30);
                binaryTree.Add(70);
                binaryTree.Add(22);
                binaryTree.Add(40);
                binaryTree.Add(11);
                binaryTree.Add(3);
                binaryTree.Add(63);

                bool found = binaryTree.Search(63);

                Console.WriteLine("63 found in the Binary Tree: " + found);
            }
        }s
    }
}
