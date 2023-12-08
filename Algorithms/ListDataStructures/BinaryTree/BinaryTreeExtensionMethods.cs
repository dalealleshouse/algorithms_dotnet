namespace Algorithms.ListDataStructures;

using System;
using System.Collections.Generic;

public static class BinaryTreeExtensionMethods
{
    public static Maybe<T> Unwrap<T>(this TreeNode<T> node)
        where T : notnull, IComparable<T>
        => !node.IsNull ? new(node.Payload) : Maybe<T>.None;

    public static int Size<T>(this Maybe<TreeNode<T>> node)
        where T : notnull, IComparable<T>
        => node.HasValue ? node.Value.Size : 0;

    public static void SetSize<T>(this Maybe<TreeNode<T>> node, int size)
        where T : notnull, IComparable<T>
    {
        if (node.HasValue)
            node.Value.Size = size;
    }

    public static NodeColor Color<T>(this Maybe<TreeNode<T>> node)
        where T : notnull, IComparable<T>
        => node.HasValue ? node.Value.Color : NodeColor.Black;

    public static void Color<T>(this Maybe<TreeNode<T>> node, NodeColor color)
        where T : notnull, IComparable<T>
    {
        if (node.HasValue)
            node.Value.Color = color;
    }

    /*
    public static Maybe<TreeNode<T>> Left<T>(this Maybe<TreeNode<T>> node)
        where T : notnull, IComparable<T>
        => node.HasValue ? node.Value.Left : Maybe<TreeNode<T>>.None;

    public static void Left<T>(this Maybe<TreeNode<T>> node, Maybe<TreeNode<T>> left)
        where T : notnull, IComparable<T>
    {
        if (node.HasValue)
            node.Value.Left = left;
    }

    public static Maybe<TreeNode<T>> Right<T>(this Maybe<TreeNode<T>> node)
      where T : notnull, IComparable<T>
      => node.HasValue ? node.Value.Right : Maybe<TreeNode<T>>.None;

    public static void Right<T>(this Maybe<TreeNode<T>> node, Maybe<TreeNode<T>> right)
        where T : notnull, IComparable<T>
    {
        if (node.HasValue)
            node.Value.Right = right;
    }

    public static Maybe<TreeNode<T>> Parent<T>(this Maybe<TreeNode<T>> node)
      where T : notnull, IComparable<T>
      => node.HasValue ? node.Value.Parent : Maybe<TreeNode<T>>.None;

    public static void Parent<T>(this Maybe<TreeNode<T>> node, Maybe<TreeNode<T>> parent)
        where T : notnull, IComparable<T>
    {
        if (node.HasValue)
            node.Value.Parent = parent;
    }

    public static Maybe<TreeNode<T>> GrandParent<T>(this Maybe<TreeNode<T>> node)
      where T : notnull, IComparable<T>
      => node.HasValue ? node.Value.Parent.Parent() : Maybe<TreeNode<T>>.None;

    public static Maybe<TreeNode<T>> Uncle<T>(this Maybe<TreeNode<T>> node)
      where T : notnull, IComparable<T>
    => node switch
    {
        { HasValue: false } => Maybe<TreeNode<T>>.None,
        { Value.Parent.HasValue: false } => Maybe<TreeNode<T>>.None,
        { Value.Parent.Value.IsLeftChild: true } => node.GrandParent().Right(),
        { Value.Parent.Value.IsRightChild: true } => node.GrandParent().Left(),
        _ => Maybe<TreeNode<T>>.None,
    };

    public static bool IsRed<T>(this Maybe<TreeNode<T>> node)
      where T : notnull, IComparable<T>
      => node.Color() == NodeColor.Red;

    public static bool IsBlack<T>(this Maybe<TreeNode<T>> node)
      where T : notnull, IComparable<T>
      => node.Color() == NodeColor.Black;

    public static bool IsLeftChild<T>(this Maybe<TreeNode<T>> node)
      where T : notnull, IComparable<T>
      => node.HasValue ? node.Value.IsLeftChild : false;

    public static bool IsRightChild<T>(this Maybe<TreeNode<T>> node)
      where T : notnull, IComparable<T>
      => node.HasValue ? node.Value.IsRightChild : false;

    public static void SetLeftParent<T>(this Maybe<TreeNode<T>> node, Maybe<TreeNode<T>> parent)
        where T : notnull, IComparable<T>
    {
        if (node.HasValue && node.Value.Left.HasValue)
            node.Value.Left.Value.Parent = parent;
    }

    public static void SetRightParent<T>(this Maybe<TreeNode<T>> node, Maybe<TreeNode<T>> parent)
        where T : notnull, IComparable<T>
    {
        if (node.HasValue && node.Value.Right.HasValue)
            node.Value.Right.Value.Parent = parent;
    }


    */

    public static string StringValue<T>(this TreeNode<T> node)
        where T : notnull, IComparable<T>
        => !node.IsNull ? node.Payload.ToString() ?? "NULL" : "Maybe<T>.None";

    public static string Direction<T>(this TreeNode<T> node)
        where T : notnull, IComparable<T>
      => node switch
      {
          _ when node.IsRoot => "Root",
          _ when node.IsLeftChild => "L",
          _ when node.IsRightChild => "R",
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

                Console.Write($"{currentNode.Payload}({currentNode.Parent.StringValue()}-{currentNode.Direction()}-size={currentNode.Size}) ");

                Console.ResetColor();

                if (!currentNode.Left.IsNull)
                    queue.Enqueue(currentNode.Left);

                if (!currentNode.Right.IsNull)
                    queue.Enqueue(currentNode.Right);
            }

            Console.WriteLine(); // Move to the next line after each level
        }

        Console.WriteLine();
    }
}
