namespace Algorithms.ListDataStructures;

using System;
using System.Collections.Generic;

public static class BinaryTreeExtensionMethods
{
    public static string StringValue<T>(this TreeNode<T> node)
        where T : notnull, IComparable<T>
        => !node.IsNull ? node.Payload.ToString() ?? "NULL" : "NullNode";

    public static string Direction<T>(this TreeNode<T> node)
        where T : notnull, IComparable<T>
      => node switch
      {
          _ when node.IsRoot() => "Root",
          _ when node.IsLeftChild() => "L",
          _ when node.IsRightChild() => "R",
          _ => "None",
      };

    public static void PrintTree<T>(this TreeNode<T> root)
        where T : notnull, IComparable<T>
    {
        if (root.IsNull)
        {
            Console.WriteLine("Tree is empty");
            return;
        }

        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;

            for (int i = 0; i < levelSize; i++)
            {
                var currentNode = queue.Dequeue();
                Console.ForegroundColor = currentNode.Color == NodeColor.Red ?
                  ConsoleColor.Red :
                  ConsoleColor.White;

                Console.Write($"{currentNode.Payload}(Parent:{currentNode.Parent.StringValue()}, {currentNode.Direction()}, size:{currentNode.Size}, {currentNode.Color}) ");

                Console.ResetColor();

                if (!currentNode.Left.IsNull)
                    queue.Enqueue(currentNode.Left);

                if (!currentNode.Right.IsNull)
                    queue.Enqueue(currentNode.Right);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
