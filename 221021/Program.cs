using System;

namespace _221021
{
    internal class Program
    {
        // delegate(대리자) : 함수를 담을 수 있는 자료형(형식)

        delegate void CallEvent();              // 반환형이 없고 매개변수가 없는 함수
        delegate int MethEvent(int a, int b);    // int반환 2개의 int 매개변수 받는 함수
        delegate int CalculateEvent(int a, int b);   

        static void Main(string[] args)
        {
            Sort sort = new Sort();
            sort.Start();
            return;

            CallEvent onCall = Temp;                        // onCall 델리게이트에 Temp함수 대입
            // onCall() = Sum                               // 다른 형태의 함수는 대입불가
            onCall();                                       // 대리자통해 함수호출

            MethEvent onMeth = Sum;                         // 형식맞는 Sum대입
            Console.WriteLine($"Sum : {onMeth(5,2)}");      // 대리자통해 함수호출

            onMeth = Minus;                                 // 형식맞는 Minus대입
            Console.WriteLine($"Minus : {onMeth(5, 2)}");   // 대리자통해 함수호출

            onMeth = Multiple;                              
            Console.WriteLine($"Mtpl : {onMeth(5, 2)}");

            Calculate(20, 40, Sum);
            Calculate(20, 20, Multiple);
        }

        static void Calculate(int a, int b, CalculateEvent onEvent)
        {
            int value = onEvent(a, b);
            Console.WriteLine($"계산 결과 : {value}");
        }

        static void Temp()
        {
            Console.WriteLine("함ㅅ 1");
        }
        static int Sum(int a, int b)
        {
            return a + b;
        }
        static int Minus(int a, int b)
        {
            return a - b;
        }
        static int Multiple(int a, int b)
        {
            return a * a + b * b;
        }

    }
}
