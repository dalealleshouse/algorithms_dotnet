namespace Algorithms.ListDataStructures;

using System;

public class UnbalancedBinaryTree<T> : StructuredBinaryTree<T>
    where T : notnull, IComparable<T>
{
    public UnbalancedBinaryTree(T[] array, Comparison<T>? comparer = null)
      : base(array, comparer)
    {
    }

    public UnbalancedBinaryTree(Comparison<T>? comparer = null)
        : this(new T[0], comparer)
    {
    }

    public override void Insert(T payload)
    {
        if (payload == null)
            throw new ArgumentNullException(nameof(payload));

        this.Length++;

        if (this.Root.IsNull)
        {
            this.Root = new(payload);
            return;
        }

        this.InsertInSubtree(payload, this.Root);
    }

    public override Maybe<T> Delete(T payload)
    {
        if (payload == null)
            throw new ArgumentNullException(nameof(payload));
        var node = this.SearchSubtree(payload, this.Root);

        if (node.IsNull)
            return Maybe<T>.None;

        this.Delete(node);
        return node.Unwrap();
    }
}
