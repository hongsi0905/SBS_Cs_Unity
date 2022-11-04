using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace _221104_1
{
    class Math
    {
        public static double PI = 3.141519;
        public double radius = 3.5;

        public int Sum(int a, int b)
        {
            return a + b;
        }
        public static int Multiple(int a, int b)
        {
            return a * b;
        }
    }

    class Duck
    {
        public void Walk()
        {
            Console.WriteLine("Duck walk");
        }
        public void Swim()
        {
            Console.WriteLine("Duck Swim");
        }
        public void Quack()
        {
            Console.WriteLine("Duck Quack");
        }
    }
    class Mallad : Duck // 청둥오리
    {

    }
    class Robot
    {
        public void Walk()
        {
            Console.WriteLine("Robot walk");
        }
        public void Swim()
        {
            Console.WriteLine("Robot Swim");
        }
        public void Quack()
        {
            Console.WriteLine("Robot Quack");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // static
            if (false)
            {
                // static 
                Math math = new Math(); // Math라는 객체가 생성되면 radius 할당
                Console.WriteLine($"반지름 : {math.radius}");
                Console.WriteLine($"합 : {math.Sum(10, 20)}");
                Console.WriteLine($"원주율 : {Math.PI}");

                Math math2 = new Math();
                Console.WriteLine($"반지름 : {math2.radius}");
                Console.WriteLine($"원주율 : {Math.PI}");
            }
            // dynamic
            if (false)
            {
                // dynamic : int, float와 같은 데이터 형식
                // 일반적으로 형식 검사는 컴파일시에 이루어지나 dynamic형식은 실행시에 이루어진다

                // 오리, 청둥오리, 로봇 내부는 같으나 컴파일러는 Duck, Mallad는 오리이고 Robot은 오리가 아니다.
                // dynamic배열 : 컴파일러가 형식검사를 런타임으로 미룬다.
                dynamic[] duckArray = { new Duck(), new Mallad(), new Robot() };
                foreach (dynamic duck in duckArray)
                {
                    Console.WriteLine(duck.GetType());
                    duck.Walk();
                    duck.Swim();
                    duck.Quack();
                    Console.WriteLine();
                }

                dynamic a = 10;
                Console.WriteLine($"{a}({a.GetType()})");

                a = 3.1415;
                Console.WriteLine($"{a}({a.GetType()})");

                a = "ABCDEFG";
                Console.WriteLine($"{a}({a.GetType()})");

                dynamic playerInfo = GetPlayerInfo();
                Console.WriteLine($"이름 : {playerInfo.name}, 레벨 : {playerInfo.level}, 골드 : {playerInfo.gold}");

                dynamic friends = GetFriendList();
                Console.WriteLine("친구");
                foreach (dynamic friend in friends.friendList)
                    Console.WriteLine(friend);

                Console.WriteLine();
                Console.WriteLine("차단");
                foreach (dynamic black in friends.blackList)
                    Console.WriteLine(black);
            }

            // await : 비동기식에서 사용하는 키워드
            double deltaTime = 1000 / 12;
            double timer = 0;
            int position = 0;
            int delayTime = 500;
            bool isRun = true;
            string message = string.Empty;
            int current = 0;
            while(isRun)
            {
                timer += (deltaTime);
                if (timer >= delayTime)
                {
                    timer -= delayTime;
                    position += 1;
                    Console.Clear();
                    Console.CursorLeft = position % 3;
                    Console.WriteLine('♠');
                    Console.WriteLine(message);
                }
                // 오버헤드 : 다른 알고리즘으로 인해 딜레이가 걸리는 현상
                if(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.D)
                {
                    message = "다운로드중 ...";
                    Download((isSuccess) =>
                    {
                        Console.Clear();
                        Console.WriteLine("다운로드 완료");
                        isRun = false;
                    }, (int currentm, int max) =>
                    {
                        message = $"다운로드중.. ({current/(float)max*100}%)";

                    });
                }
                Thread.Sleep((int)deltaTime);

            }
           
        }

        static async void Download(Action<bool> onEnd, Action<int, int> onProcess)
        {
            var task = Task.Run(() => DownloadHandle());    // 비동기식으로 worker Thread에서 도는 task 생성
            bool isSuccess = await task;                    // task가 끝나길 기다렸다가 끝나면 반환형 bool 대입
            onEnd?.Invoke(true);                       // 매개변수로 받은 델리게이트 호출
        }
        static bool DownloadHandle(Action<int>, int onProcess)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(40);
               
            }
            return true;
        }

        static dynamic GetPlayerInfo()
        {
            // 실제 DB에서 검색하는 부분 제외
            dynamic info = new { name = "플레이어 1", level = 250, gold = 200 };
            return info;
        }
        static dynamic GetFriendList()
        {
            // DB의 데이터를 검색
            List<string> friendList = new List<string>(new string[] { "가", "나", "다", "라" });
            List<string> blackList = new List<string>(new string[] { "마", "바", "사", "아" });
            dynamic info = new { friendList = friendList, blackList = blackList };
            return info;
        }

    }
}
