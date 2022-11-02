using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace _221102
{
    [Serializable]
    struct Vector2
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    [Serializable]
    class Player
    {
        public string name { get; set; }
        public int level { get; set; }
        public int gold { get; set; }
        public Vector2 position { get; set; }
    }

    class Item
    {
        public int id;
        public string name;
        public string level;
        public string job;
        public int power;
        public Item(string csv)
        {
            string[] datas = csv.Split(',');
            id = int.Parse(datas[0]);
            name = datas[1];
            level = datas[2];
            job = datas[3];
            power = int.Parse(datas[4]);

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            if (false)
            {
                Player player = new Player()
                {
                    name = "플레이어1004",
                    level = 14,
                    gold = 3123123,
                    position = new Vector2() { x = 10, y = 20 },
                };


                // 플레이어의 데이터를 파일로 저장하기
                DirectoryInfo di = Directory.CreateDirectory("PlayerData");
                if (!di.Exists)
                    di.Create();
                string path = "PlayerData/PlayerData.txt";
                StreamWriter writer = new StreamWriter(path);
                // Json
                string json = JsonSerializer.Serialize(player);
                writer.WriteLine(json);
                writer.Close();


                StreamReader sr = new StreamReader("PlayerData/PlayerData.txt");
                string readjson = sr.ReadToEnd();
                sr.Close();

                Player p1 = JsonSerializer.Deserialize<Player>(readjson);           // Json형식의 데이터 파일 역직렬화

                Console.WriteLine($"name : {p1.name}");
                Console.WriteLine($"level : {p1.level}");
                Console.WriteLine($"gold : {p1.gold}");
                Console.WriteLine($"position : {p1.position}");

            }
            if (false)
            {
                List<Item> list = new List<Item>();
                StreamReader itemsr = new StreamReader("PlayerData/ItemDB.csv");
                itemsr.ReadLine();

                while (!itemsr.EndOfStream)
                {
                    string line = itemsr.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(line))
                    {
                        list.Add(new Item(line));
                    }
                }
                itemsr.Close();

                // 아이템 컬렉션에서 공격력 100이상만 추출
                // search 자료형은 select절에서 item자료형을 리턴했기에 IEnumeralber<Item>이다.
                var search = from item in list
                             where item.power > 100
                             select new { Name = item.name, Power = item.power };

                foreach (var value in search)
                    Console.WriteLine($"이름 : {value.Name}, 파워 : {value.Power}");

                // Func<Item, bool> predicate 
                Item[] itemArray = list.Where(item => item.power > 100).ToArray();
            }

        }
    }
}
