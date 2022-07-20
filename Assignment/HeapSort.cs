using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    //Class which takes an array of tools and sorts them based on the number of times borrowed
    class HeapSortObj
    {
        private static void HeapBottomUp(Tool[] data)
        {
            int n = data.Count(s => s != null);
            for (int i = (n - 1) / 2; i >= 0; i--)
            {
                int k = i;
                Tool v = data[i];
                bool heap = false;
                while ((!heap) && ((2 * k + 1) <= (n - 1)))
                {
                    int j = 2 * k + 1;  //the left child of k
                    if (j < (n - 1))   //k has two children
                        if (data[j].NoBorrowings < data[j + 1].NoBorrowings)
                            j = j + 1;  //j is the larger child of k
                    if (v.NoBorrowings >= data[j].NoBorrowings)
                        heap = true;
                    else
                    {
                        data[k] = data[j];
                        k = j;
                    }
                }
                data[k] = v;
            }
        }

        //delete the maximum key and rebuild the heap
        private static void MaxKeyDelete(Tool[] data, int size)
        {
            //1. Exchange the root’s key with the last key K of the heap;
            Tool temp = data[0];
            data[0] = data[size - 1];
            data[size - 1] = temp;

            //2. Decrease the heap’s size by 1;
            int n = size - 1;

            //3. “Heapify” the complete binary tree.
            bool heap = false;
            int k = 0;
            Tool v = data[0];
            while ((!heap) && ((2 * k + 1) <= (n - 1)))
            {
                int j = 2 * k + 1; //the left child of k
                if (j < (n - 1))   //k has two children
                    if (data[j].NoBorrowings < data[j + 1].NoBorrowings)
                        j = j + 1;  //j is the larger child of k
                if (v.NoBorrowings >= data[j].NoBorrowings)
                    heap = true;
                else
                {
                    data[k] = data[j];
                    k = j;
                }
            }
            data[k] = v;
        }

        // sort the elements in an array 
        public static void HeapSort(Tool[] data)
        {
            //Use the HeapBottomUp procedure to convert the array, data, into a heap
            HeapBottomUp(data);


            //repeatly remove the maximum key from the heap and then rebuild the heap
            for (int i = 0; i <= data.Count(s => s != null) - 2; i++)
            {
                MaxKeyDelete(data, data.Count(s => s != null) - i);
            }
        }
    }
}


