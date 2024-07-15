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

        public void AcquireV3()
        {
            while (true)
            {
                if (Interlocked.CompareExchange(ref locked, 1, 0) == 0)
                    break;

                Thread.Sleep(1); // 무조건 휴식
                Thread.Sleep(0); // 조건부 양보 => 우선순위가 높은 스레드에게 양보
                Thread.Yield(); //  관대한 양보 => 현재 실행할 수 있는 스레드가 존재하면 양보
            }
        }
    }
}
