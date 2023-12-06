namespace Algorithms.ListDataStructures;

using System;
using System.Collections.Generic;

public abstract class StructuredBinaryTree<T> : IStructuredList<T>
    where T : notnull, IComparable<T>
{
    public StructuredBinaryTree(T[] array, Comparison<T>? comparer = null)
    {
        this.Root = Maybe<TreeNode<T>>.None;
        this.Comparer = comparer ?? Comparer<T>.Default.Compare;

        if (array == null)
            throw new ArgumentNullException(nameof(array));
        Array.ForEach(array, x => this.Insert(x));
    }

    public StructuredBinaryTree(Comparison<T>? comparer = null)
        : this(Array.Empty<T>(), comparer)
    {
    }

    public Maybe<TreeNode<T>> Root { get; protected set; }

    public int Length { get; protected set; } = 0;

    public Comparison<T> Comparer { get; }

    public Maybe<T> Delete(T payload)
    {
        if (payload == null)
            throw new ArgumentNullException(nameof(payload));
        var node = this.SearchSubtree(payload, this.Root);

        if (!node.HasValue)
            return Maybe<T>.None;

        this.Delete(node.Value);
        return node.Unwrap();
    }

    public void Enumerate(Action<T> action)
    {
        if (action == null)
            throw new ArgumentNullException(nameof(action));
        this.EnumerateSubtree(action, this.Root);
    }

    public abstract void Insert(T payload);

    public Maybe<T> Max() => this.MaxOfSubtree(this.Root).Unwrap();

    public Maybe<T> Predecessor(T value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));
        return this.Predecessor(value, this.Root).Unwrap();
    }

    public int Rank(T value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));
        return this.Rank(value, this.Root);
    }

    public Maybe<T> Search(T value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));
        return this.SearchSubtree(value, this.Root).Unwrap();
    }

    protected Maybe<TreeNode<T>> InsertInSubtree(T payload, TreeNode<T> parent)
    {
        parent.Size++;

        if (this.Comparer(payload, parent.Payload) < 0)
        {
            if (parent.Left.HasValue)
                return this.InsertInSubtree(payload, parent.Left.Value);
            else
                parent.Left = new(new(payload, parent));

            return parent.Left;
        }
        else
        {
            if (parent.Right.HasValue)
                return this.InsertInSubtree(payload, parent.Right.Value);
            else
                parent.Right = new(new(payload, parent));

            return parent.Right;
        }
    }

    private void DecrementSize(Maybe<TreeNode<T>> node)
    {
        if (!node.HasValue)
            return;

        node.Value.Size--;
        this.DecrementSize(node.Value.Parent);
    }

    private void Delete(TreeNode<T> node)
    {
        switch (node.Degree)
        {
            case 0:
            case 1:
                this.DeleteDegreeOneOrLeaf(node);
                break;
            case 2:
                this.DeleteDegreeTwo(node);
                break;
            default:
                throw new InvalidOperationException("Invalid node degree");
        }
    }

    private void DeleteDegreeOneOrLeaf(TreeNode<T> node)
    {
        if (node.Degree > 1)
            throw new InvalidOperationException("Node is not leaf or degree one");

        var child = node.FirstChildWithValue;
        if (child.HasValue)
            child.Value.Parent = node.Parent;

        this.DecrementSize(node.Parent);
        this.Length--;

        if (node.IsRoot)
            this.Root = child;
        else if (node.IsLeftChild)
            node.Parent.Value.Left = child;
        else
            node.Parent.Value.Right = child;
    }

    private void DeleteDegreeTwo(TreeNode<T> node)
    {
        if (node.Degree != 2)
            throw new InvalidOperationException("Node is not Degree Two");

        var largestLeft = this.MaxOfSubtree(node.Left);
        node.Payload = largestLeft.Value.Payload;
        this.Delete(largestLeft.Value);
    }

    private void EnumerateSubtree(Action<T> action, Maybe<TreeNode<T>> node)
    {
        if (!node.HasValue)
            return;

        this.EnumerateSubtree(action, node.Value.Left);
        action(node.Value.Payload);
        this.EnumerateSubtree(action, node.Value.Right);
    }

    private Maybe<TreeNode<T>> MaxOfSubtree(Maybe<TreeNode<T>> node)
    {
        if (!node.HasValue)
            return Maybe<TreeNode<T>>.None;

        return (!node.Value.Right.HasValue) ? node : this.MaxOfSubtree(node.Value.Right);
    }

    private Maybe<TreeNode<T>> Predecessor(T value, Maybe<TreeNode<T>> node)
    {
        if (!node.HasValue)
            return Maybe<TreeNode<T>>.None;

        var rawNode = node.Value;
        var comparison = this.Comparer(rawNode.Payload, value);

        if (comparison == 0)
        {
            return this.MaxOfSubtree(rawNode.Left);
        }
        else if (comparison < 0)
        {
            var result = this.Predecessor(value, rawNode.Right);
            return result.HasValue ? result : new(rawNode);
        }
        else
        {
            return this.Predecessor(value, rawNode.Left);
        }
    }

    private int Rank(T value, Maybe<TreeNode<T>> node, int offset = 0)
    {
        if (!node.HasValue)
            return offset;

        var rawNode = node.Value;
        var comparison = this.Comparer(rawNode.Payload, value);

        return comparison switch
        {
            0 => offset + rawNode.LeftSize,
            < 0 => this.Rank(value, rawNode.Right, offset + rawNode.LeftSize + 1),
            _ => this.Rank(value, rawNode.Left, offset),
        };
    }

    private Maybe<TreeNode<T>> SearchSubtree(T value, Maybe<TreeNode<T>> node)
    {
        if (!node.HasValue)
            return Maybe<TreeNode<T>>.None;

        var comparison = this.Comparer(node.Value.Payload, value);

        return comparison switch
        {
            0 => node,
            < 0 => this.SearchSubtree(value, node.Value.Right),
            _ => this.SearchSubtree(value, node.Value.Left),
        };
    }
}
