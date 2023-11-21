namespace Algorithms.ListDataStructures;

using System;
using System.Collections.Generic;

public class StructuredLinkedList<T> : IStructuredList<T>
    where T : notnull, IComparable<T>
{
    private readonly Comparison<T> comparer;

    public StructuredLinkedList(T[] array, Comparison<T>? comparer = null)
    {
        if (array == null) throw new ArgumentNullException(nameof(array));
        Array.ForEach(array, x => this.Insert(x));

        this.comparer = comparer ?? Comparer<T>.Default.Compare;
    }

    public StructuredLinkedList(Comparison<T>? comparer = null)
        : this(new T[0], comparer)
    {
    }

    public int Length { get; private set; } = 0;

    public Maybe<Node> Head { get; private set; }

    public Maybe<Node> Tail { get; private set; }

    public Comparison<T> Comparer => this.comparer;

    public void Enumerate(Action<T> action)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        var n = this.Head;
        while (n.HasValue)
        {
            action(n.Value.Payload);
            n = n.Value.Next;
        }
    }

    public void Insert(T item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));

        this.Length++;

        if (!this.Head.HasValue)
        {
            var node = new Node(item);
            this.Head = new(node);
            this.Tail = this.Head;
            return;
        }

        var head = new Node(item, this.Head.Value);
        this.Head.Value.Previous = new(head);
        this.Head = new(head);
    }

    public Maybe<T> Max()
    {
        if (this.Length == 0) return Maybe<T>.None;

        T max = this.Head.Value.Payload;
        var n = this.Head.Value.Next;
        while (n.HasValue)
        {
            max = this.comparer(max, n.Value.Payload) > 0 ? max : n.Value.Payload;
            n = n.Value.Next;
        }

        return new(max);
    }

    public Maybe<T> Predecessor(T value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));

        var result = Maybe<T>.None;
        var n = this.Head;
        while (n.HasValue)
        {
            if (this.comparer(n.Value.Payload, value) < 0)
            {
                if (!result.HasValue || this.comparer(result.Value, n.Value.Payload) < 0)
                {
                    result = new(n.Value.Payload);
                }
            }

            n = n.Value.Next;
        }

        return result;
    }

    public int Rank(T value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));

        var rank = 0;
        var n = this.Head;
        while (n.HasValue)
        {
            if (this.comparer(n.Value.Payload, value) < 0) rank++;
            n = n.Value.Next;
        }

        return rank;
    }

    public Maybe<T> Search(T value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        return this.Search(x => this.comparer(x, value) == 0);
    }

    public Maybe<T> Search(Predicate<T> predicate)
    {
        if (predicate == null) throw new System.ArgumentNullException();
        return this.SearchForNode(predicate).Unwrap();
    }

    public Maybe<T> Delete(T value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        var node = this.SearchForNode(x => this.comparer(x, value) == 0);

        if (!node.HasValue) return Maybe<T>.None;

        var rawNode = node.Value;

        if (rawNode.IsHead)
        {
            this.Head = node.Value.Next;
            this.Head.Value.Previous = Maybe<Node>.None;
        }
        else if (rawNode.IsTail)
        {
            this.Tail = node.Value.Previous;
            this.Tail.Value.Next = Maybe<Node>.None;
        }
        else
        {
            node.Value.Previous.Value.Next = node.Value.Next;
            node.Value.Next.Value.Previous = node.Value.Previous;
        }

        this.Length--;

        return node.Unwrap();
    }

    private Maybe<Node> SearchForNode(Predicate<T> predicate)
    {
        var n = this.Head;
        while (n.HasValue)
        {
            if (predicate(n.Value.Payload)) return n;
            n = n.Value.Next;
        }

        return Maybe<Node>.None;
    }

    public class Node
    {
        public Node(T value)
        {
            this.Payload = value;
            this.Next = Maybe<Node>.None;
            this.Previous = Maybe<Node>.None;
        }

        public Node(T value, Node next)
        {
            this.Payload = value;
            this.Next = new(next);
            this.Previous = Maybe<Node>.None;
        }

        public Node(T value, Node next, Node previous)
        {
            this.Payload = value;
            this.Next = new(next);
            this.Previous = new(previous);
        }

        public T Payload { get; }

        public Maybe<Node> Next { get; internal set; }

        public Maybe<Node> Previous { get; internal set; }

        public bool IsHead => !this.Previous.HasValue;

        public bool IsTail => !this.Next.HasValue;
    }
}
