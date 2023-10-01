using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLib
{
    public class TimeUtility
    {
        public int changeMilliSecond(int minute, int second, int millisecond)
        {
            return (((minute + 1) * (second * 1000)) + (millisecond * 10));
        }

        public void timeUpdate(ref int minute, ref int second, ref int milliSecond)
        {
            if (++milliSecond >= 100)
            {
                milliSecond = 0;
                if (++second >= 60)
                {
                    second = 0;
                    minute++;
                }
            }
        }
        public string timeForamt(int minute, int second, int milliSecond)
        {
            string strMinute = minute < 10 ? "0" + minute : minute + "";
            string strSecond = second < 10 ? "0" + second : second + "";
            string strMilliSecond = milliSecond < 10 ? "0" + milliSecond : milliSecond + "";

            return $"{strMinute}:{strSecond}.{strMilliSecond}";
        }
    }
}