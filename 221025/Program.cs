using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections;

namespace _221025
{
    internal class Program
    {
        class Item
        {
            // static : 프로그램 실행시 생성
            private static int count;
            public static int itemCount
            {
                get
                {
                    count++;
                    if (count >= 4)
                        count = 0;
                    return count;
                }
            }
            string name;
            int id;
            public int Sort => id;
            
            public Item(int id, string name)
            {
                this.id = id;
                this.name = name;
            }
            public override string ToString()
            {
                return $"{name} [{id}]";
            }

        }

        delegate int CalculateEvent(int a, int b);
        static void Main(string[] args)
        {
            DDay.Calculator(delegate (int days, int hours, int min, int sec)
            {
                Console.WriteLine($"디데이 계산기 : {days}");
            });
            return;

            if (false)
            {
                // 익명 메소드 : 이름이 없는 함수
                CalculateEvent onCalculate = delegate (int a, int b)
                {
                    return a + b;
                };

                int number = onCalculate(10, 20);

                Console.WriteLine($"number : {number}");

                // List<T>의 Sort 함수는 int delegate(T, T)를 받아서 정렬 기준
                // 이때 이미 선언된 함수를 대입해도 되지만 이후 사용하지 않는다면
                // 익명 메소드로 임시적인 처리가능
                List<int> list = new List<int>(new int[] { 30, 10, 40, 20, 50 });
                list.Sort(delegate (int num1, int num2)
                {
                // 내림차순
                if (num1 > num2)
                        return -1;
                    else if (num1 < num2)
                        return 1;
                    else
                        return 0;
                });

                foreach (int num in list)
                    Console.Write($"{num},");
                Console.WriteLine();

                // 아이디 리스트 3개요소 생성
                // 리스트 정렬
                // 리스트 값 출력

                List<Item> itemList = new List<Item>();
                itemList.Add(new Item(31, "가"));
                itemList.Add(new Item(29, "나"));
                itemList.Add(new Item(57, "다"));

                // Sort 입장에서는 Item 열거를 정렬할 시 곤란
                // 그러므로 누가 더 작고 큰지 알 수 있는 int Compare(T a, T b) 델리게이트 함수대입
                // Sort는 Item을 몰라도 두 아이템을 Compare 대입하여 크고 작은지 판별하여 정렬가능

                itemList.Sort(delegate (Item item1, Item item2)
                {
                    if (item1.Sort < item2.Sort)
                        return -1;
                    else if (item1.Sort > item2.Sort)
                        return 1;
                    else
                        return 0;
                });

                foreach (Item item in itemList)
                    Console.Write($"{item}, ");
            }

            // Console.WriteLine(Item.itemCount);
         

            DateTime date = DateTime.Now;           // 현재 시간 대입
            Console.WriteLine($"오늘 :{date.ToString()}, 37일 후 : {date.AddDays(37)}");

            DateTime date2 = new DateTime(1993, 10, 08);
            string[] weekKorea = new string[] { "일", "월", "화", "수", "목", "금", "토" };
            Console.WriteLine($"1993.10.08.({weekKorea[(int)date2.DayOfWeek]})");

            TimeSpan span = DateTime.Now - date2;
            Console.WriteLine(span.TotalDays);

            // D day
            // 2022.02.03
            TimeSpan dDay = DateTime.Now - new DateTime(2022, 02, 03);
            bool isCheckday = true;
            int totalDays = (int)dDay.TotalDays + (isCheckday ? 1 : 0);
            Console.WriteLine($"D day : {totalDays}일");

            

            IEnumerator input = Input();
            IEnumerator timer = Timer();

            /*
            while (true)
            {
                Console.Clear();
                timer.MoveNext();
                input.MoveNext();
            }*/
            
        }

        static IEnumerator Input()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
                // 키 입력이 일어났을 때
                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey();     // 입력한 키의 정보 대입
                }
                string key = keyInfo.Key.ToString();
                Console.WriteLine($"입력 키 : {key}");      // 키 출력

                yield return null;
            }
        }

        static IEnumerator Timer()
        {
            DateTime start = DateTime.Now;
            int count = 0;
            while(true)
            {
                TimeSpan span = DateTime.Now - start;
                if(span.TotalSeconds >= 1.0f)
                {
                    count += 1;
                    Console.WriteLine(count);
                    start = DateTime.Now;
                }

                yield return null;
            }
        }

    }
}
