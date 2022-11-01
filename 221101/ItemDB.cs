using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _221101
{
    enum JOB
    {
        Warrior,
        Archor,
        Mage,
        Chief,
    }

    class Item
    {
        public int id;
        public string name;
        public int level;
        public JOB job;
        public int power;
        public Item(string csvData)
        {
            string[] datas = csvData.Split(',');
            id = int.Parse(datas[0]);
            name = datas[1];
            level = int.Parse(datas[2]);
            job = (JOB)Enum.Parse(typeof(JOB),datas[3]);        // string을 enum으로 파싱
            power = int.Parse(datas[4]);
        }
        public override string ToString()
        {
            return $"id : {id}, name : {name}, level : {level}, job : {job}, Att : {power}";
        }
    }
    internal class ItemDB
    {
        Item[] items;
        public ItemDB()
        {
            string csv = FileManager.Read("ItemDB.csv");
            string[] datas = csv.Split('\n');
            items = new Item[datas.Length - 1];     // 0번 째 열의 키 값은 제외

            for (int i = 1; i <= items.Length; i++)
                items[i - 1] = new Item(datas[i]);


        }
        public void ShowDB()
        {
            foreach (Item item in items)
                Console.WriteLine(item);
        }

    }
}
