using System;

namespace _221026
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = 10;
            int num2 = 10;

            /*// bool 변수는 이름 앞에 is붙인다.
            bool isEquals = num1 == num2;
            Console.WriteLine($"num1 == num2 : {num1 == num2}");        // 같다
            Console.WriteLine($"num1 !=num2 : {num1 != num2}");         // 다르다
            Console.WriteLine($"num1 < num2 : {num1 < num2}");          // 미만
            Console.WriteLine($"num1 <= num2 : {num1 <= num2}");        // 이하
            Console.WriteLine($"num1 > num2 : {num1 > num2}");          // 초과
            Console.WriteLine($"num1 >= num2 : {num1 >= num2}");        // 이상*/



            // Input : 
            // ConsoleKeyInfo input = Console.ReadKey(true);
            // Console.WriteLine($"key : {input.Key}, kerChar : {input.KeyChar}, modifiers : {input.Modifiers}");

            // 회원가입
            Console.WriteLine("아이디 : ");
            Console.WriteLine("비밀번호 : ");
            Console.CursorTop = 0;
            Console.CursorLeft = 9; 
            string id = Console.ReadLine();
            string pw = string.Empty;
            bool isEndInput = false;

            Console.CursorLeft = 11;
            Console.CursorTop = 1;

            // ! (NOT) : 조건식의 결과를 반대
            while (!isEndInput)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                //if (input.Key == ConsoleKey.Enter)
                //    break;

                switch (input.Key)
                {
                    case ConsoleKey.Enter:
                        if (pw.Length >= 4 && pw.Length <= 12)
                            isEndInput = true;
                        else
                        {
                            DrawText(0, 2, "다시 입력");

                        }
                        break;
                    // 기존에 있던 별을 지운다.


                    case ConsoleKey.Backspace:
                        // 입력된 pw길이가 0보다 많을 경우에 실행
                        if (pw.Length > 0)
                        {
                            DrawChar(11, 1, ' ', pw.Length);
                            pw = pw.Substring(0, pw.Length - 1);        // 마지막 문자를 제외하고 pw 대입
                            DrawChar(11, 1, '*', pw.Length);
                        }
                        break;



                    default:
                        if (pw.Length < 12)
                        {
                            pw += input.KeyChar;
                            Console.Write('*');
                            ClearLine(2);
                        }
                        break;

                }

            }
            






        }
        // 특정 위치에 특정문자를 n개 그려주는 함수
        static void DrawChar(int left, int top, char c, int count)
        {
            Console.CursorLeft = left;
            Console.CursorTop = top;
            for(int i =0; i<count; i++)
                Console.Write(c);
        }
        static void DrawText(int left, int top, string str)
        {
            // 이전 커서위치 저장
            int beforeLeft = Console.CursorLeft;
            int beforeTop = Console.CursorTop;
            // 요청한 커서위치 이동
            Console.CursorLeft = left;
            Console.CursorTop = top;
            // 텍스트 출력
            Console.Write(str);
            // 이전 위치 복귀
            Console.CursorLeft = beforeLeft;
            Console.CursorTop = beforeTop;

        }
        static void ClearLine(int top)
        {
            string blank = string.Empty;
            for (int i = 0; i < Console.BufferWidth; i++)
                blank += ' ';
            DrawText(11, top, blank);
        }
    }
}
