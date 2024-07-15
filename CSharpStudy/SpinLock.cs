using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy
{
    public class SpinLock
    {
        int locked = 0;

        public void Acquire()
        {
            while (true)
            {
                int original = Interlocked.Exchange(ref locked, 1);
                if (original == 0)
                    break;
            }
        }

        public void Release()
        {
            locked = 0;
        }

        public void AcquireV2()
        {
            while (true)
            {
                if (Interlocked.CompareExchange(ref locked, 1, 0) == 0)
                    break;
            }
        }
    }
}
