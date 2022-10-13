using System;

// 모든것은 namespace로 구분된다.
namespace hongsi
{
    // 전역 변수가 없다
    // 헤더 파일이 없다.
    // '포인터'가 없다.
    // 모든 내부 접근은 피리어드(.)로 이루어진다. ( ->, :: 없다. )
    internal class Program
    {
        // 클래스 : 기본적으로 private 참조 타입이다.
        class Person
        {
            // Person클래스의 멤버 변수
            string name;
            int age;
            string contact;

            public Person()
            {
                name = string.Empty;
                age = 0;
                contact = string.Empty;
            }
            public void GetInput()
            {
                Console.WriteLine("사용자 정보 입력");
                Console.Write("이름 : ");
                name = Console.ReadLine();
                Console.Write("나이 : ");
                age = int.Parse(Console.ReadLine());
                Console.Write("연락처 : ");
                contact = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("사용자 정보 입력 완료");
                Console.ReadKey();
            }
            public void Print()
            {
                Console.WriteLine("사용자 정보");
                Console.WriteLine("이름 : {0}", name);
                Console.WriteLine("나이 : {0}", age);
                Console.WriteLine("연락처 : {0}", contact);
            }

            // 오버라이딩 : 부모로부터 상속받은 가상함수의 내용을 재정의하는 것
            public override string ToString()
            {
                //return base.ToString();
                return string.Format("이름{0} 나이{1} 연락처{2}", name, age, contact);
            }
        }


        static void Main(string[] args)
        {
            if (false)
            {
                // C#에서 변수는 객체다.
                int number = 10;        // 정수형
                float height = 10.5f;   // 실수형
                double pi = 3.1415;     // 실수형(부동형)
                char c = 'A';           // 문자형
                string str = "ABCD";    // 문자열

                // 출력
                Console.WriteLine("number : {0}, height : {1}", number, height); // {0} 0번째 값(number) / {1} 1번째 값(height)

                // object 자료형 : C#의 모든 자료형이 상속하는 기본 클래스
                object obj = number;
                // string Tostring() : object 내부에 있는 가상함수이며 어떠한 변수라도 사용할 수 있다.
                string name = number.ToString();

                // 입력
                Console.Write("값을 입력하세요 : "); // Line붙으면 줄바꿈
                string input = Console.ReadLine();
                Console.WriteLine("입력 값 : {0}", input);

                // Parse : 문자열을 숫자형으로 바꾸는 함수
                string inp = Console.ReadLine();
                int num2 = int.Parse(inp);
            }

            // 실습 : 이름, 나이, 주소, 연락처
            if (false)
            {
                Console.Write("이름 : ");
                string myname = Console.ReadLine();
                Console.Write("나이 : ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("주소 : ");
                string address = Console.ReadLine();
                Console.Write("연락처 : ");
                string contact = Console.ReadLine();

                // 한줄 지우기 : 콘솔창에 관련된것은 콘솔안에 다 있다.
                Console.Clear();
                Console.WriteLine("이름 : {0} /n 나이 : {1}/n  주소 : {2} /n 연락처 : {3}",
                    myname, age, address, contact);
            }

            Person person = new Person();
            person.GetInput();
            person.Print();

            string personStr = person.ToString();
            Console.WriteLine(personStr);
        }

    }
}
