using System;
using System.Collections;

namespace _221013
{
    #region 값/참조 타입
    // 참조 - 힙
    // Array, string..
    class ClassBox
    {
        public int number;   
        public ClassBox(int number)
        {
            this.number = number;
        }
    }
    // 값 - 스택
    // int, float, char..
    struct StructBox
    {
        public int number;
        public StructBox(int number)
        {
            this.number = number;
        }
    }
    #endregion

    class MyList
    {
        object[] array;         // 실제 데이터가 있는 메모리를 참조하는 변수
        int capacity;           // 배열의 총 길이
        int index;              // 인덱스

        // 프로퍼티 : 변수형태의 함수
        // 현재는 get만 정의하였기에 값을 가져갈 수만 있다. (read only)
        public int Count
        {
            get
            {
                return index;
            }
            /*
            set
            {
                // myList.Count = 100; >> 100이 value라는 키워드로 들어온다
                index = value;
            }
            */
        }

        public MyList()
        {
            index = 0;
            capacity = 4;
            array = new object[capacity];
        }

        // 인덱서 : 객체에 배열의 index 기능을 추가하는 방법
        public object this[int index]
        {
            get
            {
                return array[index]; 
            }
        }

        // 컬렉션에 값을 추가하는 함수
        // object자료형 값을 1개 받고 int자료형 값을 반환하는 함수
        public int Add(object value)
        {
            array[index] = value;   // 인덱스 번째 배열 방에 데이터 대입
            index++;                // 인덱스 1증가

            // 배열의 크기를 넘을 경우
            if(index >= capacity)
            {
                capacity *= 4;                                  // 용량 4배확장
                object[] newArray = new object[capacity];       // 4배 용량 배열 생성
                for(int i=0; i<array.Length; i++)               // 기존 배열 값 복사
                {
                    newArray[i] = array[i];                     // 멤버변수 array > newArray 참조로 변경
                }
                array = newArray;
            }

            return index - 1;       // 몇 번째 인덱스에 값이 들어갔는가
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            if (false)
            {
                #region 값/참조 타입
                // cBox1이 참조주소를 cBox2에 서로 대입하여 같다
                ClassBox cBox1 = new ClassBox(10);
                ClassBox cBox2 = cBox1;
                cBox1.number = 5000;

                Console.WriteLine($"cBox1 : {cBox1.number}, cBox2 : {cBox2.number}");

                // sBox1값을 sBox2에 복사하여 서로 값이 다르다
                StructBox sBox1 = new StructBox(10);
                StructBox sBox2 = sBox1;
                sBox1.number = 5000;

                Console.WriteLine($"sBox1 : {sBox1.number}, sBox2 : {sBox2.number}");
                #endregion

                #region 형 변환
                // 형 변환과 연산
                float height = 140.5f;
                int num = (int)height; // float -> int 형 변환
                Console.WriteLine($"num : {num}");

                // 0으로 나눌 수는 없다.
                // ReadLine에 0으로 연산할 경우 에러 발생 ( 컴파일 단계 확인불가 )
                float num2 = 140 / 3; // int와 int를 나눌 시 int ( 소수점 아래 버림 ) 
                Console.WriteLine($"num2 : {num2}");

                num2 = 140 / 3f; // int와 float를 나눌 시 float ( float/int도 가능 ) 
                Console.WriteLine($"num2 : {num2}");

                // 오브젝트 : 박싱
                object obj = num;       // 무슨 자료형이든 포장해서 참조

                // 언박싱
                int num3 = (int)obj;    // 기존 int형이므로 int형으로 설정해줘야 한다
                #endregion
            }

            // 배열 : 연속적인 데이터의 집합
            int[] n = new int[3] { 10, 20, 30 };

            // Collection 
            // List : 배열처럼 여러 개의 값을 넣을 수 있지만 그 개수가 정해지지 않은 자료구조
            ArrayList list = new ArrayList();       // 리스트 객체 생성
            list.Add(10);
            list.Add(20);
            list.Add(30);

            Console.WriteLine($"list 개수 : {list.Count}");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"list[{i}] : {list[i]}");
            }

            MyList myList = new MyList();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(0);

            Console.WriteLine($"myList 개수 : {myList.Count}"); // get 기능
            // myList.Count = 100; // set 기능(주석처리)
            for(int i = 0;i< myList.Count;i++)
            {
                Console.WriteLine($"myList[{i}] : {myList[i]}");
            }

        }
    }
}