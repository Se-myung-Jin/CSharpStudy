using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy
{
    public class EventLock
    {
        AutoResetEvent available = new AutoResetEvent(true);

        public void Acquire()
        {
            available.WaitOne(); // Reset은 문을 닫는 행위 but, AutoReset이기 때문에 할 필요없음
        }

        public void Release()
        {
            available.Set();
        }
    }
}
