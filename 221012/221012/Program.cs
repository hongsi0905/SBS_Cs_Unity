using System;

namespace Hongsi221012
{
    // class : 참조형식
    // private 기본
    class Item
    {
        string name;
        int level;

        // 생성자 : 객체가 생성될 때 불리는 초기화 함수
        // string, int를 매개변수로 받는 생성자
        public Item(string name, int level)
        {
            this.name = name; // 나의 name변수에 매개변수name 값을 대입
            this.level = level;
        }

        public Item Copy()
        {
            Item item = new Item(name, level);
            return item;
        }
        public void Print()
        {
            // 문자열의 보간 형식
            //string str = "name : " + name", level : " + level;
            string str = $"name : {name}. level : {level}";
            Console.WriteLine($"Name : {name}. Level : {level}");
        }
        public void SetLevel(int level)
        {
            this.level = level;
        }
    }

    // struct : 값 형식
    // public 기본
    struct Status
    {
        public int hp;
        public int power;
        public Status(int hp, int power)
        {
            this.hp = hp;
            this.power = power;
        }
    }

    internal class Program
    {
        #region 데이터형식변수
        // 데이터 형식 (기본데이터, 복합데이터, 상수, 열거형)
        // 1 기본데이터형식 : 값이 1개인 것(int, float, char..)
        // 2 복합데이터형식 : 값이 1개 이상인 것(배열, 구조체, 클래스)
        // 3 상수 : 변하지 않는 변수
        // 4 열거형 : 상수의 나열

        // 열거형(Enum)
        /*
            상수를 사용하면 이름으로만 구분되기에 의미가 퇴색
            const int RESULT_YES = 1;
            const int RESULT_NO = 2;
            const int RESULT_CANCEL = 3;
        */
        // 열거형으로 묶어 같은 의미사용 
        enum DialogResult
        {
            Yes,
            No,
            Cancel,
        }



        // 메모리 영역
        // 스택 메모리 : 기본 데이터
        // 힙 메모리 : 복합 데이터
        #endregion
        static void Main(string[] args)
        {
            #region 데이터 형식
            // 스택 메모리의 특징은 코드 블록이 끝나면 내부에서 생성된 변수는 자동 해제된다.
            {
                // 값 형식의 변수 : 자기 자신이 값을 가지고 있는 변수
                int a = 10;
                int b = 20;

                // 기존값을 버리고 대입한 값을 복사
                a = 50;

                // int c = null; 
                // 값 형식에 한해서 nullable(null + able)형식으로 만들 수 있다.
                // null 아무런 값도 가지고 있지 않다.
                int? c = null;
            }
            // Console.WriteLine(a); > 코드블록이 끝나고 따라서 이곳에서 에러가 난다.

            // 힙 메모리
            {
                // 참조 형식의 변수(힙영역) : 포인터와 동일, 힙 영역에 실제 데이터가 있고 나는 그 주소를 참조하고 있다.
                object a = 10;
                object b = 20;
                object c = null;
            }

            //상수
            const int MAX_VALUE = 2147483647;
            const int MIN_VALUE = -2147483648;
            // MAX_VALUE = 10; > 상수는 값을 변경할 수 없다.

            // 열거형은 상수의 나열이다.
            DialogResult result = DialogResult.Yes;
            result = DialogResult.No;

            switch (result)
            {
                case DialogResult.Yes:
                    Console.WriteLine("예");
                    break;
                case DialogResult.No:
                    Console.WriteLine("아니오");
                    break;
                case DialogResult.Cancel:
                    Console.WriteLine("취소");
                    break;
            }
            #endregion


            // 배열 : 연속적인 데이터 나열
            int[] array;            // 스택 메모리에 할당 > 포인터와 동일
            array = new int[3];     // new연산자로 힙에 할당된 메모리의 첫 번째 주소 참조
            array[0] = 10;
            array[1] = 20;
            array[2] = 30;

            if (array != null)
            {
                for (int i = 0; i < array.Length; i++)
                    Console.WriteLine(array[i]);

                // foreach 반복문
                foreach (int num in array)
                {
                    Console.WriteLine(num);
                }

            }

            Console.WriteLine("array : {0}", array.Length);


            Item newItem;                   // newItem : Item자료형, Stack할당, null값
            // newItem = new Item();        // string, int를 받아야지만 객체 생성가능
            newItem = new Item("홍시", 1);  // new연산자로 할당한 힙 메모리주소를 newItem 참조
            newItem.Print();

            // Item newItem2 = newItem;     // X : 참조 형식변수의 대입은 해당 변수가 참조하는 주소값을 넘긴다.
            Item newItem2 = newItem.Copy(); // O : 복사 함수를 통해 Clone을 만들어 대입한다.
            newItem2.SetLevel(30);

            newItem.Print();
            newItem2.Print();

            Status myStatus = new Status(100, 10);   // 나의 스탯 생성
            Status enemyStatus = myStatus;          // 나의 스탯 기반으로 적 스탯 생성

            enemyStatus.hp = 0;

            Console.WriteLine($"나의 체력 : {myStatus.hp}, 상대 체력 : {enemyStatus.hp}");

            // C# 이름규칙
            // 1 변수명은 첫글자가 소문자
            // 2 클래스, 함수..등은 대문자
            // 3 띄워쓰기 부분은 공백이 아니라 대문자로 구분 ( item level > itemLevel )
            // 4 상수는 전부 대문자, 띄워쓰기는 언더바(_) 사용
        }
    }
}
