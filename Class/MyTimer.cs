using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleRecitation
{
    class MyTimer
    {
        readonly private int maxSec;
        private double sec;
        private double ms;

        public MyTimer()
        {
            this.maxSec = 180;
            sec = maxSec;
            ms = 0;
        }

        public MyTimer(int max)
        {
            this.maxSec = max;
            sec = maxSec;
            ms = 0;
        }

        public double Sec
        {
            get { return sec; }
            set { sec = value; }
        }

        public double Ms
        {
            get { return ms; }
            set { ms = value; }
        }

        public int GetMaxSec()
        {
            return maxSec;
        }

        public void Reset()
        {
            sec = maxSec;
            ms = 0;
        }

        public void Decrease()
        {
            ms--;

            if (ms < 1)
            {
                ms += 99;
                sec -= 1;
            }
        }

        public bool TimeOver()
        {
            if(sec < 1)
            { 
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
