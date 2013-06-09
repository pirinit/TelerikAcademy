using System;
using System.Collections.Generic;
using System.Linq;

/* 1. You are given a tree of N nodes represented as a set of N-1 pairs
 * of nodes (parent node, child node), each in the range (0..N-1).
 * Write a program to read the tree and find:
 * the root node
 * all leaf nodes
 * all middle nodes
 * the longest path in the tree
 * all paths in the tree with given sum S of their nodes
 * all subtrees with given sum S of their nodes
 */
namespace _1.Tree
{
    public class TreeDemo
    {
        static TreeNode[] nodes;
        static List<int> longestPath = new List<int>();
        static List<int> currentPath = new List<int>();
        static List<List<int>> allPathsWithGivenSum = new List<List<int>>();
        static int targetSum;
        public static void Main()
        {
            nodes = ReadInput();

            // task a
            int rootNodeNumber = FindRootNode(nodes);
            Console.WriteLine("Root node is {0}", rootNodeNumber);

            //task b
            List<int> leafs = FindAllLeafs(nodes);
            Console.WriteLine("Leafs:");
            foreach (var leaf in leafs)
            {
                Console.WriteLine(leaf);
            }

            //task c
            List<int> middleNode = FindAllMiddleNodes(nodes);
            Console.WriteLine("Middle nodes:");
            foreach (var node in middleNode)
            {
                Console.WriteLine(node);
            }

/* input to test longest path task
10
2 4
3 2
5 0
3 5
5 6
5 1
4 7
1 8
8 9

*/
            FindLogestPath(nodes[rootNodeNumber]);
            Console.WriteLine("Longest path:");
            foreach (var nodeNumber in longestPath)
            {
                Console.Write("{0}-> ", nodeNumber);
            }
            Console.WriteLine();

            //task e
            targetSum = 9;
            FindAllPathsWithGivenSum(nodes[rootNodeNumber]);
            Console.WriteLine("All paths with sum {0}:", targetSum);
            foreach (var path in allPathsWithGivenSum)
            {
                foreach (var nodeNumber in path)
                {
                    Console.Write("{0}-> ", nodeNumber);
                }
                Console.WriteLine();
            }

            //task f - it is possible to save the sum of every subtree - dynamic optimization
            int sum = 6;
            foreach (var node in nodes)
            {
                if (sum == CalcTreeSum(node))
                {
                    Console.WriteLine("The subtree starting in node number {0} has sum equal to {1}.", node.Number, sum);
                }
            }
        }

        private static void FindAllPathsWithGivenSum(TreeNode treeNode)
        {
            currentPath.Add(treeNode.Number);

            if (treeNode.ChildCount == 0)
            {
                // leaf is reached
                int pathSum = currentPath.Sum();
                if (pathSum == targetSum)
                {
                    // save the path to the current leaf
                    allPathsWithGivenSum.Add(new List<int>(currentPath));
                }
            }

            for (int i = 0; i < treeNode.ChildCount; i++)
            {
                FindAllPathsWithGivenSum(nodes[treeNode.GetChildNumber(i)]);
            }

            currentPath.RemoveAt(currentPath.Count - 1);
        }

        private static int CalcTreeSum(TreeNode node)
        {
            int sum = node.Number;

            for (int i = 0; i < node.ChildCount; i++)
            {
                sum += CalcTreeSum(nodes[node.GetChildNumber(i)]);
            }

            return sum;
        }

        private static void FindLogestPath(TreeNode treeNode)
        {
            currentPath.Add(treeNode.Number);

            if (currentPath.Count > longestPath.Count)
            {
                longestPath = new List<int>(currentPath);
            }

            for (int i = 0; i < treeNode.ChildCount; i++)
            {
                FindLogestPath(nodes[treeNode.GetChildNumber(i)]);
            }

            currentPath.RemoveAt(currentPath.Count - 1);
        }

        private static List<int> FindAllMiddleNodes(TreeNode[] nodes)
        {
            List<int> middleNodes = new List<int>();

            foreach (var node in nodes)
            {
                if (node.HasParent && node.ChildCount > 0)
                {
                    middleNodes.Add(node.Number);
                }
            }

            return middleNodes;
        }

        private static List<int> FindAllLeafs(TreeNode[] nodes)
        {
            List<int> leafs = new List<int>();
            foreach (var node in nodes)
            {
                if (node.ChildCount == 0)
                {
                    leafs.Add(node.Number);
                }
            }

            return leafs;
        }

        private static int FindRootNode(TreeNode[] nodes)
        {
            foreach (var node in nodes)
            {
                if (!node.HasParent)
                {
                    return node.Number;
                }
            }

            throw new ArgumentException("The three has no root.");
        }
  
        private static TreeNode[] ReadInput()
        {
            
            string input = Console.ReadLine();
            int n = int.Parse(input);
            TreeNode[] nodes = new TreeNode[n];

            for (int i = 0; i < n - 1; i++)
            {
                input = Console.ReadLine();
                string[] splitNodes = input.Split();

                int parentNumber = int.Parse(splitNodes[0]);
                int childNumber = int.Parse(splitNodes[1]);

                TreeNode parentNode;
                TreeNode childNode;

                if (nodes[parentNumber] != null)
                {
                    parentNode = nodes[parentNumber];
                }
                else
                {
                    parentNode = new TreeNode(parentNumber);
                    nodes[parentNumber] = parentNode;
                }

                if (nodes[childNumber] != null)
                {
                    childNode = nodes[childNumber];
                }
                else
                {
                    childNode = new TreeNode(childNumber);
                    nodes[childNumber] = childNode;
                }

                childNode.HasParent = true;
                parentNode.AddChild(childNumber);
            }
            return nodes;
        }
    }
}
