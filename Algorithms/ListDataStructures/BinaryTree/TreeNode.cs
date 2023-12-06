namespace Algorithms.ListDataStructures;

using System;

public class TreeNode<T>
    where T : notnull, IComparable<T>
{
    public TreeNode(T value, TreeNode<T>? parent = null, TreeNode<T>? left = null, TreeNode<T>? right = null)
    {
        this.Payload = value;
        this.Parent = parent == null ? Maybe<TreeNode<T>>.None : new(parent);
        this.Left = left == null ? Maybe<TreeNode<T>>.None : new(left);
        this.Right = right == null ? Maybe<TreeNode<T>>.None : new(right);
    }

    public int Size { get; internal set; } = 1;

    public T Payload { get; internal set; }

    public Maybe<TreeNode<T>> Parent { get; internal set; }

    public Maybe<TreeNode<T>> Left { get; internal set; }

    public Maybe<TreeNode<T>> Right { get; internal set; }

    public NodeColor Color { get; internal set; } = NodeColor.Black;

    public bool IsLeaf => this.Degree == 0;

    public bool IsRoot => !this.Parent.HasValue;

    public bool IsLeftChild =>
        this.Parent.HasValue
        && this.Parent.Value.Left.HasValue
        && this.Parent.Value.Left.Value == this;

    public bool IsRightChild =>
        this.Parent.HasValue
        && this.Parent.Value.Right.HasValue
        && this.Parent.Value.Right.Value == this;

    public int Degree => (int)(this.Left.HasValue ? 1 : 0) + (this.Right.HasValue ? 1 : 0);

    public Maybe<TreeNode<T>> FirstChildWithValue => this.Left.HasValue ? this.Left : this.Right;

    public int LeftSize => this.Left.HasValue ? this.Left.Value.Size : 0;

    public int RightSize => this.Right.HasValue ? this.Right.Value.Size : 0;
}
