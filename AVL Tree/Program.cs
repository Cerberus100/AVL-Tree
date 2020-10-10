using System;
using System.Collections.Generic;

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

            var list = avl.breadthFirst();

            for (int a = 0; a < list.Count; a++)
            {
                Console.WriteLine(list[a]);
            }
        }
    }
}
