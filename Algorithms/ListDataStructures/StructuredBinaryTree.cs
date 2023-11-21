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

    public Maybe<T> Max() => this.MaxOfSubtree(this.Root);

    public Maybe<T> Predecessor(T value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        return this.Predecessor(value, this.Root);
    }

    public int Rank(T value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        return this.Rank(value, this.Root);
    }

    public Maybe<T> Search(T value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        return this.SearchSubtree(value, this.Root);
    }

    private Maybe<T> Predecessor(T value, Maybe<Node> node)
    {
        if (!node.HasValue) return Maybe<T>.None;

        var unwrapped = node.Value;
        var comparison = this.comparer(unwrapped.Payload, value);

        if (comparison == 0)
        {
            return this.MaxOfSubtree(unwrapped.Left);
        }
        else if (comparison < 0)
        {
            var result = this.Predecessor(value, unwrapped.Right);
            return result.HasValue ? result : new(unwrapped.Payload);
        }
        else
        {
            return this.Predecessor(value, unwrapped.Left);
        }
    }

    private int GetLeftSize(Node node) => node.Left.HasValue ? node.Left.Value.Size : 0;

    private int Rank(T value, Maybe<Node> node, int offset = 0)
    {
        if (!node.HasValue) return offset;

        var unwrapped = node.Value;
        var comparison = this.comparer(unwrapped.Payload, value);

        return comparison switch
        {
            0 => offset + this.GetLeftSize(unwrapped),
            < 0 => this.Rank(value, unwrapped.Right, offset + this.GetLeftSize(unwrapped) + 1),
            _ => this.Rank(value, unwrapped.Left, offset),
        };
    }

    private Maybe<T> SearchSubtree(T value, Maybe<Node> node)
    {
        if (!node.HasValue) return Maybe<T>.None;

        var comparison = this.comparer(node.Value.Payload, value);

        return comparison switch
        {
            0 => new Maybe<T>(node.Value.Payload),
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

    private Maybe<T> MaxOfSubtree(Maybe<Node> node)
    {
        if (!node.HasValue) return Maybe<T>.None;

        return (!node.Value.Right.HasValue) ?
            new(node.Value.Payload) :
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

        public T Payload { get; }

        public Maybe<Node> Parent { get; internal set; }

        public Maybe<Node> Left { get; internal set; }

        public Maybe<Node> Right { get; internal set; }
    }
}
