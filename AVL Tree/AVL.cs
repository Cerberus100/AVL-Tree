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

            if (node.balance < -1)
            {
                node.leftChild = rightRotate(node);
            }
            else
            {
                node.rightChild = leftRotate(node);
            }
        }
        //TODO: double check if find parent works, implement it into insert with balance and stuff. 
        public Node<T> findParent(Node<T> node)
        {
            Node<T> p = parentRecur(root, node);

            return p; 
        }

        private Node<T> parentRecur(Node<T> start, Node<T> node)
        {
            if(start == node) // if it's root
            {
                return null;
            }
            else if(start.value.CompareTo(node.value) > 0)
            {
                //

                if (start.leftChild == node) return start; 

                return parentRecur(start.leftChild, node);
            }
            else
            {
                //

                if (start.rightChild == node) return start; 
                return parentRecur(start.rightChild, node);
            }
        }

        public Node<T> rightRotate(Node<T> node)
        {
            Node<T> temp = node.leftChild;

            node.leftChild = temp.rightChild;

            temp.rightChild = node; 

            return temp;
        }

        public Node<T> leftRotate(Node<T> node)
        {
            Node<T> temp = node.rightChild;

            node.rightChild = temp.leftChild;

            temp.leftChild = node; 

            return temp;
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

            //implement balancing here

            return node;
        }




    }
}
