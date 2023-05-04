using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var numb = Console.ReadLine();
            //var result = FizzBuzz(Convert.ToInt32(numb));

            //var letter = Console.ReadLine();
            //var key = Console.ReadLine();
            //var result = CanConstruct(key, letter);

            //var j = RunningSum(new int[4] { 1, 2, 3, 4 });

            //int[][] a = new int[3][];
            //a[0] = new int[] { 2, 8, 7 };
            //a[1] = new int[] { 7, 1, 3 };
            //a[2] = new int[] { 1, 9, 5 };
            //var k = MaximumWealth(a);

            //var j = NumberOfSteps(8);

            //ListNode listNode6 = new ListNode(6);
            //ListNode listNode5 = new ListNode(5, listNode6);
            //ListNode listNode4 = new ListNode(4, listNode5);
            //ListNode listNode3 = new ListNode(3, listNode4);
            //ListNode listNode2 = new ListNode(2, listNode3);
            //ListNode listNodehead = new ListNode(1, listNode2);
            //var j = MiddleNode(listNodehead);

            var arr = new int[] { 0, 4, 1, 0, 0, 8, 0, 0, 3 };
            DuplicateZeros(arr);

            //Console.WriteLine(result.ToString());
            Console.ReadKey();
        }

        public static int NumberOfSteps(int num)
        {
            int steps = 0;
            int remianed = num;

            while (remianed > 0)
            {
                if (remianed % 2 == 0)//even
                    remianed /= 2;
                else//odd
                    remianed -= 1;

                steps++;
            }

            return steps;
        }

        public static int MaximumWealth(int[][] accounts)
        {
            int max = accounts[0].Sum();
            for (int i = 1; i < accounts.Length; i++)
            {
                int sum = accounts[i].Sum();
                if (sum > max)
                    max = sum;
            }

            return max;
        }

        public static int[] RunningSum(int[] nums)
        {
            int[] result = new int[nums.Length];
            result[0] = nums[0];
            int sum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                sum += nums[i];
                result[i] = sum;
            }

            return result;
        }

        public static bool CanConstruct(string ransomNote, string magazine)
        {
            int iof;

            for (int i = 0; i < ransomNote.Length; i++)
            {
                iof = magazine.IndexOf(ransomNote[i]);

                if (iof == -1)
                    return false;

                magazine = magazine.Remove(iof, 1);
            }

            return true;
        }

        public static IList<string> FizzBuzz(int n)
        {
            string fizz = "Fizz";
            string buzz = "Buzz";
            List<string> result = new List<string>(n);
            bool upperThan2 = false;
            bool isFizz = false;
            bool isBuzz = false;
            string str = "";

            for (int i = 1; i <= n; i++)
            {
                upperThan2 = i > 2;

                if (upperThan2)
                {
                    isFizz = i % 3 == 0;
                    isBuzz = i % 5 == 0;

                    str = "";
                    if (isFizz)
                        str = fizz;
                    if (isBuzz)
                        str += buzz;
                    else if (str.Length == 0)
                        str = i.ToString();

                    result.Add(str);
                }
                else
                    result.Add(i.ToString());
            }

            return result;
        }

        public static ListNode MiddleNode(ListNode head)
        {
            if (head.next is null)
                return head;
            if (head.next.next is null)
                return head.next;

            int count = 1;
            ListNode currentNode = head;
            HashSet<ListNode> dic = new HashSet<ListNode>();

            while (currentNode.next != null)
            {
                dic.Add(currentNode);
                currentNode = currentNode.next;
                count++;
            }

            return dic.ElementAt(count / 2);
        }

        public static void DuplicateZeros(int[] arr)
        {
            var len = arr.Length;
            if (len == 0 || len == 1)
                return;

            int currentIndex = 0;
            int[] result = new int[len];

            for (int i = 0; i < len; i++)
            {
                if (arr[i] == 0)
                {
                    if (i == len - 1 || currentIndex == len - 1)
                        break;

                    result[currentIndex] = result[currentIndex + 1] = 0;

                    for (int j = currentIndex + 1; j < len - 1; j++)
                        result[j + 1] = arr[j];

                    currentIndex += 2;
                }
                else
                {
                    result[currentIndex] = arr[i];
                    currentIndex++;
                }

                if (currentIndex >= len)
                    break;
            }

            for (int k = 0; k < len; k++)
                arr[k] = result[k];
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
