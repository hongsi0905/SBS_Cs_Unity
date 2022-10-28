using System;
using System.Threading;

namespace _221028
{
    class Player
    {
        
        // static : 프로그램 실행 시 할당
        // 객체가 할당된다고 개별적으로 생성되지않음
        static object lockObj = new object();

        // 멤버 변수 : 객체가 할당(인스턴스)될 때 개별적 할당
        // static과 다르게 객체 별로 다른 값 
        Thread thread;
        int index = 0;
        bool isCounting;
        public Player(int index)
        {
            this.index = index;
        }

        public void StartCount()
        {
            thread = new Thread(Counting);
            thread.Start(); 
        }
        public void StopCount()
        {
            isCounting = false;
        }

        private void Counting()
        {
            int count = 0;
            isCounting = true;
            while(isCounting)
            {
                // lock : lockObj 사용으로 잠금을 걸면 멀티 스레드 환경에서 다른 lockObj를 사용하는 lock문을 대기
                lock (lockObj)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = index;
                    Console.Write($"Player{index} : {count++}");

                    Console.CursorLeft = 0;
                    Console.CursorTop = 3;

                }
                Thread.Sleep(1000);
            }
        }

    }
    internal class Program
    {
        private delegate int NumberEvnet(int a, int b);
        private delegate string ConcatEvent(params string[] strs);
        private delegate void TestEvent(int a, float b, string c);

        static void Main(string[] args)
        {
            // Event
            if (false)
            {
                // Event : 어떠한 일 발생
                // Timer(3);
                Timer timer = new Timer();
                //timer.StartTimer(3);

                Player player1 = new Player(0);
                Player player2 = new Player(1);

                timer.onEndTimer += player1.StopCount;      // 플레이어1의 StopCount함수를 타이머 이벤트 등록
                timer.onEndTimer += player2.StopCount;      // 플레이어2의 StopCount함수를 타이머 이벤트 등록

                // event delegate
                // 외부에서는 오로지 추가, 제거만 가능
                // 외부에서 호출하거나 어떠한 값을 대입하는 기능 제한
                // timer.onEndTimer();              // 델리게이트 호출
                // timer.onEndTimer = null;         // 델리게이트 제거

                player1.StartCount();
                player2.StartCount();

                timer.StartTimer(10);
            }
            // 람다식
            if (false)
            {
                NumberEvnet onSum = Sum;
                Console.WriteLine(onSum(10, 20));

                // 익명 메소드 : 이름 없는 함수
                onSum = delegate (int a, int b)
                {
                    return a + b;
                };

                // 람다식 : 익명 메소드를 만들기 위한 표현식
                onSum = (a, b) => a + b;

                // 문 형식의 람다식
                ConcatEvent onConcat = null;
                onConcat = (strs) =>
                {
                    string result = string.Empty;
                    for (int i = 0; i < strs.Length; i++)
                        result += strs[i];
                    return result;
                };

                Console.WriteLine(onConcat("ABCD", "EFG", "HIJ", "K"));

                TestEvent onTest = null;
                onTest = (a, b, c) =>
                {
                    Console.WriteLine($"1 : {a}, 2 : {b}, 3 : {c}");
                };

                onTest(10, 30.5f, "Test");
            }

            // Func, Action 이용한 델리게이트
            // Func<Result T> : 반환형 있는 델리게이트
            // Action : 반환형 없는 델리게이트 

            // 1. 반환형이 없고 int를 하나 받는 델리게이트 변수
            // delegate void SomeEvent(int num);
            Action<int> onPrint = (number) => Console.WriteLine($"number : {number}");
            onPrint(10);

            // 2. int반환 int 2개 받는 델리게이트 변수
            // delegate string SomeEvent(int a, int b); 
            // 마지막 자료형이 반환형
            Func<int, int, string> onSum2 = (a, b) => (a + b).ToString();
            Console.WriteLine(onSum2(100, 200));

            // 3. 반환형이 없고 string 2개 받는 델리게이트
            Action<string, string> onPrintStr = (hi, bye) => Console.WriteLine($"{hi} : {bye}");
            onPrintStr("안녕", "잘가");

            // 4. int반환 float 1개 받는 델리게이트
            Func<float, int> IntFunc = a => (int)a;
            Console.WriteLine(IntFunc(10.5f));

            // 5. string반환 string배열 받는 델리게이트
            Func<string, string> arr = (a) => a.ToString();
            Console.WriteLine(arr("배열"));

            // 6. 반환형이 없고 매개변수도 없는 델리게이트
            Action onAction = () => Console.WriteLine("없음");
            onAction();

            // 7. int 반환 매개변수 없는 델리게이트
            Func<int> onIntFunc = () => 10;
            Console.WriteLine(onIntFunc());

            // 델리게이트가 null인 상태에서 호출을 하면 NullReference 예외 발생
            Action onCallback = null;
            // onCallback(); XX

            // 1. if 처리
            if (onCallback != null)
                onCallback();

            // 2. Null 체크 처리
            onCallback?.Invoke();   // 델리게이트가 Null이 아니면 Invoke(호출)하라. (null이면 무시)

            Person p = null;
            p?.talk();              // p가 null이 아니라면 Talk()를 호출하라. (null이면 무시)

            // ?? : p가 null이 아니라면 age를 null이라면 0을 사용하겠다.
            Console.WriteLine($"나이 : {p?.age ?? 0}");

            int money = 0;          // 0이라는 값이 있는 것 (사람의 기준인 돈이 없다가 아님)
            int? gold = null;       // 값형식 자료형 뒤에 ?붙이면 null형식을 지원한다 (nullable 타입의 값 형식)
            Console.WriteLine($"골드 : {(gold == null ? "ㄴ" : gold)}");


            // 예외는 요청을 받은 '객체'가 스스로 판단해 throw해주는 것
            // null이라면 그 throw해줄 대상이 없기 때문에 try문에서는 처리가 불가능
            /*try
            {
                onCallback();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/





        }
        class Person
        {
            public int age;
            public Person(int age)
            {
                this.age = age;
            }
            public void talk()
            {
                Console.WriteLine($"나는 {age}살");
            }
        }


        static int Sum(int a, int b)
        {
            return a + b;
        }

    }   
}

