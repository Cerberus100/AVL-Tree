using System;

namespace AVL_Tree
{
    class Program
    {
        static void Main(string[] args) 
        {
            var avl = new AVL<int>();
            //TODO: test preOrder, finish inOrder and post order

            avl.Insert(50);
            avl.Insert(25);
            avl.Insert(75);
            avl.Insert(30);

            
        }
    }
}
