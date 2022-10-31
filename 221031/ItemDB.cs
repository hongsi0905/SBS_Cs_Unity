using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _221031
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
        public string name;
        public int level;
        public JOB job;     
        public int power;

        public Item(string name, int level, JOB job, int power)
        {
            this.name = name;
            this.level = level;
            this.job = job;
            this.power = power;
        }
    }

    internal class ItemDB
    {
        List<Item> itemList;

        public ItemDB()
        {
            itemList = new List<Item>();
            itemList.Add(new Item("장검", 50, JOB.Warrior, 56));
            itemList.Add(new Item("석궁", 60, JOB.Archor, 48));
            itemList.Add(new Item("ㄱ완드", 30 ,JOB.Mage, 36));
            itemList.Add(new Item("ㄴ완드", 30, JOB.Mage, 36));
            itemList.Add(new Item("ㄷ완드", 30, JOB.Mage, 36));
            itemList.Add(new Item("ㄹ완드", 30 ,JOB.Mage, 36));
            itemList.Add(new Item("ㄱ단검", 40, JOB.Chief, 27));
            itemList.Add(new Item("ㄴ단검", 40, JOB.Chief, 27));
            itemList.Add(new Item("아대", 20, JOB.Chief, 11));
            itemList.Add(new Item("ㄱ둔기", 10, JOB.Warrior, 23));
            itemList.Add(new Item("ㄴ둔기", 10, JOB.Warrior, 23));
            itemList.Add(new Item("ㄷ둔기", 10, JOB.Warrior, 23));
            itemList.Add(new Item("ㄹ둔기", 10, JOB.Warrior, 23));
            itemList.Add(new Item("ㅁ둔기", 10, JOB.Warrior, 23));

        }

        // 해당 이름이 포함된 아이템을 배열로 묶어 반환하는 함수
        public Item[] GetItem(string containStr)
        {
            var search = from item in itemList
                         where item.name.Contains(containStr)
                         select item;
            return search.ToArray();
        }


    }
}
