using LearnTest.LinkedList;
using LearnTest.Stack;
using System;
using System.Collections.Generic;

namespace LearnTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeTimer.Initialize();
            string s = "asdfa";
            HashSet<char> set = new HashSet<char>();
            set.Add(s[0]);
            Console.WriteLine(set);
            //ListNode ex1 = new ListNode(2);
            //ex1.next = new ListNode(4);
            //ex1.next.next= new ListNode(3);
            //ListNode ex2 = new ListNode(5);
            //ex2.next = new ListNode(6);
            //ex2.next.next = new ListNode(4);
            //ListNode result = AddTwoNumbers(ex1, ex2);
            //MySingleLinkedListTest();
            //StackWithArrayTest();
        }

        /// <summary>
        /// s="pwwkew",abcabcbb，bbbbb
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstring(string s)
        {
            
            return 0;
        }
        static void SortedAddInTest()
        {
            Random random = new Random();
            int array_count = 100000;
            List<int> intList = new List<int>();
            for (int i = 0; i <= array_count; i++)
            {
                int ran = random.Next();
                intList.Add(ran);
            }

            SortedList<int, string> sortedlist_int = new SortedList<int, string>();
            SortedDictionary<int, string> dic_int = new SortedDictionary<int, string>();
            CodeTimer.Time("sortedList_Add_int", 1, () =>
            {
                foreach (var item in intList)
                {
                    if (sortedlist_int.ContainsKey(item) == false)
                        sortedlist_int.Add(item, "test" + item.ToString());
                }
            });
            CodeTimer.Time("sortedDictionary_Add_int", 1, () =>
            {
                foreach (var item in intList)
                {
                    if (dic_int.ContainsKey(item) == false)
                        dic_int.Add(item, "test" + item.ToString());
                }
            });
        }

        /// <summary>
        /// LeetCode两数相加
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);
            ListNode cursor = result;
            int carrybit = 0;
            while (l1 != null || l2 != null || carrybit != 0)
            {
                int sum = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + carrybit;
                carrybit = sum / 10;
                ListNode sumNode = new ListNode(sum % 10);
                cursor.next = sumNode;
                cursor = sumNode;
                l1 = (l1 == null ? null : l1.next);
                l2 = l2 == null ? null : l2.next;
            }
            return result.next;
        }

        /// <summary>
        /// 约瑟夫环问题
        /// </summary>
        static void JosephusTest()
        {
            MyCircularLinkedList<int> linkedList = new MyCircularLinkedList<int>();
            string result = string.Empty;

            Console.WriteLine("Step1:请输入人数N");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Step2:请输入数字M");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Step3:报数游戏开始");
            // 添加参与人员元素
            for (int i = 1; i <= n; i++)
            {
                linkedList.Add(i);
            }
            // 打印所有参与人员
            Console.Write("所有参与人员：{0}", linkedList.GetAllNodes());
            Console.WriteLine("\r\n" + "-------------------------------------");
            result = string.Empty;

            while (linkedList.Count > 1)
            {
                // 依次报数：移动
                linkedList.Move(m);
                // 记录出队人员
                result += linkedList.CurrentItem + " ";
                // 移除人员出队
                linkedList.Remove();
                Console.WriteLine();
                Console.Write("剩余报数人员：{0}", linkedList.GetAllNodes());
                Console.Write("  开始报数人员：{0}", linkedList.CurrentItem);
            }
            Console.WriteLine("\r\n" + "Step4:报数游戏结束");
            Console.WriteLine("出队人员顺序：{0}", result + linkedList.CurrentItem);
        }
        static void MyCircularLinkedListTest()
        {
            MyCircularLinkedList<int> linkedList = new MyCircularLinkedList<int>();
            // 顺序插入5个节点
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);

            Console.WriteLine("All nodes in the circular linked list:");
            Console.WriteLine(linkedList.GetAllNodes());
            Console.WriteLine("--------------------------------------");
            // 当前节点：第一个节点
            Console.WriteLine("Current node in the circular linked list:");
            Console.WriteLine(linkedList.CurrentItem);
            Console.WriteLine("--------------------------------------");
            // 移除当前节点(第一个节点)
            linkedList.Remove();
            Console.WriteLine("After remove the current node:");
            Console.WriteLine(linkedList.GetAllNodes());
            Console.WriteLine("Current node in the circular linked list:");
            Console.WriteLine(linkedList.CurrentItem);
            // 移除当前节点(第二个节点)
            linkedList.Remove();
            Console.WriteLine("After remove the current node:");
            Console.WriteLine(linkedList.GetAllNodes());
            Console.WriteLine("Current node in the circular linked list:");
            Console.WriteLine(linkedList.CurrentItem);
            Console.WriteLine("--------------------------------------");

            Console.WriteLine();
        }
        static void MySingleLinkedListTest()
        {
            MySingleLinkedList<int> linkedList = new MySingleLinkedList<int>();
            // Test1:顺序插入4个节点
            linkedList.Add(0);
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);

            Console.WriteLine("The nodes in the linkedList:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            Console.WriteLine("----------------------------");

            // Test2.1:在索引为0(即第1个节点)的位置插入单个节点
            linkedList.Insert(0, 10);
            Console.WriteLine("After insert 10 in index of 0:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            // Test2.2:在索引为2(即第3个节点)的位置插入单个节点
            linkedList.Insert(2, 20);
            Console.WriteLine("After insert 20 in index of 2:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            // Test2.3:在索引为5（即最后一个节点）的位置插入单个节点
            linkedList.Insert(5, 30);
            Console.WriteLine("After insert 30 in index of 5:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            Console.WriteLine("----------------------------");

            // Test3.1:移除索引为5（即最后一个节点）的节点
            linkedList.RemoveAt(5);
            Console.WriteLine("After remove an node in index of 5:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            // Test3.2:移除索引为0（即第一个节点）的节点
            linkedList.RemoveAt(0);
            Console.WriteLine("After remove an node in index of 0:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            // Test3.3:移除索引为2（即第三个节点）的节点
            linkedList.RemoveAt(2);
            Console.WriteLine("After remove an node in index of 2:");
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
            Console.WriteLine("----------------------------");
        }

        /// <summary>
        /// 基于数组的栈的测试
        /// </summary>
        static void StackWithArrayTest()
        {
            MyArrayStack<int> stack = new MyArrayStack<int>(10);
            Console.WriteLine(stack.IsEmpty());

            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(rand.Next(1, 10));
            }
            Console.WriteLine("IsEmpty:{0}", stack.IsEmpty());
            Console.WriteLine("Size:{0}", stack.Size);
            Console.WriteLine("-------------------------------");

            for (int i = 0; i < 10; i++)
            {
                int node = stack.Pop();
                Console.Write(node + " ");
            }
            Console.WriteLine();
            Console.WriteLine("IsEmpty:{0}", stack.IsEmpty());
            Console.WriteLine("Size:{0}", stack.Size);
            Console.WriteLine("-------------------------------");

            for (int i = 0; i < 15; i++)
            {
                stack.Push(rand.Next(1, 15));
            }
            for (int i = 0; i < 15; i++)
            {
                int node = stack.Pop();
                Console.Write(node + " ");
            }
            Console.WriteLine();
        }
    }

}
