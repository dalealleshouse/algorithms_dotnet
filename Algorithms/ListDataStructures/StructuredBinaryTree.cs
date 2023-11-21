namespace Algorithms.ListDataStructures;

using System;
using System.Collections.Generic;

public class StructuredBinaryTree<T> : IStructuredList<T>
    where T : notnull, IComparable<T>
{
    private readonly Comparison<T> comparer;
    private int length = 0;

    public StructuredBinaryTree(T[] array, Comparison<T>? comparer = null)
    {
        this.Root = Maybe<Node>.None;
        this.comparer = comparer ?? Comparer<T>.Default.Compare;

        if (array == null) throw new ArgumentNullException(nameof(array));
        Array.ForEach(array, x => this.Insert(x));
    }

    public StructuredBinaryTree(Comparison<T>? comparer = null)
        : this(new T[0], comparer)
    {
    }

    public Maybe<Node> Root { get; private set; }

    public int Length => this.length;

    public Comparison<T> Comparer => this.comparer;

    public void Enumerate(Action<T> action)
    {
        if (action == null) throw new ArgumentNullException(nameof(action));
        this.EnumerateSubtree(action, this.Root);
    }

    public void Insert(T payload)
    {
        if (payload == null) throw new ArgumentNullException(nameof(payload));

        this.length++;

        if (!this.Root.HasValue)
        {
            this.Root = new(new(payload));
            return;
        }

        this.InsertInSubtree(payload, this.Root.Value);
    }

    public Maybe<T> Delete(T payload)
    {
        if (payload == null) throw new ArgumentNullException(nameof(payload));
        var node = this.SearchSubtree(payload, this.Root);

        if (!node.HasValue) return Maybe<T>.None;

        this.Delete(node.Value);
        return node.Unwrap();
    }

    public Maybe<T> Max() => this.MaxOfSubtree(this.Root).Unwrap();

    public Maybe<T> Predecessor(T value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        return this.Predecessor(value, this.Root).Unwrap();
    }

    public int Rank(T value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        return this.Rank(value, this.Root);
    }

    public Maybe<T> Search(T value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        return this.SearchSubtree(value, this.Root).Unwrap();
    }

    private void Delete(Node node)
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

    private void DecrementSize(Maybe<Node> node)
    {
        if (!node.HasValue) return;

        node.Value.Size--;
        this.DecrementSize(node.Value.Parent);
    }

    private void DeleteDegreeTwo(Node node)
    {
        if (node.Degree != 2) throw new InvalidOperationException("Node is not Degree Two");

        var largestLeft = this.MaxOfSubtree(node.Left);
        node.Payload = largestLeft.Value.Payload;
        this.Delete(largestLeft.Value);
    }

    private void DeleteDegreeOneOrLeaf(Node node)
    {
        if (node.Degree > 1) throw new InvalidOperationException("Node is not leaf or degree one");

        var child = node.FirstChildWithValue;
        if (child.HasValue) child.Value.Parent = node.Parent;

        this.DecrementSize(node.Parent);
        this.length--;

        if (node.IsRoot)
            this.Root = child;
        else if (node.IsLeftChild)
            node.Parent.Value.Left = child;
        else
            node.Parent.Value.Right = child;
    }

    private Maybe<Node> Predecessor(T value, Maybe<Node> node)
    {
        if (!node.HasValue) return Maybe<Node>.None;

        var rawNode = node.Value;
        var comparison = this.comparer(rawNode.Payload, value);

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

    private int Rank(T value, Maybe<Node> node, int offset = 0)
    {
        if (!node.HasValue) return offset;

        var rawNode = node.Value;
        var comparison = this.comparer(rawNode.Payload, value);

        return comparison switch
        {
            0 => offset + rawNode.LeftSize,
            < 0 => this.Rank(value, rawNode.Right, offset + rawNode.LeftSize + 1),
            _ => this.Rank(value, rawNode.Left, offset),
        };
    }

    private Maybe<Node> SearchSubtree(T value, Maybe<Node> node)
    {
        if (!node.HasValue) return Maybe<Node>.None;

        var comparison = this.comparer(node.Value.Payload, value);

        return comparison switch
        {
            0 => node,
            < 0 => this.SearchSubtree(value, node.Value.Right),
            _ => this.SearchSubtree(value, node.Value.Left),
        };
    }

    private void InsertInSubtree(T payload, Node parent)
    {
        parent.Size++;

        if (this.comparer(payload, parent.Payload) < 0)
        {
            if (parent.Left.HasValue)
                this.InsertInSubtree(payload, parent.Left.Value);
            else
                parent.Left = new(new(payload, parent));
        }
        else
        {
            if (parent.Right.HasValue)
                this.InsertInSubtree(payload, parent.Right.Value);
            else
                parent.Right = new(new(payload, parent));
        }
    }

    private void EnumerateSubtree(Action<T> action, Maybe<Node> node)
    {
        if (!node.HasValue) return;

        this.EnumerateSubtree(action, node.Value.Left);
        action(node.Value.Payload);
        this.EnumerateSubtree(action, node.Value.Right);
    }

    private Maybe<Node> MaxOfSubtree(Maybe<Node> node)
    {
        if (!node.HasValue) return Maybe<Node>.None;

        return (!node.Value.Right.HasValue) ?
            node :
            this.MaxOfSubtree(node.Value.Right);
    }

    public class Node
    {
        public Node(T value, Node? parent = null, Node? left = null, Node? right = null)
        {
            this.Payload = value;
            this.Parent = parent == null ? Maybe<Node>.None : new(parent);
            this.Left = left == null ? Maybe<Node>.None : new(left);
            this.Right = right == null ? Maybe<Node>.None : new(right);
        }

        public int Size { get; internal set; } = 1;

        public T Payload { get; internal set; }

        public Maybe<Node> Parent { get; internal set; }

        public Maybe<Node> Left { get; internal set; }

        public Maybe<Node> Right { get; internal set; }

        public bool IsLeaf => this.Degree == 0;

        public bool IsRoot => !this.Parent.HasValue;

        public bool IsLeftChild => this.Parent.HasValue && this.Parent.Value.Left.HasValue && this.Parent.Value.Left.Value == this;

        public bool IsRightChild => this.Parent.HasValue && this.Parent.Value.Right.HasValue && this.Parent.Value.Right.Value == this;

        public int Degree => (int)(this.Left.HasValue ? 1 : 0) + (this.Right.HasValue ? 1 : 0);

        public Maybe<Node> FirstChildWithValue => this.Left.HasValue ? this.Left : this.Right;

        public int LeftSize => this.Left.HasValue ? this.Left.Value.Size : 0;

        public int RightSize => this.Right.HasValue ? this.Right.Value.Size : 0;
    }
}
