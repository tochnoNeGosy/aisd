using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace AisdBaza
{
    public class TreeNode
    {
        public int value;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int value)
        {
            this.value = value;
            left = null;
            right = null;
        }
    }
    public class BinaryTree
    {
        private TreeNode root;

        public BinaryTree()
        {
            root = null;
        }

        public void AddElement(int value)
        {
            root = AddRec(root, value);
        }

        private TreeNode AddRec(TreeNode node, int value)
        {
            if (node == null)
            {
                node = new TreeNode(value);
                return node;
            }
            if (node.value > value)
            {
                node.left = AddRec(node.left, value);
            }
            else
            {
                node.right = AddRec(node.right, value);
            }
            return node;
        }

        public void RemoveElement(int value)
        {
            root = RemoveRec(root, value);
        }

        private TreeNode RemoveRec(TreeNode node, int value)
        {
            if (node == null)
            {
                return null;
            }
            if (node.value == value)
            {
                if (node.left == null && node.right == null)
                {
                    return null;
                }
                if (node.left == null)
                {
                    return node.right;
                }
                if (node.right == null)
                {
                    return node.left;
                }
                TreeNode maxMIn = node.right;
                while(maxMIn.left != null)
                {
                    maxMIn = maxMIn.left;
                }
                maxMIn.left = node.left;
                return node.right;
            }
            if (node.value > value)
            {
                node.left = RemoveRec(node.left, value);
            }
            else
            {
                node.right = RemoveRec(node.right, value);
            }
            return node;
        }

        public void WriteElements()
        {
            WriteRec(root);
            Console.WriteLine();
        }

        private void WriteRec(TreeNode treeNode)
        {
            if (treeNode == null)
            {
                return;
            }
            Console.Write(treeNode.value + ", ");
            WriteRec(treeNode.left);
            WriteRec(treeNode.right);
        }
    }
}
