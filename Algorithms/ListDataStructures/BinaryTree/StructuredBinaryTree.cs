namespace Algorithms.ListDataStructures;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage(
        "StyleCop.CSharp.MaintainabilityRules",
        "SA1401:FieldsMustBePrivate",
        Justification = "A protected field is required for the derived class.")]
public abstract class StructuredBinaryTree<T> : IStructuredList<T>
    where T : notnull, IComparable<T>
{
    private readonly TreeNode<T> nullNode = TreeNode<T>.CreateNullNode();

    public StructuredBinaryTree(T[] array, Comparison<T>? comparer = null)
    {
        this.Root = this.nullNode;
        this.Comparer = comparer ?? Comparer<T>.Default.Compare;

        if (array == null)
            throw new ArgumentNullException(nameof(array));
        Array.ForEach(array, x => this.Insert(x));
    }

    public StructuredBinaryTree(Comparison<T>? comparer = null)
        : this(Array.Empty<T>(), comparer)
    {
    }

    public TreeNode<T> Root { get; protected set; }

    public int Length { get; protected set; } = 0;

    public Comparison<T> Comparer { get; }

    public TreeNode<T> NullNode => this.nullNode;

    public abstract Maybe<T> Delete(T payload);

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

    protected TreeNode<T> InsertInSubtree(T payload, TreeNode<T> parent)
    {
        parent.Size++;

        if (this.Comparer(payload, parent.Payload) < 0)
        {
            if (!parent.Left.IsNull)
                return this.InsertInSubtree(payload, parent.Left);
            else
                parent.Left = new(payload, parent, this.NullNode, this.NullNode);

            return parent.Left;
        }
        else
        {
            if (!parent.Right.IsNull)
                return this.InsertInSubtree(payload, parent.Right);
            else
                parent.Right = new(payload, parent, this.NullNode, this.NullNode);

            return parent.Right;
        }
    }

    protected TreeNode<T> SearchSubtree(T value, TreeNode<T> node)
    {
        if (node.IsNull)
            return node;

        var comparison = this.Comparer(node.Payload, value);

        return comparison switch
        {
            0 => node,
            < 0 => this.SearchSubtree(value, node.Right),
            _ => this.SearchSubtree(value, node.Left),
        };
    }

    protected TreeNode<T> Delete(TreeNode<T> node)
    {
        switch (node.Degree)
        {
            case 0:
            case 1:
                return this.DeleteDegreeOneOrLeaf(node);
            case 2:
                return this.DeleteDegreeTwo(node);
            default:
                throw new InvalidOperationException("Invalid node degree");
        }
    }

    private void DecrementSize(TreeNode<T> node)
    {
        if (node.IsNull)
            return;

        node.Size--;
        this.DecrementSize(node.Parent);
    }

    private TreeNode<T> DeleteDegreeOneOrLeaf(TreeNode<T> node)
    {
        if (node.Degree > 1)
            throw new InvalidOperationException("Node is not leaf or degree one");

        var child = node.FirstChildWithValue;
        child.Parent = node.Parent;

        this.DecrementSize(node.Parent);
        this.Length--;

        if (node.IsRoot)
            this.Root = child;
        else if (node.IsLeftChild)
            node.Parent.Left = child;
        else
            node.Parent.Right = child;

        return child;
    }

    private TreeNode<T> DeleteDegreeTwo(TreeNode<T> node)
    {
        if (node.Degree != 2)
            throw new InvalidOperationException("Node is not Degree Two");

        var largestLeft = this.MaxOfSubtree(node.Left);
        node.Payload = largestLeft.Payload;
        return this.Delete(largestLeft);
    }

    private void EnumerateSubtree(Action<T> action, TreeNode<T> node)
    {
        if (node.IsNull)
            return;

        this.EnumerateSubtree(action, node.Left);
        action(node.Payload);
        this.EnumerateSubtree(action, node.Right);
    }

    private TreeNode<T> MaxOfSubtree(TreeNode<T> node)
    {
        if (node.IsNull)
            return node;

        return node.Right.IsNull ? node : this.MaxOfSubtree(node.Right);
    }

    private TreeNode<T> Predecessor(T value, TreeNode<T> node)
    {
        if (node.IsNull)
            return node;

        var comparison = this.Comparer(node.Payload, value);

        if (comparison == 0)
        {
            return this.MaxOfSubtree(node.Left);
        }
        else if (comparison < 0)
        {
            var result = this.Predecessor(value, node.Right);
            return !result.IsNull ? result : node;
        }
        else
        {
            return this.Predecessor(value, node.Left);
        }
    }

    private int Rank(T value, TreeNode<T> node, int offset = 0)
    {
        if (node.IsNull)
            return offset;

        var comparison = this.Comparer(node.Payload, value);

        return comparison switch
        {
            0 => offset + node.LeftSize,
            < 0 => this.Rank(value, node.Right, offset + node.LeftSize + 1),
            _ => this.Rank(value, node.Left, offset),
        };
    }
}
