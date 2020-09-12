using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AVL_Tree
{
    public class AVL<T> where T : IComparable<T>
    {
        public Node<T> root = null;
        public int Count = 0;

        public void Balance(Node<T> node)
        {
            if (node.balance >= -1 && node.balance <= 1) return;


        }

        public void rightRotate(Node<T> node)
        {
            //Check if root or if it has a parent.  change the root.  Change the parents connection




            /*
            Node<T> temp = node.leftChild.rightChild;

            node.leftChild.rightChild = node;
            node.leftChild.parent = node.parent;

            if(node.parent != null)
            {
                if(node.isLeft)
                {
                    node.parent.leftChild = node.leftChild;
                }
                else
                {
                    node.parent.rightChild = node.leftChild;
                }
            }

            node.parent = node.leftChild;

            node.leftChild = temp;    
            */

            //TODO: have karan show me how rightRotate works 
        }

        public void Insert (T value)
        {
            root = recInsert(root, value);
            Count++;

            //check height & balance
        }

        //recursive function for insert
        private Node<T> recInsert(Node<T> node, T val)
        {
            if (node == null)
            {
                return new Node<T>(val);
            }
            int comp = val.CompareTo(node.value);

            if (comp < 0)
            {
                node.leftChild = recInsert(node.leftChild, val);
            }
            else
            {
                node.rightChild = recInsert(node.rightChild, val);
            }

            return node;
        }




    }
}
