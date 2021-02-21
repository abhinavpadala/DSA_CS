using System;
using System.Collections.Generic;

namespace DSA_CS.Misc
{
    public class LargestMultiple3
    {

        public static int populateAux(int[] aux, Queue<int> queue0, Queue<int> queue1, Queue<int> queue2)
        {
            int top = 0;

            while(queue0.Count != 0)
            {
                aux[top++] = queue0.Dequeue();
            }

            while(queue1.Count != 0)
            {
                aux[top++] = queue1.Dequeue();
            }

            while(queue2.Count != 0)
            {
                aux[top++] = queue2.Dequeue();
            }

            return top;
        }

        public static bool findMaxMultipleOf3(int[] arr)
        {
            Array.Sort(arr);

            Queue<int> queue0 = new Queue<int>();
            Queue<int> queue1 = new Queue<int>();
            Queue<int> queue2 = new Queue<int>();

            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                if ((arr[i] % 3) == 0)
                    queue0.Enqueue(arr[i]);
                else if ((arr[i] % 3) == 1)
                    queue1.Enqueue(arr[i]);
                else
                    queue2.Enqueue(arr[i]);
            }

            if ((sum%3) == 1)
            {
                if (queue1.Count != 0)
                    queue1.Dequeue();
                else
                {
                    if (queue2.Count != 0)
                        queue2.Dequeue();
                    else
                        return false;

                    if (queue2.Count != 0)
                        queue2.Dequeue();
                    else
                        return false;
                }
            }
            else if ((sum % 3) == 2)
            {
                if (queue2.Count != 0)
                    queue2.Dequeue();
                else
                {
                    if (queue1.Count != 0)
                        queue1.Dequeue();
                    else
                        return false;

                    if (queue1.Count != 0)
                        queue1.Dequeue();
                    else
                        return false;
                }
            }
            int[] aux = new int[arr.Length];

            int top = populateAux(aux, queue0, queue1, queue2);

            Array.Sort(aux, 0, top);

            for (int i = top - 1; i >= 0; i--)
                Console.Write(aux[i] + " ");
            return true;
        }
        public static void RunProgram()
        {
            int[] arr = { 8, 1, 7, 6, 0 };
            if (!findMaxMultipleOf3(arr))
            Console.WriteLine("Not possible");
        }
    }
}
