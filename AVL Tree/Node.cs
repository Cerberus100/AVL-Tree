using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AVL_Tree
{
    public class Node<T> where T : IComparable<T>
    {
        public T value;
        public Node<T> leftChild { get; set; }
        public Node<T> rightChild { get; set; }

        public bool isLeft
        {
            get
            {
                if (parent == null || parent.leftChild != this) return false;
                return true;
            }
        }

        public bool isRight
        {
            get
            {
                if (parent == null || parent.rightChild != this) return false;
                return true; 
            }
        }

        public int childCount
        {
            get
            {
                int count = 0;

                if (leftChild != null) count++;
                if (rightChild != null) count++;

                return count;
            }
        }

        public int height
        {
            get
            {
                int leftHeight = 0;

                if(leftChild != null)
                {
                    leftHeight = leftChild.height; 

                }


                int rightHeight = 0; 

                if(rightChild != null)
                {
                    rightHeight = rightChild.height; 
                }

                if (leftHeight <= rightHeight) return rightHeight + 1;
                else return leftHeight + 1; 
            }
      
        }

        public int balance
        {
            get
            {
                if (leftChild == null && rightChild == null)
                {
                    return 0;
                }
                else if (leftChild == null && rightChild != null)
                {
                    return rightChild.height;
                }
                else if (leftChild != null && rightChild == null)
                {
                    return 0 - leftChild.height;
                }
                else
                {
                    return rightChild.height - leftChild.height;
                }
            }
        }

        public Node(T Value)
        {
            value = Value;
        }
    }
}
