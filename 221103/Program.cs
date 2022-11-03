using System;
using System.Linq;


namespace _221103
{
    class Item
    {
        public string name;
        public int level;
        public int price;
        public Item(string name, int level, int price)
        {
            this.name = name;
            this.level = level;
            this.price = price;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            if (false)
            {
                // Where : 데이터 필터 / 원하는 조건에 맞는 데이터 수집
                // Select : 최종 결과물
                Item[] items = {
                new Item("단검", 10, 4000),
                new Item("지팡이", 7, 3500),
                new Item("사냥꾼의 활", 30, 28000),
                new Item("그륜힐", 24, 22200),
                new Item("청운검", 50, 10000),
            };

                // Group by : 데이터를 특정 기준을 잡아 분류
                var listItems = from item in items
                                group item by item.price >= 10000 into g
                                select new { GroupKey = g.Key, Items = g };

                // listItems는 IGrouping<T>형식
                foreach (var group in listItems)
                {
                    Console.WriteLine(group.GroupKey ? "10000원 이상" : "10000원 미만");
                    Console.WriteLine("==============================");
                    foreach (var item in group.Items)
                    {
                        Console.WriteLine($"{item.name} : {item.price.ToString("#,##0")}원");
                    }
                    Console.WriteLine();
                }

                int price = 1000000;
                string str = price.ToString("#,##0");
                str.Replace(',', '\0');
                Console.WriteLine(str);

                // 문자열 편집
                str = "Hello World! Good bye";
                Console.WriteLine($"Hello가 포함되었나 : {str.Contains("Hello")}");
                Console.WriteLine($"Good은 몇 번째부터 시작 : {str.IndexOf("Good")}");
                Console.WriteLine($"잘라낸 문자열 : {str.Substring(13)}");
                Console.WriteLine($"원래 문자 : {str}");

                Console.WriteLine($"모두 대문자 일 때 : {str.ToUpper()}");
                Console.WriteLine($"모두 소문자 일 때 : {str.ToLower()}");
                Console.WriteLine($"hello가 존재하는가 : {str.ToLower().Contains("hello")}");

                str = "                 Good Morning everyone.   ";
                Console.WriteLine($"공백 제거 : {str.Trim()}");
                Console.WriteLine($"morning 제거 : {str.Trim().Remove(5, 8)}");       // index5부터 8글자 지운다


            }

            int[] array = { 30, 40, 10, 60, 20, 50, };

            // 배열 정렬
            array = array.Sort();

            // 출력
            Console.WriteLine(array.ToStringArray());


            // string형 자료형에 메서드 확장
            // int Toint() : 문자열을 int형으로 바꿔주며 바꿀 수 없다면 -1을 반환
            string s = "-132";
            bool isValid = false;
            int test = s.Toint(out isValid );
           
            Console.WriteLine($"{test} : {isValid}");

         

        }
    }

   
    



    // 확장 메서드
    // static 클래스는 static 함수, 변수만 가질 수 있다.
    public static class Method
    {
        public static int[] Sort(this int[] array, bool isAscending = true)
        {
            if(isAscending)
                return array.OrderBy(num => num).ToArray();
            else
                return array.OrderByDescending(num => num).ToArray();
        }
        public static string ToStringArray(this int[] array, char separator = ',')
        {
            return string.Join(separator, array);
            /*string arrayStr = string.Empty;
            foreach (int n in array)
                arrayStr += $"{n},";
            arrayStr = arrayStr.Remove(arrayStr.Length - 1, 1);
            return arrayStr;*/
        }

        // out 키워드가 붙은 매개변수 : 함수 내에서는 값의 대입을 강제하고 실제 매개변수에게 값을 대입시킨다.
        public static int Toint(this string str, out bool isValid)
        {
            try
            {
                int s = int.Parse(str);
                isValid = true;
                return s; 
            }
            catch (Exception ex)
            {
                isValid = false;
            }
                return -1;
        }
    }

}

