using System;
using System.Collections;
using System.Collections.Generic;


namespace _221017
{
    #region 일반화
    // 일반화 : 선언 단계에서는 알 수 없으나 객체 생성 시 자료형이 정해지는 기법
    class Box<T>
    {
        public T value;
    }


    #endregion
    

    // Interface : 프로그램끼리의 약속
    // 인터페이스를 상속하면 모든 내용을 구현해야만 한다
    interface IDamage
    {
        void Damage(int power);
    }

    class Glass : IDamage
    {
        public void Destroy()
        {
            Console.WriteLine("유리 파괴");
        }

        public void Damage(int power)
        {
            Console.WriteLine("유리 파괴");
        }
    }

    class Enemy : IDamage
    {
        public void TakeDamage(int power)
        {
            Console.WriteLine($"{power}의 데미지를 입힘");
        }

        public void Damage(int power)
        {
            Console.WriteLine($"{power}의 데미지를 입힘");
        }
    }

    class NPC
    {
        // 피격판정없음
    }

    // 상속 : 클래스의 내용을 재사용하거나 수정할 수 있다.
    class Person
    {
        public string name;
        public int age;
        public virtual void Talk()
        {
        }
    }

    class Baby : Person
    {
        // virtual : 해당 함수는 자신을 상속한 클래스가 재정의 할 수 있다.
       public override void Talk()
        {
            // base.Talk(); > 원래 내용 호출
            Console.WriteLine("옹알이");
        }
    }

    class Child : Baby
    {
        public void Run()
        {
            Console.WriteLine("뛰다");
        }
        public override void Talk()
        {
            // base.Talk(); > 원래 내용 호출
            Console.WriteLine("소통");
        }
    }

    class Container : IEnumerable
    {
        // Ctrl + . : 에러수정
        string[] values;
        // 프로퍼티
        public int Length
        {
            get
            {
                return values.Length;
            }
        }

        // 인덱서
        public string this[int i]
        {
            get
            {
                return values[i];
            }
        }
        public Container()
        {
            values = new string[3];
            values[0] = "AA";
            values[1] = "BB";
            values[2] = "CC";
        }

        public IEnumerator GetEnumerator()
        {
            for(int i=0;i<values.Length;i++)
                yield return values[i];
        }

      
    }
    //=========================================================================

    internal class Program
    {
        static void Main(string[] args)
        {
            // Ctrl + Shift + ? : 주석처리
            if (false)
            {
                /*Box<int> box = new Box<int>(); // 객체 box는 int 값을 하나 가진다.
                box.value = 10;

                Box<string> box2 = new Box<string>(); // 객체 box2는 string 값을 하나 가진다.
                box2.value = "ABC";*/

                Glass glass = new Glass();
                Enemy enemy = new Enemy();

                glass.Destroy();
                enemy.TakeDamage(5);

                // is (bool) : 해당 객체가 인터페이스 혹은 클래스를 상속하는가? 
                if (glass is IDamage)
                {
                    // as : 객체 간의 형변환
                    IDamage damage = glass as IDamage;
                    damage.Damage(5);

                    // 어떠한 객체가 IDamage를 상속하고 있다면
                    // 적어도 IDamage의 내용은 구현하고 있기 때문에 호출할 수 있다.
                }
            }
            if (false)
            {
                Baby baby = new Baby();     // 애기객체추가
                baby.Talk();                // 말함

                Child child = new Child();  // 아이객체추가
                child.Run();
                child.Talk();

                // 상속관계에서의 업/다운
                Person p = null;
                p = new Baby();
                p.Talk();

                p = new Child();
                p.Talk();
            }
            if (false)
            {
                // 가정) 광범위 공격으로 10개의 옵젝이 잡혀있다
                //       이중 Enemy, Glass는 판정
                //       NPC는 비판정
                List<IDamage> damagelist = new List<IDamage>();

                Enemy[] enemys = new Enemy[5];          // Enemy 객체를 담을 수 있는 공간 5개 생성
                for (int i = 0; i < 5; i++)
                    enemys[i] = new Enemy();            // 실제 Enemy 객체 생성


                Glass[] glasses = new Glass[3];
                for (int i = 0; i < 3; i++)
                    glasses[i] = new Glass();

                NPC[] npcs = new NPC[2];
                for (int i = 0; i < 2; i++)
                    npcs[i] = new NPC();


                AddTarget(enemys, damagelist);          // AddTarget 함수를 이용해 대상판정 후 list 추가
                AddTarget(glasses, damagelist);
                AddTarget(npcs, damagelist);

                foreach (IDamage target in damagelist)
                    target.Damage(100);
            }

            Container container = new Container();
            for(int i = 0; i < container.Length; i++)
            {
                Console.WriteLine($"value[{i}] : {container[i]}");
            }

            // foreach를 사용하기 위해서는 IEnumerable이 필요하다.
            foreach(string s in container)
            {

            }

        }



        // 타겟을 추가
        // 대상이 어떤 자료형이건 상관없이 object배열 받음
        static void AddTarget(object[] targets, List<IDamage> list)
        {
            foreach (object target in targets)          // 모든object 배열 순회
            {
                if (target is IDamage)                  // target이 IDamage 상속 시
                    list.Add(target as IDamage);        // list 추가
            }
        }

    }
}

