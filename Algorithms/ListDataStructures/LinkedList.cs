namespace Algorithms.ListDataStructures;

using System;
using System.Collections.Generic;

public class LinkedList<T> : IList<T>
    where T : notnull, IComparable<T>
{
    private readonly T[] array;
    private readonly Comparison<T> comparer;

    public LinkedList(T[] array, Comparison<T>? comparer = null)
    {
        this.array = array ?? throw new ArgumentNullException(nameof(array));

        Array.ForEach(this.array, x => this.Insert(x));

        this.comparer = comparer ?? Comparer<T>.Default.Compare;
    }

    public LinkedList(Comparison<T>? comparer = null)
        : this(new T[0], comparer)
    {
    }

    public int Length { get; private set; } = 0;

    public Maybe<Node> Head { get; private set; }

    public Maybe<Node> Tail { get; private set; }

    public void Enumerate(Action<T> action)
    {
        if (action is null) throw new ArgumentNullException(nameof(action));

        var n = this.Head;
        while (n.HasValue)
        {
            action(n.Value.Value);
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

        T max = this.Head.Value.Value;
        var n = this.Head.Value.Next;
        while (n.HasValue)
        {
            max = this.comparer(max, n.Value.Value) > 0 ? max : n.Value.Value;
            n = n.Value.Next;
        }

        return new(max);
    }

    public Maybe<T> Predecessor(T value)
    {
        throw new NotImplementedException();
    }

    public Maybe<int> Rank(T value)
    {
        throw new NotImplementedException();
    }

    public Maybe<T> Search(T value)
    {
        throw new NotImplementedException();
    }

    public class Node
    {
        public Node(T value)
        {
            this.Value = value;
            this.Next = Maybe<Node>.None;
            this.Previous = Maybe<Node>.None;
        }

        public Node(T value, Node next)
        {
            this.Value = value;
            this.Next = new(next);
            this.Previous = Maybe<Node>.None;
        }

        public Node(T value, Node next, Node previous)
        {
            this.Value = value;
            this.Next = new(next);
            this.Previous = new(previous);
        }

        public T Value { get; }

        public Maybe<Node> Next { get; internal set; }

        public Maybe<Node> Previous { get; internal set; }
    }
}
