using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _221021
{
    // 일반화 델리게이트
    delegate int Compare<T>(T a, T b);

    internal class Sort
    {
        public void Start()
        {
            int[] array = { 5, 1, 3, 2, 7, 9, 10, 0, 6 };
            Console.WriteLine($"정렬 전 : {string.Join(',', array)}");
            Console.Write("오름차순 ");
            BubbleSort(array, Compare);
            Console.WriteLine($"정렬 후 : {string.Join(',', array)}");
            Console.WriteLine();

            string[] array2 = { "EE", "AA", "DD", "CC", "BB" };
            Console.WriteLine($"정렬 전 : {string.Join(',', array2)}");
            Console.Write("내림차순 ");
            BubbleSort(array2, Compare, false);
            Console.WriteLine($"정렬 후 : {string.Join(',', array2)}");

            // 
            List<string> list = new List<string>();
            list.Add("DD");
            list.Add("AA");
            list.Add("KK");

            list.Sort(Compare);

            Console.WriteLine(string.Join(',', list));

        }
        void BubbleSort<T>(T[] array,Compare<T> compare, bool isAscending = true)
        {
            int com = isAscending ? -1 : 1;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (compare(array[i], array[j]) == com)
                        Swap(array, i, j);
                }

            }
            void Swap<T>(T[] array, int a, int b)
            {
                T temp = array[a];
                array[a] = array[b];
                array[b] = temp;
            }
        }

        int Compare(int a, int b)
        {
            if (a > b)
                return -1;
            else if (a < b)
                return 1;
            else
                return 0;
        }
        int Compare(string a, string b)
        {
            int aNum = 0;
            int bNum = 0;

            foreach (char c in a)
                aNum += c;

            foreach (char c in b)
                bNum += c;
            if (aNum > bNum)
                return -1;
            else if (aNum < bNum)
                return 1;
            else
                return 0;

        }
    }
}
