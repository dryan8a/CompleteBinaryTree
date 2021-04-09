using System;
using Xunit;
using CompleteBinaryTree;

namespace CBTTests
{
    public class SubTreeConstructorTests
    {
        [Theory]
        [InlineData(new object[] { new int[] { 0, 2, 3, 4, 5, 6 }, 2 })]
        [InlineData(new object[] { new int[] { 0, 2, 3, 4, 5, 6 }, 3 })]
        [InlineData(new object[] { new int[] { 1 }, 1 })]
        [InlineData(new object[] { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 1 })]
        [InlineData(new object[] { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 2 })]
        [InlineData(new object[] { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 3 })]
        [InlineData(new object[] { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 4 })]
        [InlineData(new object[] { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 5 })]
        public void SubTreeConstructorTest(int[] data, int subTreeHeadVal)
        {
            var originalTree = new CBT<int>();
            foreach(int datum in data)
            {
                originalTree.Insert(datum);
            }

            var newTree = new CBT<int>(originalTree,subTreeHeadVal);


            void RecursiveCheck(int originalVal, int newVal)
            {
                Assert.True(originalVal == newVal);

                Assert.Equal(originalTree.HasLeftChild(originalVal), newTree.HasLeftChild(newVal));
                Assert.Equal(originalTree.HasRightChild(originalVal), newTree.HasRightChild(newVal));

                if (newTree.HasLeftChild(newVal))
                {
                    RecursiveCheck(originalTree.GetLeftChild(originalVal), newTree.GetLeftChild(newVal));
                }

                if(newTree.HasRightChild(newVal))
                {
                    RecursiveCheck(originalTree.GetRightChild(originalVal), newTree.GetRightChild(newVal));
                }
            }


            RecursiveCheck(subTreeHeadVal, subTreeHeadVal);
        }
    }
}
