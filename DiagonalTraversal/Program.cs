using System;

namespace DiagonalTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Diagonal Traversal!");
            Console.WriteLine("-------------------");

            BinaryTree binaryTree = GetBinaryTreeFromInput();
            binaryTree.PrintDiagonalTraversal();
            Console.ReadLine();
        }

        private static BinaryTree GetBinaryTreeFromInput() {
            BinaryTree binaryTree = null;

            Console.WriteLine("Enter the number of nodes in the binary tree");
            try{
                int numberElements = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the elements separated by space, comma" +
                    " or semi-colon");
                String[] elements = Console.ReadLine().Split(' ', ',',';');
                binaryTree = new BinaryTree(null);
                for (int index = 0; index < numberElements; index++) {
                    binaryTree.SetBinaryTreeRoot(binaryTree.Insert(binaryTree.GetBinaryTreeRoot(),
                        int.Parse(elements[index])));
                }
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }

            return binaryTree;
        }
    }
}
