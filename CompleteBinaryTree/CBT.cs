using System;
using System.Collections.Generic;
using System.Text;

namespace CompleteBinaryTree
{
    /// <summary>
    /// Complete Binary Tree; doesn't allow duplicate values
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CBT<T>
    {
        private List<T> Data;
        public T Head { get => Data[0]; }
        public int NodeCount { get => Data.Count; }

        public CBT()
        {
            Data = new List<T>();
        }

        /// <summary>
        /// Creates a new CBT based on a sub-tree of an existing CBT
        /// </summary>
        /// <param name="fullTree">The CBT containing the sub-tree to take from</param>
        /// <param name="subTreeHeadVal">The value of the head of the desired sub-tree</param>
        public CBT(CBT<T> fullTree, T subTreeHeadVal)
        {
            Data = new List<T>();

            var valueQueue = new Queue<T>(); //Preorder traversal to get the correct order of nodes
            valueQueue.Enqueue(subTreeHeadVal);
            while(valueQueue.Count > 0)
            {
                T value = valueQueue.Dequeue();

                if (fullTree.HasLeftChild(value))
                {
                    valueQueue.Enqueue(fullTree.GetLeftChild(value));
                }
                if (fullTree.HasRightChild(value))
                {
                    valueQueue.Enqueue(fullTree.GetRightChild(value));
                }

                Data.Add(value);
            }
        }

        public T GetParent(T value)
        {
            return Data[(Data.IndexOf(value) - 1) / 2];
        }
        public T GetLeftChild(T value)
        {
            return Data[Data.IndexOf(value) * 2 + 1];
        }
        public T GetRightChild(T value)
        {
            return Data[Data.IndexOf(value) * 2 + 2];
        }

        public bool HasLeftChild(T value)
        {
            return Data.IndexOf(value) * 2 + 1 < Data.Count;
        }
        public bool HasRightChild(T value)
        {
            return Data.IndexOf(value) * 2 + 2 < Data.Count;
        }

        /// <summary>
        /// Inserts value into the tree; throws on duplicate value
        /// </summary>
        /// <param name="value">Value to insert</param>
        /// <returns>Value of the parent to the added node</returns>
        public T Insert(T value)
        {
            Data.Add(value);

            return GetParent(value);
        }
    }
}
