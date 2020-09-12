using System;

namespace AVL_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var avl = new AVL<int>();


            avl.Insert(50);
            avl.Insert(25);
            avl.Insert(10);
            avl.rightRotate(avl.root);
            ;
        }
    }
}
