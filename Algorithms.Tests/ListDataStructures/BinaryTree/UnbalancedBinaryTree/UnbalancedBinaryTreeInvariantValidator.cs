namespace Algorithms.Tests.ListDataStructures.UnbalancedBinaryTree;

using System;
using Algorithms.ListDataStructures;
using Algorithms.Tests.ListDataStructures.StructuredBinaryTree;

public class UnbalancedBinaryTreeInvariantValidator<T> : BinaryTreeInvariantValidator<T>
    where T : notnull, IComparable<T>
{
    private readonly UnbalancedBinaryTree<T> sut;

    public UnbalancedBinaryTreeInvariantValidator(IStructuredList<T> sut)
      : base(sut)
    {
        this.sut = (UnbalancedBinaryTree<T>)sut;
    }

    public override void Validate()
    {
        base.Validate();
    }
}
