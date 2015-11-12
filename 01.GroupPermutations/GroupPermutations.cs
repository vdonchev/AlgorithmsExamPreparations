namespace _01.GroupPermutations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class GroupPermutations
    {
        private static Dictionary<char, int> counts;
        static void Main(string[] args)
        {
            counts = new Dictionary<char, int>();
            var str = Console.ReadLine();

            foreach (var ch in str)
            {
                if (!counts.ContainsKey(ch))
                {
                    counts.Add(ch, 0);
                }

                counts[ch]++;
            }

            char[] items = str.Distinct().ToArray();
            Perm(items, 0);
        }

        static void Perm(char[] arr, int k)
        {
            if (k >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                Perm(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    Perm(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        private static void Swap<T>(ref T item1, ref T item2)
        {
            T temp = item1;
            item1 = item2;
            item2 = temp;
        }

        private static void Print(char[] arr)
        {
            var asd = arr.ToList().Select(s => new string(s, counts[s]));
            Console.WriteLine(string.Join("", asd));
        }
    }
}