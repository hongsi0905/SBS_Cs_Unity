using System;
using System.Threading;

namespace _221028
{
    internal class Timer
    {
        public delegate void OnEndEvent();
        public event OnEndEvent onEndTimer; // 이벤트형 델리게이트 

        int time;
        public void StartTimer(int second)
        {
            time = second * 1000;                   // ms 저장
            Thread thread = new Thread(OnTimer);    // 스레드 생성
            thread.Start();                         // 스레드 시작
        }
        private void OnTimer()
        {
            Thread.Sleep(time);                     // time 대기
            // Console.WriteLine("시간이 되었다");       // 시간 알림
            onEndTimer();

        }
    

    }


}
