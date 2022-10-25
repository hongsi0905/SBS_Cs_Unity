using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _221025
{
    // 반환형이 없고 매개변수로 string, int를 하나씩 받는 함수 델리게이트
    public delegate void DayResultEvent(int days, int hours, int min, int sec);

    internal class DDay
    {
        public static void Calculator(DayResultEvent onResult)
        {
            Console.WriteLine("디데이 계산기");

            Console.Write("년 : ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("월 : ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("일 : ");
            int day = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("첫 날 기준 (Y/N)");
            bool isFirst = Console.ReadKey().KeyChar == 'y';

            DateTime dDay = new DateTime(year, month, day);
            TimeSpan span = DateTime.Today - dDay;
            int days = (int)span.TotalDays + (isFirst ? 1 : 0);

            onResult(days, (int)span.TotalHours, (int)span.TotalMinutes, (int)span.TotalSeconds);
        }

    }
}
