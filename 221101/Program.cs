using System;
using System.IO;
using System.Text;

namespace _221101
{
    internal class Program
    {
        class UserData
        {
            public string name;
            public int level;
            public int gold;

            public string GetSaveData()
            {
                string data = string.Empty;
                data += $"{name}\n";
                data += $"{level}\n";
                data += $"{gold}\n";
                return data;
            }
            public void SetSaveData(string data)
            {
                string[] datas = data.Split('\n');
                name = datas[0];
                level = int.Parse(datas[1]);
                gold = int.Parse(datas[2]);
            }
        }
        
        static void Main(string[] args)
        {
            if (false)
            {
                string str = "ABC,DEF,GHI";
                string[] splits = str.Split(',');        // string.Split(char) : 문자를 기준으로 문단나눔
                foreach (string split in splits)
                    Console.WriteLine(split);


                // 파일 읽기/쓰기
                // txt : 기본 텍스트 파일. 어떠한 형식이 없다.
                string projectPath = Directory.GetCurrentDirectory();
                string rootPath = $"{projectPath}/Database";

                // 해당 경로에 디렉토리가 있는가
                if (!Directory.Exists(rootPath))
                    Directory.CreateDirectory(rootPath);

                // ItemDB.txt 있는가
                string itemDbPath = $"{rootPath}/ItemDB.txt";
                if (!File.Exists(itemDbPath))
                {
                    Console.WriteLine("생성완료");
                    File.Create(itemDbPath);
                }

                WriteLog("입장");

                using (FileStream stream = new FileStream(itemDbPath, FileMode.OpenOrCreate))
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    while (!reader.EndOfStream)
                        Console.WriteLine(reader.ReadLine());
                }
            }

            if (false)
            {
                UserData user = new UserData();
                user.SetSaveData(FileManager.Read("ItemDB.txt"));

                Console.WriteLine($"이름 : {user.name}");
                Console.WriteLine($"레벨 : {user.level}");
                Console.WriteLine($"골드 : {user.gold}");

                //user.level += 1;
                FileManager.Write("ItemDB.txt", user.GetSaveData());
            }

            // 데이터 포맷 형식
            // XML : HTML의 Tag형식과 닮은 데이터 포맷
            // CSV : Comma Separated Value
            // Json : 

            ItemDB itemDB = new ItemDB();
            itemDB.ShowDB();

        }

        static void WriteLog(string log)
        {
            string path = $"{Directory.GetCurrentDirectory()}/Database/Log_{DateTime.Now.ToShortDateString()}.txt";
            // 해당 경로의 파일을 스트림하고 Writer이용해 쓰기모드 진입
            // using문 내에서 사용시 코드블록이 끝나고 자동으로 연결해제
            using (FileStream stream = new FileStream(path, FileMode.Append))
            using (StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.GetEncoding("utf-8")))
            {
                writer.WriteLine($"{DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")} : [{log}]");
            }

            Console.WriteLine("완료");
        }
    }
}
