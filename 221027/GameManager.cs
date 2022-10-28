using System;
using System.Collections.Generic;
using System.Threading;

namespace _221027
{

    internal class GameManager
    {
        struct Vector2
        {
            public int x;
            public int y;

            public Vector2(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            // 연산자 오버로드 : 자체제작한 Vector2자료형을 더할 수 없기에 오버로드를 통해 더할 수 있게 재정의
            public static Vector2 operator +(Vector2 v1, Vector2 v2)
            {
                return new Vector2(v1.x + v2.x, v1.y + v2.y);
            }
            public static Vector2 operator -(Vector2 v1, Vector2 v2)
            {
                return new Vector2(v1.x - v2.x, v1.y - v2.y);
            }
        }
        enum VECTOR
        {
            UP,
            DOWN,
            LEFT,
            RIGHT,
        }

        Vector2[] vectorToPos = { new Vector2(0, -1), new Vector2(0, 1), new Vector2(-1, 0), new Vector2(1, 0) };

        const char SIGN_PLAYER = '★';
        const char SIGN_WALL = '■';
        const char SIGN_BLANK = '　';

        char[,] backgrounds;    // 2차원 배열 배경
        Vector2 WLD_SIZE;       // 맵 사이즈
        Vector2 playerPos;      // 플레이어 위치


        bool isGame;        // 게임 온오프

        public void GameStart()
        {
            // 플레이어 위치 그리기
                Init();
            while (isGame)
            {
                RenderBackground();
                Input();
            }
            SetCursor(WLD_SIZE);
            
        }
        // 실행 시 초기값 할당함수
        private void Init()
        {
            // 백그라운드 초기화
            WLD_SIZE = new Vector2(7, 7);
            backgrounds = new char[WLD_SIZE.y, WLD_SIZE.x];
            for(int y=0; y<WLD_SIZE.y; y++)
            {
                for(int x=0; x<WLD_SIZE.x; x++)
                {
                    // 화면 외곽선 생성
                    if (x == 0 || x == WLD_SIZE.x - 1 || y == 0 || y == WLD_SIZE.y - 1)
                        backgrounds[y, x] = SIGN_WALL;
                    else
                        backgrounds[y, x] = SIGN_BLANK;
                }
            }
            // 장애물 대입
            backgrounds[1, 1] = SIGN_WALL;
            backgrounds[2, 2] = SIGN_WALL;


            playerPos = new Vector2();
            playerPos.x = WLD_SIZE.x / 2;
            playerPos.y = WLD_SIZE.y / 2;


            isGame = true;                   // 게임시작

            Console.CursorVisible = false;   // 커서지우기
        }
        private void Input()
        {
            // 키입력이 없으면
            if (Console.KeyAvailable)
                return;
            ConsoleKeyInfo KeyInfo = Console.ReadKey(true);
            switch (KeyInfo.Key)
            {

                case ConsoleKey.LeftArrow:
                    if (IsMovePlayer(playerPos, VECTOR.LEFT))
                        playerPos += vectorToPos[(int)VECTOR.LEFT];
                    break;
                case ConsoleKey.RightArrow:
                    if (IsMovePlayer(playerPos, VECTOR.RIGHT))
                        playerPos += vectorToPos[(int)VECTOR.RIGHT];
                    break;
                case ConsoleKey.UpArrow:
                    if (IsMovePlayer(playerPos, VECTOR.UP))
                        playerPos += vectorToPos[(int)VECTOR.UP];
                    break;
                case ConsoleKey.DownArrow:
                    if (IsMovePlayer(playerPos, VECTOR.DOWN))
                        playerPos += vectorToPos[(int)VECTOR.DOWN];
                    break;
                

            }

        }

        // 특정 위치에서 원하는 방향으로 움직이는가
        private bool IsMovePlayer(Vector2 playerPos, VECTOR vector)
        {
            // VECTOR 자료형 값을 int값으로 변환 후 원하는 방향 값을 정하고
            // 이후 매개변수 playerPos에 더한다.
            // 가상의 위치를 잡고 벽일 경우 플레이어는 움직일 수 없다는 사실전달
            playerPos += vectorToPos[(int)vector];
            return backgrounds[playerPos.y, playerPos.x] != SIGN_WALL;
        }

        private void RenderBackground()
        {
            SetCursor(0,0);
            for (int y = 0; y < WLD_SIZE.y; y++)
            {
                for (int x = 0; x < WLD_SIZE.x; x++)
                {
                    bool isPlayer = x == playerPos.x && y == playerPos.y;
                    Console.Write(isPlayer ? SIGN_PLAYER : backgrounds[y, x]);
                }
                Console.WriteLine();
            }


        }



        private void SetCursorx(int x)
        {
            Console.CursorLeft = x * 2;
        }
        private void SetCursory(int y)
        {
            Console.CursorTop = y;
        }
        private void SetCursor(int x, int y)
        {
            Console.CursorLeft = x * 2;
            Console.CursorTop = y;
        }
        private void SetCursor(Vector2 position)
        {
            Console.CursorLeft = position.x;
            Console.CursorTop = position.y;
        }

    }
}
