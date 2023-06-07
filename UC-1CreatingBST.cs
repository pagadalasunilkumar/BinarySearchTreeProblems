using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeProblem
{
    internal class UC_1CreatingBST
    {
        public interface INode<T> where T : IComparable<T>
        {
            T Key { get; set; }
            INode<T> Left { get; set; }
            INode<T> Right { get; set; }
        }

        public class BinaryNode<T> : INode<T> where T : IComparable<T>
        {
            public T Key { get; set; }
            public INode<T> Left { get; set; }
            public INode<T> Right { get; set; }
        }

        public class BinarySearchTree<T> where T : IComparable<T>
        {
            private INode<T> root;

            public void Add(T key)
            {
                root = AddNode(root, key);
            }

            private INode<T> AddNode(INode<T> node, T key)
            {
                if (node == null)
                {
                    node = new BinaryNode<T>
                    {
                        Key = key,
                        Left = null,
                        Right = null
                    };
                }
                else if (key.CompareTo(node.Key) < 0)
                {
                    node.Left = AddNode(node.Left, key);
                }
                else if (key.CompareTo(node.Key) > 0)
                {
                    node.Right = AddNode(node.Right, key);
                }

                return node;
            }
        }

        public class Program
        {
            public static void Main(string[] args)
            {
                BinarySearchTree<int> bst = new BinarySearchTree<int>();

                bst.Add(56);
                bst.Add(30);
                bst.Add(70);

                Console.WriteLine("Binary Search Tree created with nodes: 56, 30, 70");
            }
        }
    }
}
