using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AVL_Tree
{
    public class AVL<T> where T : IComparable<T>
    {
        Node<T> root = null;

        public void Balance(Node<T> node)
        {
            if (node.balance >= -1 && node.balance <= 1) return;


        }

        public void rightRotate(Node<T> node)
        {
            //Check if root or if it has a parent.  change the root.  Change the parents connection
            Node<T> temp = node.leftChild.rightChild;

            node.leftChild.rightChild = node;
            node.leftChild.parent = node.parent;

            if(node == root)
            {

            }
            node.parent = node.leftChild;

            node.leftChild = temp;    

            //TODO: Check to see if the node has is root or has parent nodes. If it is root. then you don't have to reconnect the left child. 
            //Else, find out if node is left or right child and connect it. 
        }


    }
}
