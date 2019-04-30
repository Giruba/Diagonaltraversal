using System;
using System.Collections.Generic;
using System.Text;

namespace DiagonalTraversal
{
    class BinaryTree
    {
        BinaryTreeNode root;

        public BinaryTree(BinaryTreeNode binaryTreeNode) {
            root = binaryTreeNode;
        }

        public void SetBinaryTreeRoot(BinaryTreeNode binaryTreeNode) {
            root = binaryTreeNode;
        }

        public BinaryTreeNode GetBinaryTreeRoot(){
            return root;
        }

        public BinaryTreeNode Insert(BinaryTreeNode binaryTreeNode, int data) {
            if (binaryTreeNode == null) {
                binaryTreeNode = new BinaryTreeNode(data);
                return binaryTreeNode;
            }

            if (binaryTreeNode.GetBinaryTreeNodeData() < data)
            {
                binaryTreeNode.SetBinaryTreeNodeRight(
                    Insert(binaryTreeNode.GetBinaryTreeNodeRight(), data));
            }
            else {
                binaryTreeNode.SetBinaryTreeNodeLeft(
                    Insert(binaryTreeNode.GetBinaryTreeNodeLeft(), data));
            }
            return binaryTreeNode;
        }

        public void PrintDiagonalTraversal() {
            Dictionary<int, LinkedList<int>> keyValuePairs = new Dictionary<int, LinkedList<int>>();
            keyValuePairs = FindDiagonalEntries(keyValuePairs, 0, this.GetBinaryTreeRoot());
            for (int index = 0; index < keyValuePairs.Count; index++) {
                Console.WriteLine("The elements at slope "+index);
                LinkedList<int> linkedList = keyValuePairs[index];
                foreach (var element in linkedList) {
                    Console.Write(element +" ");
                }
                Console.WriteLine();
            }
        }

        private Dictionary<int, LinkedList<int>> FindDiagonalEntries(Dictionary<int, LinkedList<int>> keyValuePairs, int slope, BinaryTreeNode binaryTreeRoot) {
            if (binaryTreeRoot == null) {
                return keyValuePairs;
            }

            LinkedList<int> slopeList = null;
            if (!keyValuePairs.ContainsKey(slope)){
                slopeList = new LinkedList<int>();
                slopeList.AddLast(binaryTreeRoot.GetBinaryTreeNodeData());
            }
            else {
                slopeList = keyValuePairs[slope];
                slopeList.AddLast(binaryTreeRoot.GetBinaryTreeNodeData());
            }
            keyValuePairs[slope] =  slopeList;
            keyValuePairs = FindDiagonalEntries(keyValuePairs, slope+1, binaryTreeRoot.GetBinaryTreeNodeLeft());
            keyValuePairs = FindDiagonalEntries(keyValuePairs, slope, binaryTreeRoot.GetBinaryTreeNodeRight());

            return keyValuePairs;
        }
    }
}
