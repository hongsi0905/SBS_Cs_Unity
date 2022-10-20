using System;

namespace _221020
{
    class Shop
    {
        public const int MAX_MONEY = 10000;
        public readonly int MAX_GUEST;     // 생성자 내부에 한해 값을 변경할 수 있다
        public Shop(int maxGuest)
        {
            MAX_GUEST = maxGuest;
        }

    }

    internal class Program
    {
        #region out, ref
        static void Swap(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        // ref : 참조형태로 변수전달
        static void SwapRef(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        // out : ref와 비슷하게 참조형태로 변수 전다
        // 단, 함수종료 후 어떠한 값이라도 대입됨을 보장한다
        static void Get(out int num)
        {
            num = 100;
        }
        static void GetRef(ref int num)
        {
            // 공백
        }
        #endregion

        #region params
        // params : 이후에 오는 모든 값들을 배열로 묶어준다
        static void PrintArray(string str, params int[] array)
        {
            Console.WriteLine(str);
            for(int i=0; i<array.Length; i++)
                Console.WriteLine($"{i} : {array[i]}");
        }
        #endregion


        // 열거형 : 상수의 나열
        const int WEEK_SUN = 0;
        const int WEEK_MON = 1;
        const int WEEK_TUE = 2;
        const int WEEK_WED = 3;
        const int WEEK_THU = 4;
        const int WEEK_FRI = 5;
        const int WEEK_SAT = 6;

        [Flags]
        enum WEEKEND
        {
            // << 쉬프트 연산자
            Sun = 1 << 0, // 1을 좌측으로 0번 쉬프트
            Mon = 1 << 1, 
            Tue = 1 << 2,
            Wed = 1 << 3,
            Thu = 1 << 4,
            Fri = 1 << 5,
            Sat = 1 << 6
        }


        static void Main(string[] args)
        {
            // 예외 try - catch
            if (false)
            {
                // try ~ catch
                int[] a = { 1, 2, 3 };
                int number = 0;

                try
                {
                    Console.Write("값을 가져올 배열 index : ");
                    int input = int.Parse(Console.ReadLine());
                    number = a[input];

                    // try도중에 에러발생 시 이후의 문장 실행하지 않음
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    number = 0;
                }
                finally
                {
                    // try가 성공적으로 종료가 되어도 예외로 catch문이 실행되어도
                    // 최종적으로 불리는 영역
                    Console.WriteLine("종료");
                }
                Console.WriteLine($"number : {number}");
            }
            if (false)
            {
                #region out, ref 키워드
                int num = Divide(1, 5);
                int num2 = Divide(10, 0);
                Console.WriteLine($"num1 : {num}, num2 : {num2}");

                if (Divide2(1, 5, out num))
                {
                    Console.WriteLine($"정상적인 계산");
                }
                int number1 = 1000;
                int number2 = 1000;
                Give(number1);
                Console.WriteLine($"number1 : {number1}");
                Give(out number2);
                Console.WriteLine($"number2 : {number2}");

                int n1 = 100;
                int n2 = 200;
                Swap(n1, n2);
                Console.WriteLine($"Swap [n1 : {n1}, n2 : {n2}]");

                SwapRef(ref n1, ref n2);
                Console.WriteLine($"SwapRef [n1 : {n1}, n2 : {n2}]");
                #endregion

                #region params 키워드
                // PrintArray는 매개변수를 1개 받지만 params 키워드를 사용했기에
                // 제한 없이 int 값을 받아올 수 있다.
                // params가 없다면
                PrintArray("A", 20, 30, 40, 50, 60);    //(string, int, int,..)
                PrintArray("B", 20);                    //(string, int)
                #endregion

                #region const, readonly

                // 상수 : 변하지 않는 수 (규칙 : 상수는 모든 대문자 공백은 언더바(_)로 구분)
                const int MAX_NUM = 100;
                // MAX_NUM = 20;

                Shop shop1 = new Shop(10);
                Shop shop2 = new Shop(30);

                Console.WriteLine($"shop1 : 최대 {shop1.MAX_GUEST}명의 손님을 받을 수 있다.");
                Console.WriteLine($"shop2 : 최대 {shop2.MAX_GUEST}명의 손님을 받을 수 있다.");
                #endregion


            }

            int week = WEEK_MON;
            WEEKEND weekend = WEEKEND.Thu;
            if (weekend == WEEKEND.Thu)
                Console.WriteLine("목요일");

            // AND : 둘 다 1이여야 1
            Console.WriteLine("AND");
            Console.WriteLine($"1 & 1 : {1 & 1}");
            Console.WriteLine($"1 & 0 : {1 & 0}");
            Console.WriteLine($"0 & 1 : {0 & 1}");
            Console.WriteLine($"0 & 0 : {0 & 0}");

            // OR : 둘 중 하나라도 1이면 1
            Console.WriteLine("OR");
            Console.WriteLine($"1 | 1 : {1 | 1}");
            Console.WriteLine($"1 | 0 : {1 | 0}");
            Console.WriteLine($"0 | 1 : {0 | 1}");
            Console.WriteLine($"0 | 0 : {0 | 0}");

            Student student = new Student("학생", WEEKEND.Thu, WEEKEND.Tue, WEEKEND.Fri);
            Console.WriteLine($"{student.name}은 월요일에 학원을 가나요 : {student.IsWeek(WEEKEND.Mon)}");
        }

        class Student
        {
            public string name;
            public WEEKEND classWk; // 수업 요일
            public Student(string name, params WEEKEND[] wknds)
            {
                this.name = name;
                foreach (WEEKEND w in wknds)
                    classWk |= w;
                // 양측 값을 OR후 좌측대입
            }
            public bool IsWeek(WEEKEND weekend)
            {
                // 학생의 학원가는 날에 원하는 요일을 AND연산
                // 0이 아닌 값이 나올 경우 포함
                return (classWk & weekend) != 0;
            }
        }



        #region out
        // 결과 값 만을 반환하기에 제대로 계산이 되었는지의 여부는 알 수 없다
        static int Divide(int divisor, int divide)
        {
            // 0으로 나눌 경우
            if (divide == 0)
            {
                return 0;
            }
            return divisor / divide;
        }
        // 반환값으로 실행결과를 리턴하고 out키워드로 계산된 결과값을 전달
        static bool Divide2(int divisor, int divide, out int result)
        {
            if(divide == 0)
            {
                result = 0;
                return false;
            }
            result = divisor / divide;
            return true;
        }
        static void Give(int num)
        {
            num = 100;
        }
        // 함수종료 시 매개변수에 값이 대입됨을 보장하는 키워드
        // 실제 변수의 주소 참조
        static void Give(out int num)
        {
            num = 100;
        }
        #endregion
    }
}
