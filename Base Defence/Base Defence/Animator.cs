using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Base_Defence
{
    class Animator
    {
        Timer Timer;

        public Animator(int Interval)
        {
            Timer NewTimer = new Timer(Interval);
            NewTimer.Start();
            Timer = NewTimer;
        }

        public void AttactEvent(ElapsedEventHandler e)
        {
            Timer.Elapsed += e;
        }
    }
}
