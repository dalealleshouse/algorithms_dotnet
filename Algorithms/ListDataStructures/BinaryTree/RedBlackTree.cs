namespace Algorithms.ListDataStructures;

using System;

public class RedBlackTree<T> : StructuredBinaryTree<T>
    where T : notnull, IComparable<T>
{
    public RedBlackTree(T[] array, Comparison<T>? comparer = null)
      : base(array, comparer)
    {
    }

    public RedBlackTree(Comparison<T>? comparer = null)
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
            this.Root = new(payload, this.NullNode, this.NullNode);
            return;
        }

        var node = this.InsertInSubtree(payload, this.Root);
        node.Color = NodeColor.Red;
        this.Balance(node);
    }

    public override Maybe<T> Delete(T payload)
    {
        if (payload == null)
            throw new ArgumentNullException(nameof(payload));
        var node = this.SearchSubtree(payload, this.Root);

        if (node.IsNull)
            return Maybe<T>.None;

        var returnValue = node.Unwrap();
        var isBlack = node.IsBlack();
        var replacement = this.Delete(node);

        if (isBlack)
            this.BlanceAfterDelete(replacement);

        return returnValue;
    }

    private void BlanceAfterDelete(TreeNode<T> node)
    {
        while (node != this.Root && node.IsBlack())
        {
            var sibling = node.Sibling();

            if (node.IsLeftChild())
            {
                if (sibling.IsRed())
                {
                    // case 3.1
                    sibling.Color = NodeColor.Black;
                    node.Parent.Color = NodeColor.Red;
                    this.LeftRotate(node.Parent);
                    sibling = node.Parent.Right;
                }

                if (sibling.Left.IsBlack() && sibling.Right.IsBlack())
                {
                    // case 3.2
                    sibling.Color = NodeColor.Red;
                    node = node.Parent;
                }
                else
                {
                    if (sibling.Right.IsBlack())
                    {
                        // case 3.3
                        sibling.Left.Color = NodeColor.Black;
                        sibling.Color = NodeColor.Red;
                        this.RightRotate(sibling);
                        sibling = node.Parent.Right;
                    }

                    // case 3.4
                    sibling.Color = node.Parent.Color;
                    node.Parent.Color = NodeColor.Black;
                    sibling.Right.Color = NodeColor.Black;
                    this.LeftRotate(node.Parent);
                    node = this.Root;
                }
            }
            else
            {
                if (sibling.IsRed())
                {
                    // case 3.1
                    sibling.Color = NodeColor.Black;
                    node.Parent.Color = NodeColor.Red;
                    this.RightRotate(node.Parent);
                    sibling = node.Parent.Left;
                }

                if (sibling.Left.IsBlack() && sibling.Right.IsBlack())
                {
                    // case 3.2
                    sibling.Color = NodeColor.Red;
                    node = node.Parent;
                }
                else
                {
                    if (sibling.Left.IsBlack())
                    {
                        // case 3.3
                        sibling.Right.Color = NodeColor.Black;
                        sibling.Color = NodeColor.Red;
                        this.LeftRotate(sibling);
                        sibling = node.Parent.Left;
                    }

                    // case 3.4
                    sibling.Color = node.Parent.Color;
                    node.Parent.Color = NodeColor.Black;
                    sibling.Left.Color = NodeColor.Black;
                    this.RightRotate(node.Parent);
                    node = this.Root;
                }
            }
        }

        node.Color = NodeColor.Black;
        this.NullNode.Parent = this.NullNode;
    }

    private void LeftRotate(TreeNode<T> pivot)
    {
        var temp = pivot.Right;
        pivot.Right = temp.Left;

        temp.Left.Parent = pivot;

        temp.Parent = pivot.Parent;

        if (pivot.Parent.IsNull)
            this.Root = temp;
        else if (pivot.IsLeftChild())
            pivot.Parent.Left = temp;
        else
            pivot.Parent.Right = temp;

        temp.Left = pivot;
        pivot.Parent = temp;

        pivot.Size = pivot.Left.Size + pivot.Right.Size + 1;
        pivot.Parent.Size = pivot.Size + pivot.Parent.Right.Size + 1;
    }

    private void RightRotate(TreeNode<T> pivot)
    {
        var temp = pivot.Left;
        pivot.Left = temp.Right;

        temp.Right.Parent = pivot;

        temp.Parent = pivot.Parent;

        if (pivot.Parent.IsNull)
            this.Root = temp;
        else if (pivot.IsRightChild())
            pivot.Parent.Right = temp;
        else
            pivot.Parent.Left = temp;

        temp.Right = pivot;
        pivot.Parent = temp;

        pivot.Size = pivot.Left.Size + pivot.Right.Size + 1;
        pivot.Parent.Size = pivot.Size + pivot.Parent.Left.Size + 1;
    }

    private void Balance(TreeNode<T> root)
    {
        while (root.Parent.IsRed())
        {
            var uncle = root.Uncle();

            if (uncle.IsRed())
            {
                root.Parent.Color = NodeColor.Black;
                uncle.Color = NodeColor.Black;
                root.GrandParent().Color = NodeColor.Red;
                root = root.GrandParent();
                continue;
            }

            if (root.Parent.IsLeftChild())
            {
                if (root.IsRightChild())
                {
                    root = root.Parent;
                    this.LeftRotate(root);
                    continue;
                }

                root.Parent.Color = NodeColor.Black;
                root.GrandParent().Color = NodeColor.Red;
                this.RightRotate(root.GrandParent());
            }
            else
            {
                if (root.IsLeftChild())
                {
                    root = root.Parent;
                    this.RightRotate(root);
                    continue;
                }

                root.Parent.Color = NodeColor.Black;
                root.GrandParent().Color = NodeColor.Red;
                this.LeftRotate(root.GrandParent());
            }
        }

        this.Root.Color = NodeColor.Black;
    }
}
