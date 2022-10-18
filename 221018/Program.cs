using System;

namespace _221018
{
    internal class Program
    {
        // interface : 추상클래스와 유사하고 규격을 만들 때 사용
        interface IEat
        {
            // 함수 규격화
            void Eat();
        }

        class Person : IEat
        {
            public void Eat()
            {
                Console.WriteLine("냠");
            }
        }
        class Lion : IEat
        {
            public void Eat()
            {
                Console.WriteLine("얌");
            }
        }
        class Camel : IEat
        {
            public void Eat()
            {
                Console.WriteLine("먹");
            }
        }
        class AA : IEat
        {
            public void Eat()
            {
                Console.WriteLine("AA");
            }
        }




        static void Main(string[] args)        
        {
            Pro pro = new Pro();
            pro.Start();
            return; // 리턴으로 함수종료

            Person person = new Person();       // Person 객체 인스턴스
            Lion lion = new Lion();             // Lion 객체 인스턴스
            Camel camel = new Camel();          // Camel 객체 인스턴스
            AA aa = new AA();

            person.Eat();
            lion.Eat();
            camel.Eat();

            Console.WriteLine();
            EatFunc(person);
            EatFunc(lion);
            EatFuncObj(camel);
            EatFunc(aa);

            Console.WriteLine();
            EatFuncInter(person);
            EatFuncInter(lion);
            EatFuncInter(camel);
            EatFuncInter(aa);
        }

        // 인터페이스를 사용하여 객체간의 '결합도'를 낮춤
        static void EatFuncInter(object target)
        {
            if(target is IEat)
            {
                IEat eat = target as IEat;
                eat.Eat();
            }
        }

        // 인터페이스를 사용한 '아규먼트 패싱'을 사용하지 않은 경우
        // 오버로딩을 통해 메서드를 3배 늘렸다
        static void EatFunc(Person p)
        {
            p.Eat();
        }
        static void EatFunc(Lion l)
        {
            l.Eat();
        }
        static void EatFunc(Camel c)
        {
            c.Eat();
        }
        static void EatFunc(AA a)
        {
            a.Eat();
        }

        // object를 이용
        // 오버로딩을 통해선 클래스가 늘어남에 따라 함수의 양도 증가하기에
        // 모든 자료형을 대입할 수 있는 object 자료형으로 대상을 받아온다
        static void EatFuncObj(object target)
        {
            if(target is Person)
            {
                Person p = target as Person;
                p.Eat();
            }
            else if (target is Lion)
            {
                Lion l = target as Lion;
                l.Eat();
            }
            else if(target is Camel)
            {
                Camel c = target as Camel;
                c.Eat();
            }
        }
    }
}
