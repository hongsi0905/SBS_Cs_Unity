using System;
using System.Collections;
using System.Collections.Generic;

namespace _221014
{
    // T : 일반화 자료형
    // 클래스 정의 단계에서는 종류가 정해지지 않았다.

    
    //아래의 클래스는 어떠한 데이터를 여러개 담고 있기 위해 만들어졌다
    //  하지만 특정 자료형 밖에 담지 못하기 때문에 일반화를 시켜
    //  어떠한 자료형이라도 대응되는 '가방'을 만든 것
     
    class Container<T>
    {
        T[] array;
        int index;

        public Container()
        {
            array = new T[10];
            index = 0;
        }
        public T this[int i]
        {
            get
            {
                return array[i];
            }
        }

        public void Add(T value)
        {
            array[index++] = value;
        }
    }

    class Item
    {
        string itemName;
        int itemPrice;
        public Item(string itemName, int itemPrice)
        {
            this.itemName = itemName;
            this.itemPrice = itemPrice;
        }

        public override string ToString()
        {
            return $"{itemName} : {itemPrice}G";
        }

    }

    class Npc
    {
        string name;
        List<Item> itemList;                // Item List 자료형 멤버 변수
        public Npc(string name)
        {
            this.name = name;
            itemList = new List<Item>();
        }

        public void AddItem(Item item)
        {
            itemList.Add(item);             // 매개변수로 받은 Item변수를 List추가
        }

        public void ShowItem()
        {
            Console.WriteLine($"{name}");
            Console.WriteLine("==============");
            for (int i = 0; i < itemList.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{itemList[i]}");
            }
            Console.WriteLine("==============");
        }
    }


    internal class Program
    {
        static void MeetNpc(Npc npc)
        {
            Console.WriteLine("만남");
            npc.ShowItem();
        }
        
        // 함수 : 기능
        // 반환형 함수명 ( 매개변수 )
        static Item BuyItem(int gold, int index)
        {
            return new Item("EMPTY", 0);
        }

        static void Main(string[] args)
        {
            BuyItem(9000, 1);

            if (false)
            {
                #region 일반 컬렉션
                // ArrayList : 배열을 닮은 컬렉션
                ArrayList list = new ArrayList();   // new 연산을 통해 객체(인스턴스, 클론) 생성
                list.Add(12);
                list.Add(34);
                list.Add(56);

                list.Insert(1, "INSERT");
                list.RemoveAt(2);

                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(list[i]);
                }
                Console.WriteLine();

                // Queue : 선입선출 형태의 자료구조. 데이터가 들어간 순서대로 나온다.
                Queue queue = new Queue();
                queue.Enqueue(100);                     // 값 대입 (줄 선다)
                queue.Enqueue(200);

                Console.WriteLine(queue.Dequeue());     // 값 반환 (줄 나온다)
                Console.WriteLine(queue.Dequeue());

                // Stack : 선입후출 형태의 자료구조. 나중에 들어온 데이터가 먼저 나간다.
                Stack stack = new Stack();
                stack.Push(1000);
                stack.Push(2000);

                Console.WriteLine(stack.Pop());
                Console.WriteLine(stack.Pop());

                // Hashtable : Key, Value 한쌍으로 이루어진 자료구조
                Hashtable table = new Hashtable();
                table.Add("A", 90000);
                table.Add("B", 5000);
                table.Add("C", 100);

                // ContainsKey(object) : bool
                // 키 값을 확인 후 bool값을 반환하는 함수

                if (table.Contains("D"))
                    Console.WriteLine($"값 : {table["D"]}");
                else
                    Console.WriteLine("해당 키는 존재하지 않음");

                // Hashtable 키 값을 고유한 HashCode로 변환 후 index 찾아낸다
                // 해당 index번 째 배열 방의 값이 들어갈 공간이다
                string name = "Hello";
                Console.WriteLine(name.GetHashCode());

                #endregion
            }
            if (false)
            {
                #region 일반화
                // Generic (일반화) : 어떠한 일반화 클래스의 내부 자료형은 이 때 정해진다.
                // 동일한 동작을 자른 자료형으로 통합해 처리하고 싶을 때 사용
                Container<int> intContainer = new Container<int>();
                intContainer.Add(100);

                Container<string> strContainer = new Container<string>();
                strContainer.Add("Hello");

                // Generic type collection : object가 아닌 동일한 자료형을 여러 개 담을 수 있는 자료구조
                // ArrayList -> List<T> : 동일한 자료형의 데이터를 개수 제한 없이 가질 수 있는 객체
                List<int> intlist = new List<int>();
                intlist.Add(1);
                intlist.Add(2);

                List<string> strlist = new List<string>();
                strlist.Add("AAA");
                #endregion
            }

            #region 객체화
            Npc wpNpc = new Npc("무기");
            wpNpc.AddItem(new Item("ㄱㄱ", 300));
            wpNpc.AddItem(new Item("ㄴㄴ", 20));
            wpNpc.AddItem(new Item("ㄷㄷ", 500));


            Npc hdNpc = new Npc("히든");
            hdNpc.AddItem(new Item("ㅋㅋ", 20000));
            hdNpc.AddItem(new Item("ㅇㅇ", 10));
            hdNpc.AddItem(new Item("ㅎㅎ", 200));

            MeetNpc(wpNpc);

            /*
            List<Item> items = new List<Item>();
            items.Add(new Item("ㅏㅏ", 100));
            items.Add(new Item("ㅣㅣ", 200));
            items.Add(new Item("ㅓㅓ", 300));
            */

            #endregion

        }
    }
}

