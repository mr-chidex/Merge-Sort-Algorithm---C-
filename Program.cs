using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 3, 5, 7, 8, 3, 2, 6, 1 };

            Console.WriteLine("Unsorted");
            Console.WriteLine(string.Join(" ", array));
            Console.WriteLine();
            Merge(array);

            Console.WriteLine("Sorted");
            Console.WriteLine(string.Join(" ", array));

            Console.ReadKey();
        }

        private static void Merge(int[] array)
        {
            int[] temp = Merge(array, 0, array.Length - 1);
            Array.Copy(temp, array, temp.Length);
        }


        private static int[] Merge(int[] arr, int start, int end)
        {
            //To Split
            if (end - start < 1)
            {
                return new int[] { arr[start] };
            }


            int middle = (end + start) / 2;
            int[] left = Merge(arr, start, middle);
            int[] right = Merge(arr, middle + 1, end);

            //Temp storage
            int[] temp = new int[left.Length + right.Length];

            //Merge
            int indexLeft = 0;
            int indexRight = 0;
            int index = 0;

            while (indexLeft < left.Length && indexRight < right.Length)
            {
                if (left[indexLeft] < right[indexRight])
                {
                    temp[index++] = left[indexLeft++];
                }
                else
                {
                    temp[index++] = right[indexRight++];
                }
            }

            //Completing the Sort
            while (indexLeft < left.Length)
            {
                temp[index++] = left[indexLeft++];
            }
            while (indexRight < right.Length)
            {
                temp[index++] = right[indexRight++];
            }

            return temp;
        }
    }
}
