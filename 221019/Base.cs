using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _221019
{
    internal class Base
    {
        public string name;

        public Base()
        {
            Console.WriteLine("Base의 빈 생성자");
        }
        public Base(string name)
        {
            this.name = name;
            Console.WriteLine("Base의 string 받는 생성자");
        }
    }

    class Child : Base
    {
        public int number;
        // 객체는 생성 시(인스턴스) 무조건 생성자가 불리게 되어있다.
        // 생성자를 정의하지 않았다면 컴파일러가 자동으로 빈 기본 생성자를 작성

        // Child는 Base상속
        // Child의 생성자가 불릴 때 그보다 먼저 Base의 생성자 호출
        // 만약 아무런 명시가 없으면 Base의 기본 생성자 자동 호출

        // string, int를 받는 Child의 생성자가 호출 시
        // 부모 클래스인 Base의 string을 받는 생성자를 호출
        public Child(string name, int number) : base(name)
        {
            this.number = number;
            Console.WriteLine("Child의 int 받는 생성자");
        }
    }
}
