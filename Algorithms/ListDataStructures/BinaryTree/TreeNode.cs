namespace Algorithms.ListDataStructures;

using System;

public class TreeNode<T>
    where T : notnull, IComparable<T>
{
    private static readonly TreeNode<T> NullNode;

    static TreeNode()
    {
        NullNode = new TreeNode<T>();
        NullNode.Size = 0;
        NullNode.Parent = NullNode;
        NullNode.Left = NullNode;
        NullNode.Right = NullNode;
    }

    public TreeNode(T value, TreeNode<T>? parent = null, TreeNode<T>? left = null, TreeNode<T>? right = null)
    {
        this.Payload = value;
        this.Parent = parent == null ? NullNode : parent;
        this.Left = left == null ? NullNode : left;
        this.Right = right == null ? NullNode : right;
    }

    private TreeNode()
    {
        this.Payload = default!;
    }

    public int Size { get; internal set; } = 1;

    public T Payload { get; internal set; }

    public TreeNode<T> Parent { get; internal set; } = NullNode;

    public TreeNode<T> Left { get; internal set; } = NullNode;

    public TreeNode<T> Right { get; internal set; } = NullNode;

    public NodeColor Color { get; internal set; } = NodeColor.Black;

    public bool IsNull => this == NullNode;

    public bool IsLeaf => this.Degree == 0;

    public bool IsRoot => this.Parent == NullNode;

    public bool IsLeftChild => this.Parent.Left == this;

    public bool IsRightChild => this.Parent.Right == this;

    public int Degree => (int)(!this.Left.IsNull ? 1 : 0) + (!this.Right.IsNull ? 1 : 0);

    public TreeNode<T> FirstChildWithValue => !this.Left.IsNull ? this.Left : this.Right;

    public int LeftSize => !this.Left.IsNull ? this.Left.Size : 0;

    public int RightSize => !this.Right.IsNull ? this.Right.Size : 0;

    public static TreeNode<T> GetNullNode() => NullNode;

    public TreeNode<T> Sibling()
      => this.IsLeftChild ? this.Parent.Right : this.Parent.Left;

    public TreeNode<T> Uncle()
      => this.Parent.Sibling();
}
