using System;
using System.ComponentModel;

using AVL_Tree;
using Xunit;

namespace AVL.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void EmptyTreeHasNoCount ()
        {
            var tree = new AVL<int>();

            Assert.Equal(tree.Count, 0);
        }

        [Theory]
        [InlineData (new int[] {10, 5, 7})] //right-left
        [InlineData (new int[] {5, 10, 7})] //left-right
        [InlineData (new int[] {5, 7, 10 })] //left
        [InlineData (new int[] {10, 7, 5})] //right 
        public void InsertBalances (int[] arr)
        {
            var tree = new AVL<int>();

            for (int a = 0; a < arr.Length; a++)
            {
                tree.Insert(arr [a]);
            }

            bool balanced;

            if (tree.root.balance >= -1 && tree.root.balance <= 1) //if the tree is balanced
            {
                balanced = true;
            }
            else
            {
                balanced = false; 
            }

            Assert.True(balanced);
        }

        [Theory]
        [InlineData (123123, 10000)]
        [InlineData (945786, 99999)]
        //[InlineData (219876, 150000)]
        public void InsertWorksWithManyValues (int seed, int count)
        {
            Random gen = new Random(Guid.NewGuid().GetHashCode());
            var tree = new AVL<int>();

            for (int a = 0; a < count; a++)
            {
                tree.Insert(gen.Next());
            }

            Assert.Equal(tree.Count, count);
        }

        [Theory]
        [InlineData(123123, 10000)]
        [InlineData(945786, 99999)]
        [InlineData(219876, 100000)]
        public void InsertBalancesWithManyValues (int seed, int count)
        {
            Random gen = new Random(Guid.NewGuid().GetHashCode());
            var tree = new AVL<int>();

            for (int a = 0; a < count; a++)
            {
                tree.Insert(gen.Next());
            }

            bool balanced;

            if (tree.root.balance >= -1 && tree.root.balance <= 1)
            {
                balanced = true;
            }
            else
            {
                balanced = false;
            }

            Assert.True(balanced);
        }
    }
}
