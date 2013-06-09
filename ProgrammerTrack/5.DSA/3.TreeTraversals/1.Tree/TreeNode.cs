using System.Collections.Generic;

namespace _1.Tree
{
    public class TreeNode
    {
        private List<int> children;

        public int Number { get; private set; }
        public bool HasParent { get; set; }

        public int ChildCount 
        {
            get
            {
                return this.children.Count;
            }
        }

        public TreeNode(int number)
        {
            this.Number = number;
            this.children = new List<int>();
        }

        public void AddChild(int childNumber)
        {
            this.children.Add(childNumber);
        }

        public int GetChildNumber(int childIndex)
        {
            return this.children[childIndex];
        }
    }
}