namespace Algorithms.ListDataStructures;

using System;

public class TreeNode<T>
    where T : notnull, IComparable<T>
{
    public TreeNode(T value, TreeNode<T> parent, TreeNode<T> left, TreeNode<T> right)
    {
        this.Payload = value;
        this.Parent = parent;
        this.Left = left;
        this.Right = right;
    }

    private TreeNode()
    {
        this.Payload = default!;
        this.Parent = this;
        this.Left = this;
        this.Right = this;
        this.Size = 0;
        this.IsNull = true;
    }

    public int Size { get; internal set; } = 1;

    public T Payload { get; internal set; }

    public TreeNode<T> Parent { get; internal set; }

    public TreeNode<T> Left { get; internal set; }

    public TreeNode<T> Right { get; internal set; }

    public NodeColor Color { get; internal set; } = NodeColor.Black;

    public bool IsNull { get; private set; } = false;

    public bool IsLeaf => this.Degree == 0;

    public bool IsRoot => this.Parent.IsNull;

    public bool IsLeftChild => this.Parent.Left == this;

    public bool IsRightChild => this.Parent.Right == this;

    public int Degree => (int)(!this.Left.IsNull ? 1 : 0) + (!this.Right.IsNull ? 1 : 0);

    public TreeNode<T> FirstChildWithValue => !this.Left.IsNull ? this.Left : this.Right;

    public int LeftSize => !this.Left.IsNull ? this.Left.Size : 0;

    public int RightSize => !this.Right.IsNull ? this.Right.Size : 0;

    public bool IsRed => this.Color == NodeColor.Red;

    public bool IsBlack => this.Color == NodeColor.Black;

    public static TreeNode<T> CreateNullNode() => new();

    public TreeNode<T> Sibling()
      => this.IsLeftChild ? this.Parent.Right : this.Parent.Left;

    public TreeNode<T> Uncle()
      => this.Parent.Sibling();

    public TreeNode<T> GrandParent()
      => this.Parent.Parent;
}
