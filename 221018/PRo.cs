using System;
using System.Collections;           // 일반 타입
using System.Collections.Generic;   // 일반화 타입

namespace _221018
{
    class Box<T> : IEnumerable<T>
    {
        T[] array;
        int index;
        // Getter 프로퍼티 : 카운트를 통해 값을 가져갈 때 자신의 값이 아닌 index변수 값 리턴
        public int Count
        {
            // 기본적으로 존재하는 get기능 구현
            // index의 값은 사실상 가지고 있는 값의 개수와 동일
            // 따라 get(가져갈 수만 있는) 변수를 만들고 index값 반환
            get
            {
                return index;
            }
            // int Count 변수는 set기능 미구현으로 대입불가
        }

        public Box()
        {
            array = new T[20];
        }
        // 인덱스
        public T this[int index]
        {
            get 
            {
                return array[index]; 
            }
        }
        // 대입함수
        public void Add(T i)
        {
            array[index] = i;
            index++;
        }

        // 함수명 GetEnumerator
        public IEnumerator<T> GetEnumerator()
        {
            // 횟수는 array.Length만큼 돌면 원하는 결과가 나오지 않는다
            // 현재 배열은 20개의 길이를 가지지만 이것은 대입받은 값의 개수가 아니다
            // 따라 실제 대입받은 값의 개수만큼 열거(Enumerate)시킨다
            for(int i=0; i<Count; i++)
            {
                yield return array[i];
            }
        }
        // 일반버전 열거자 필요
        // IEnumerable 내부에 존재하는 GetEnumerator
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    

    internal class Pro
    {
        // Enumerate : 열거자

        // C#의 모든 컬렉션들은 아래의 두 인터페이스를 상속받아 구현
        // IEnumerator : 데이터 리턴 열거자
        // IEnumerable : 열거자 리턴 Getter
        

        public void Start()
        {
            IEnumerator ie = GetEnumerator(); // 열거자 리턴
            Console.WriteLine($"현재 값 : {ie.Current}");

            ie.MoveNext();
            Console.WriteLine($"현재 값 : {ie.Current}");

            ie.MoveNext();
            Console.WriteLine($"현재 값 : {ie.Current}");

            // Foreach 구현
            // 객체 box의 일반화 타입은 int 명시
            Box<int> box = new Box<int>();
            foreach (int num in box)
            {
                Console.WriteLine(num);
            }

            // 객체 box2의 일반화 타입 string 명시
            Box<string> box2 = new Box<string>();
            foreach(string str in box2)
            {
                Console.WriteLine(str);
            }
        }

        // IEnumerable 자동 완성형 : 열거자를 반환하는 함수는 MoveNext, Reset, Current를 자동으로 생성
        IEnumerator GetEnumerator()
        {
            // MoveNext 실행이 되면 다음 yield 지점까지 실행 (리턴 위치기록)
            Console.WriteLine("1번");
            Console.WriteLine("1번");
            yield return 1; 

            Console.WriteLine("2번");
            yield return 2;

            Console.WriteLine("3번"); // MoveNext호출 시 리턴이 없으므로 가장 최근 리턴값 반환
            
        }
    }
}
