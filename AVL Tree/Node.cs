using System;
using System.Collections.Generic;
using System.Text;

namespace AVL_Tree
{
    public class Node<T> where T : IComparable<T>
    {
        T value;
        public Node<T> parent { get; set; }
        public Node<T> leftChild { get; set; }
        public Node<T> rightChild { get; set; }

        int childCount 
        {
            get
            {
                int count = 0;

                if (leftChild != null) count++;
                if (rightChild != null) count++;

                return count; 
            }
        }

        int height { get; set; }

        int balance
        {
            get
            {

            }
        }

        public Node(T Value)
        {
            value = Value;
            height = 1; 
        }

    }
}
