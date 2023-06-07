using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeProblem
{
    internal class UC_2SizeOfTree
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

            public int Size()
            {
                return CountNodes(root);
            }

            private int CountNodes(BinaryTreeNode<T> node)
            {
                if (node == null)
                {
                    return 0;
                }

                // Recursively count the nodes in the left and right subtrees
                int leftCount = CountNodes(node.Left);
                int rightCount = CountNodes(node.Right);

                // Add 1 for the current node
                return 1 + leftCount + rightCount;
            }
        }

        public class Program
        {
            public static void Main(string[] args)
            {
                BinaryTree<int> binaryTree = new BinaryTree<int>();

                binaryTree.Add(1);
                binaryTree.Add(2);
                binaryTree.Add(3);
                binaryTree.Add(4);
                binaryTree.Add(5);

                int size = binaryTree.Size();

                Console.WriteLine("Binary Tree size: " + size);
            }
        }
    }
}
