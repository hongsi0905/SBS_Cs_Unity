using System;
using System.Collections.Generic;

namespace _221024
{
    internal class Program
    {
        delegate void ThereIsFire(string location);

        static void Call119(string location)
        {
            Console.WriteLine($"119 연락 {location} 화재");
        }
        static void ShotOut(string location)
        {
            Console.WriteLine($"{location} 화재");
        }
        static void Escape(string location)
        {
            Console.WriteLine($"{location} 탈출");
        }

        static void Main(string[] args)
        {
            if (false)
            {
                GameManager gameManager = new GameManager();
                Player[] players = new Player[3];
                for (int i = 0; i < players.Length; i++)
                    players[i] = gameManager.GetNewPlayer();

                Console.WriteLine("모든 플레이어 200 타격");
                foreach (Player p in players)
                    p.TakeDamage(200);

                gameManager.ShowAllPlayer();
                gameManager.Notify("안녕");
            }

            // delegate chain : 함수 추가참조
            ThereIsFire onFire = null;
            onFire = Call119;
            onFire += ShotOut;
            onFire += Escape;

            onFire -= ShotOut;              // 델리게이트에서 해당 함수 제거

            onFire("우리집");



        }

    }

    // 함수가 아니고 자료형의 선언이기에 내용부가 없다
    public delegate void PlayerEvent(Player player);
    public delegate void NotifyEvent(string str);

    public class GameManager
    {
        // 모든 플레이어가 담긴 리스트
        List<Player> playerList = new List<Player>();
        List<Player> deadplayerList = new List<Player>();

        // 모든 사용자에게 공지사항을 보내는 함수
        // 모든 사용자가 공지를 받는 함수를 담고 있다.
        NotifyEvent onNotifyAllPlayer = null;

        // 게임매니저 요청으로 새로운 플레이어 생성 후 외부전달
        public Player GetNewPlayer()
        {
            Console.WriteLine("새로운 플레이어 생성");
            Console.Write("이름 : ");
            string name = Console.ReadLine();
            int hp = 0;
            while (hp <= 0)
            {
                try
                {
                    Console.Write("체력 : ");
                    hp = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"HP 입력 실패 : {e.Message}");
                    hp = 0;
                }
            }
            // 입력받은 값을 통해 새로운 플레이어 객체생성
            Player newPlayer = new Player(name, hp, OnDeadPlayer);
            playerList.Add(newPlayer);

            // 새로운 플레이어의 OnNotify함수를 GM의 델리게이트 변수에 체인
            onNotifyAllPlayer += newPlayer.OnNotify;

            return newPlayer;
        }
        // 현재 모든 플레이어 정보출력
        // 출력내용은 이름과 생존여부
        public void ShowAllPlayer()
        {
            Console.WriteLine("모든 플레이어 정보");
            Console.WriteLine("=======[생존]=======");
            for (int i = 0; i < playerList.Count; i++)
            {
                Player player = playerList[i];              // i 번째 플레이어 대입
                Console.WriteLine(player);                  // 해당 플레이어 출력
            }
            Console.WriteLine("=======[죽음]=======");
            foreach(Player dp in deadplayerList)
            {
                Console.WriteLine(dp);
            }
        }
        public void Notify(string notify)
        {
            onNotifyAllPlayer(notify);
        }

        // 누군가 죽었을 때 불리는 함수
        private void OnDeadPlayer(Player player)
        {
            playerList.Remove(player);      // 리스트 내부에서 player 제거
            deadplayerList.Add(player);     // 죽은 플레이어 리스트 추가
        }
    }


    public class Player
    {
        // 상수 키워드 const / readonly
        // const : 선언과 동시에 초기화
        // readonly : 생성자에 한해 초기 값 대입 가능
        public readonly int MAX_HP;                 // 최대체력은 변치않기에 상수처리
        const int MAX_NAME_LENGTH = 12;      // 이 값은 모든 플레이어객체가 동일하기에 const 상수 사용
        string name;
        int hp;
        PlayerEvent onDead;
        NotifyEvent onTalkToParty;
        // 프로퍼티
        public string Name => name;         // get에 한해 표현식 생략 (=람다식)
        public bool IsAlive => hp > 0;      // 특정 수식을 통해 프로퍼티 값 조절

        public Player(string name, int hp, PlayerEvent onDead)
        {
            MAX_HP = hp;                    // readonly 상수는 객체별 다른 값 할당
            this.name = name;
            this.hp = hp;
            this.onDead = onDead;
        }
        
        public void TakeDamage(int power)
        {
            hp -= power;
            if (hp <= 0)
            {
                hp = 0;
                onDead(this);
            }
        }
        // Gm이 보내는 공지사항을 플레이어가 받는 함수
        public void OnNotify(string notify)
        {
            Console.WriteLine($"{name} 공지사항 도착 : {notify}");
        }

        // Player 객체를 출력 시 규격따라 생성
        // 따라 hp, maxHP 출력 불필요
        public override string ToString()
        {
            return $"{name} : {hp}/{MAX_HP}";
        }
    }
}




