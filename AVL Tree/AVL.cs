using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace AVL_Tree
{
    public class AVL<T> where T : IComparable<T>
    {
        public Node<T> root = null;
        public int Count = 0;

        public Node<T> Balance(Node<T> node)
        {
            if (node.balance < -1)
            {
                if (node.leftChild.balance >= 1)
                {
                    node.leftChild = leftRotate(node.leftChild);
                }

                node = rightRotate(node);
            }
            else if (node.balance > 1)
            {
                if (node.rightChild.balance <= -1)
                {
                    node.rightChild = rightRotate(node.rightChild);
                }

                node = leftRotate(node);
            }

            return node;
        }

        public Node<T> findParent(Node<T> node)
        {
            //Node<T> p = parentRecur(root, node);

            Node<T> current = root;

            // if root
            if (current == node)
            {
                return null;
            }

            // otherwise
            while(current != null)
            {
                if (current.leftChild == node || current.rightChild == node)
                {
                    return current;
                }
                if (node.value.CompareTo(current.value) < 0)
                {
                    current = current.leftChild;
                }
                else
                {
                    current = current.rightChild;
                }

            }

            return null;
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


        public void Insert(T value)
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
            return Balance(node);
        }


        public bool Delete (T value)
        {
            int beforeCount = Count;
            root = deleteRecur(value);

            if (beforeCount == Count)//if nothing was removed
            {
                return false;
            }

            return true; 
        }

        private Node<T> deleteRecur(T value) //recursion for Delete
        {
            Node<T> node = Search(value);

            if (findParent(node) == null)
            {
                return null; 
            }
            

            if (node.childCount == 2)
            {
                Node<T> replacement = node.leftChild;

                while (replacement.rightChild != null)
                {
                    replacement = replacement.rightChild; 
                }

                node.value = replacement.value;

                node = replacement;
            }

            Node<T> parent = findParent(node);

            if (node.childCount == 0) // if no children
            {
                if (parent == null)
                {
                    root = null; 
                }
                else
                {
                    if (parent.leftChild.Equals(node))
                    {
                        parent.leftChild = null; 
                    }
                    else
                    {
                        parent.rightChild = null; 
                    }
                }
            }
            else if (node.childCount == 1) // if one child
            {
                if (node.leftChild != null)
                {
                    if (parent == null)
                    {
                        root = node.leftChild;  
                    }
                    else
                    {
                        parent.leftChild = node.leftChild; 
                    }
                }
                else
                {
                    if (parent == null)
                    {
                        root = node.rightChild;
                    }
                    else
                    {
                        parent.rightChild = node.rightChild; 
                    }
                }
            }

            Count--;
            return Balance (parent);
        }

        public Node<T> Search(T value)
        {
            return recSearch(root, value);
        }

        private Node<T> recSearch(Node<T> node, T value)
        {
            if (node == null)
            {
                return null;
            }
            int compare = value.CompareTo(node.value);
            if (compare == 0)
            {
                return node;
            }
            else if (compare < 0)
            {
                node = node.leftChild;
            }
            else
            {
                node = node.rightChild;
            }
            return recSearch(node, value);
        }

        public List<T> preOrder ()
        {
            List<T> values = new List<T>();

            preOrderRec(root, values);

            return values;
        }

        private void preOrderRec(Node<T> node, List<T> list)
        {
            if (node == null)
            {
                return; 
            }

            list.Add(node.value);
            preOrderRec(node.leftChild, list);
            preOrderRec(node.rightChild, list);
        }

        public List<T> inOrder ()
        {
            List<T> list = new List<T>();

            inOrderRec(root, list);

            return list;
        }

        private void inOrderRec (Node<T> node, List<T> list)
        {
            if (node == null)
            {
                return;
            }

            inOrderRec(node.leftChild, list);
            list.Add(node.value);
            inOrderRec(node.rightChild, list);
        }

        public List<T> postOrder ()
        {
            List<T> list = new List<T>();
            postOrderRec(root, list);
            return list;
        }

        private void postOrderRec (Node<T> node, List<T> list)
        {
            if (node == null)
            {
                return;
            }

            postOrderRec(node.leftChild, list);
            postOrderRec(node.rightChild, list);
            list.Add(node.value);
        }

        public List<T> breadthFirst ()
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            List<T> list = new List<T>();
             
            queue.Enqueue(root);


            while (queue.Count > 0)
            {
                Node<T> node = queue.Dequeue();

                list.Add(node.value);

                if (node.leftChild != null)
                {
                    queue.Enqueue(node.leftChild);
                }

                if (node.rightChild != null)
                {
                    queue.Enqueue(node.rightChild);
                }
            }

            return list; 
        }
    }
}
