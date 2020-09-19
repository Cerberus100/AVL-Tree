using System;

namespace AVL_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var avl = new AVL<int>();

            avl.Insert(50);
            avl.Insert(75);
            avl.Insert(75);

            var node = avl.findParent(avl.root);

            ;
        }
    }
}
