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

        if (!this.Root.HasValue)
        {
            this.Root = new(new(payload));
            return;
        }

        var node = this.InsertInSubtree(payload, this.Root.Value);
        node.SetColor(NodeColor.Red);
        this.Balance(node);
    }

    private void LeftRotate(Maybe<TreeNode<T>> pivot)
    {
        var temp = pivot.Right();
        pivot.SetRight(temp.Left());

        temp.SetLeftParent(pivot);

        temp.SetParent(pivot.Parent());

        if (!pivot.Parent().HasValue)
            this.Root = temp;
        else if (pivot.IsLeftChild())
            pivot.Parent().SetLeft(temp);
        else
            pivot.Parent().SetRight(temp);

        temp.SetLeft(pivot);
        pivot.SetParent(temp);

        pivot.SetSize(pivot.Left().Size() + pivot.Right().Size() + 1);
        pivot.Parent().SetSize(pivot.Size() + pivot.Parent().Right().Size() + 1);
    }

    private void RightRotate(Maybe<TreeNode<T>> pivot)
    {
        var temp = pivot.Left();
        pivot.SetLeft(temp.Right());

        temp.SetRightParent(pivot);

        temp.SetParent(pivot.Parent());

        if (!pivot.Parent().HasValue)
            this.Root = temp;
        else if (pivot.IsRightChild())
            pivot.Parent().SetRight(temp);
        else
            pivot.Parent().SetLeft(temp);

        temp.SetRight(pivot);
        pivot.SetParent(temp);

        pivot.SetSize(pivot.Left().Size() + pivot.Right().Size() + 1);
        pivot.Parent().SetSize(pivot.Size() + pivot.Parent().Left().Size() + 1);
    }

    private void Balance(Maybe<TreeNode<T>> root)
    {
        while (root.Parent().IsRed())
        {
            var uncle = root.Uncle();

            if (root.Parent().IsLeftChild())
            {
                if (uncle.IsRed())
                {
                    root.Parent().SetColor(NodeColor.Black);
                    uncle.SetColor(NodeColor.Black);
                    root.GrandParent().SetColor(NodeColor.Red);
                    root = root.GrandParent();
                }
                else if (root.IsRightChild())
                {
                    root = root.Parent();
                    this.LeftRotate(root);
                }
                else
                {
                    root.Parent().SetColor(NodeColor.Black);
                    root.GrandParent().SetColor(NodeColor.Red);
                    this.RightRotate(root.GrandParent());
                }
            }
            else
            {
                if (uncle.IsRed())
                {
                    root.Parent().SetColor(NodeColor.Black);
                    uncle.SetColor(NodeColor.Black);
                    root.GrandParent().SetColor(NodeColor.Red);
                    root = root.GrandParent();
                }
                else if (root.IsLeftChild())
                {
                    root = root.Parent();
                    this.RightRotate(root);
                }
                else
                {
                    root.Parent().SetColor(NodeColor.Black);
                    root.GrandParent().SetColor(NodeColor.Red);
                    this.LeftRotate(root.GrandParent());
                }
            }
        }

        this.Root.SetColor(NodeColor.Black);
    }
}
