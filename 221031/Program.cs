using System;
using System.Collections.Generic;
using System.Linq;


namespace _221031
{
    class MyClass
    {
        public string name;
        public int age;
        public float height;
    }
    class BirthdayInfo
    {
        // 자동 프로퍼티를 이용해 클래스의 은닉성은 보장하고 더 쉽고 간결하게 사용할 수 있다
        public string name { get; private set; }
        public DateTime birthday { get; private set; }

        public int Age => new DateTime(DateTime.Now.Subtract(birthday).Ticks).Year;
        public BirthdayInfo(string name, DateTime birthday)
        {
            this.name = name;
            this.birthday = birthday;
        }
    }
    
    
    internal class Program
    {

        static void Main(string[] args)
        {
            if (false)
            {
                // 프로퍼티를 통해 객체를 초기화하는 방법
                MyClass myClass = new MyClass() { name = "ㅎㅇ", age = 24 };

                // 생성자를 통해 객체를 초기화하는 방법
                BirthdayInfo birthday = new BirthdayInfo("ㅇㅇ", new DateTime(2022, 10, 31));
                Console.WriteLine($"이름 : {birthday.name}, 생일 : {birthday.birthday.ToShortDateString()}, 나이 : {birthday.Age}");

                // 무명 형식(Anonymous Type)
                // 기본 형식 int, float같이 형식에는 이름이 있어야한다. 하지만 이름이 없는 형식이 존재한다.

                // var형식 : 들어오는 값에 의해 프로그램이 형식을 유추한다.
                var myInstance = new { Name = "ㅎㅇ", Age = 24 };
                Console.WriteLine($"name : {myInstance.Name}, Age : {myInstance.Age}");



            }

            
            MyClass[] profiles =
            {
                new MyClass() {name = "ㄱ", age = 4, height = 9.78f},
                new MyClass() {name = "ㄴ", age = 1, height = 4.32f},
                new MyClass() {name = "ㄷ", age = 2, height = 3.21f},
                new MyClass() {name = "ㄹ", age = 3, height = 8.76f},
                new MyClass() {name = "ㅁ", age = 5, height = 4.56f},
            };

            // 키가 5이상인 사람을 뽑아 리스트 만들기
            // 단, 순서는 키를 기준으로 오름차순 정렬

            // if문과 List의 Sort함수 정렬
            if (false)
            {
                List<MyClass> list = new List<MyClass>();
                for (int i = 0; i < profiles.Length; i++)
                {
                    if (profiles[i].height >= 5)
                    {
                        list.Add(profiles[i]);
                    }
                }

                // Sort는 delegate의 Comparison 매개변수 필요 : int Comparison<T>(T x, T y)형식의 함수 대입
                // delegate int Comparison(MyClass x, MyClass y)
                list.Sort((a, b) =>
                {
                    if (a.height < b.height)
                        return -1;
                    else if (a.height > b.height)
                        return 1;
                    else
                        return 0;

                });

                foreach (MyClass profile in list)
                {
                    Console.WriteLine(profile.name);
                }
            }

            if (false)
            {
                // from절 : 시작부분. 대상을 하나씩 받아온다
                // where절 : 필터, 특정 조건에 맞는 변수만 거른다
                // select절 : 최종적으로 어떠한 데이터를 반환할 것인가

                // 링크문은 데이터가 IEnumerable을 구현해야 사용할 수 있다
                // profiles는 Array<T>형이고 IEnumerable<T>를 구현하고 있다
                // Linq 쿼리문이 마지막으로 반환하는 자료형은 IEnumerable<T>이다.
                var search = from profile in profiles           // 배열에서 값을 하나씩 가져온다
                             where profile.height > 5           // 해당 값이 조건을 충족해야한다
                             orderby profile.height             // 충족한 값을 오름차순 정렬
                             select profile;                    // 마지막 배열 그 자체를 값으로 보낸다

                foreach (var p in search)
                {
                    Console.WriteLine($"name : {p.name}, height : {p.height}");
                }
            }

            ItemDB itemDB = new ItemDB();

            Console.Write("검색어 : ");
            Item[] searchItems = itemDB.GetItem(Console.ReadLine());

            Console.WriteLine("경매장");
            Console.WriteLine("========================");
            Console.WriteLine($"{"이름", -10}{"레벨",-10}{"직업",-10}{"공격력",-8}");

            foreach (var item in searchItems)
            {
                Console.WriteLine($"{item.name,-10}{item.level,-10}{item.job,-10}{item.power,-10}");
            }

        }
    }
}
