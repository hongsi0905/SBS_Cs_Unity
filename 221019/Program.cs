using System;

namespace _221019
{
    // 회원가입 시 이메일 형식이 잘못되었다는 예외
    class InvalidEmailException : Exception
    {
        public int errorCode;       // 작성한 에러 코드
        public string email;        // 사용자가 입력한 이메일
        public string repw;
            
        // 객체 생성 시(생성자 호출 시) 상속하고 있는 Exception의 생성자 중에서
        // string의 하나 받는 생성자를 호출하라고 명시하는 것
        public InvalidEmailException(string msg, int errorCode, string email) : base(msg)
        { 
            this.errorCode = errorCode;
            this.email = email;
        }

        public override string ToString()
        {
            return ($"[{errorCode}] {Message} (email : {email})");
        }
    }
    class InvalidPasswordException : Exception
    {
        public int errorCode;
        public string password;
        public string repw;
        public InvalidPasswordException(string msg, int errorCode, string password, string repw) : base(msg)
        {
            this.errorCode=errorCode;
            this.password=password;
            this.repw=repw;
        }
        public InvalidPasswordException(string msg, int errorCode, string password) : this(msg,errorCode,password,"")
        {
            // 매개변수를 4개 받는 생성자를 호출하였으므로 따로 구현할 내용이 없다.
        }
        public override string ToString()
        {
            return ($"[{errorCode}] {Message} (password : {password})");
        }
    }

    class SignManage
    {
        public void SignIn(string email, string password, string repw)
        {
            // 실제로는 이메일이 적합한지 여러가지 체크 중 부적합한 부분이 나왔다 가정
            // 일부러 이메일이 적합하지 않다고 에러를 일으키자
            if (email.Length < 4 || email.Length > 12)
                throw new InvalidEmailException("아이디 길이가 유효하지 않음 (4~12)", 100, email);
            else if (password.Length < 4 || password.Length > 12)
                throw new InvalidPasswordException("비밀번호 길이가 유효하지 않음 (4~12)", 20, password);
            else if (password != repw)
                throw new InvalidPasswordException("비밀번호가 일치하지 않음", 30, password);
            else
                //throw new InvalidEmailException("ID 형식이 틀림", 200, email, repw);

        }
        

    }

    

    internal class Program
    {
        static void Main(string[] args)
        {
            #region 예외 처리
            if (false)
            {
            
            // 예외처리 : 예측 불가능한 일이 일어나면 프로그램 종료
            int[] array = { 10, 20, 30, 40, 50 };

            //for(int i=0; i< 10; i++)
            //    Console.WriteLine(array[i]);

            // 잘못된 인덱스를 통한 배열요소 접근으로
            // 배열 객체가 문제에 대한 상세 정보를 Exception 객체에 담에 Main함수에 던진다

            // Array가 리턴한 예외는 Main에서 처리할 방도가 없기에
            // 그대로 시스템 관리자인 CLR에게 던진다.
            // CLR은 예외를 발견하고 화면에 출력하면서 프로그램 종료

            // try ~ catch 문 : Main함수에는 해당 예외를 받아 처리할 준비 필요
            // 예외가 일어날 것 같은 구간을 try로 감싼다
            try
            {
                int[] a = null;
                // Console.WriteLine(a.ToString());

                for (int i = 0; i < 10; i++)
                    Console.WriteLine(array[i]);

                Console.WriteLine("출력 끝");
            }
            catch (IndexOutOfRangeException e)   // 배열 범위를 벗어난 접근 예외
            {
                Console.WriteLine(e.Message);
            }
            catch (DivideByZeroException e)      // 어떠한 값을 0으로 나누려 했을 때의 예외
            {
                Console.WriteLine(e.Message);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            // catch외의 예외발생 시 처리하지 못해 CLR에게 예외를 던진다(프로그램 종료)

            // System.Exception 클래스
            // 모든 예외는 해당 클래스를 상속한다. (object와 비슷)
            // 어떠한 예외라도 받을 수 있지만 섬세한 예외처리는 불가능
            try
            {
                int[] numbers = { 10 };
                Console.WriteLine(numbers[20]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // throw 키워드 : 사용자가 임의의 예외를 발생시킬 수 있다.
            try
            {
                int number = 10;
                Console.WriteLine(number);
                throw new Exception("내가 만든 예외");
            }
            catch (Exception e)
            {
                Console.WriteLine($"catch : {e.Message}");
            }
            // try ~ catch , finally
            // 예외가 발생하던 안하던 무조건 실행되는 영역
            try
            {
                // 1:1 통신상태서 일어나는 문제
                // Network.Connect();           << 아무도 연결하지 않고 있어서 연결 성공
                // ...                          << 에러 발생 시
                // Network.Disconnect();        << Disconnect 함수 호출하지 않음
                // 이후 다시는 Connect할 수 없는 사태가 일어난다.
            }
            catch (Exception e)
            {

            }
            finally
            {
                // Network.Disconnect();        << try에서 예외가 발생하면 호출되지 않을 수 있으니 finally에서 호출
            }

        }
            #endregion

            // 사용자 정의 예외 만들기
            // .NET은 약 100개의 예외 클래스가 정의되어 있지만
            // 내가 원하는 예외가 없을 수 있다.

            Child child = new Child("테스터" ,20);
            Console.WriteLine($"name : {child.name}");
            Console.WriteLine($"number : {child.number}");

            SignManage signManage = new SignManage(); // 회원가입 관리 객체
            
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("회원가입시도");
                    Console.WriteLine();

                    Console.Write("ID : ");
                    string email = Console.ReadLine();

                    Console.Write("PW : ");
                    string password = Console.ReadLine();

                    Console.Write("RePW : ");
                    string repw = Console.ReadLine();


                    signManage.SignIn(email, password, repw);
                    Console.WriteLine("성공");
                }

                catch (InvalidEmailException e)
                {
                    Console.WriteLine(e);
                    Console.ReadKey();
                }
                catch(InvalidPasswordException e)
                {
                    Console.WriteLine(e);
                    Console.ReadKey();
                }
                
            }
        }
    }
}
