using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GXPEngine.GXPEngine
{
    internal class EventSystem : GameObject
    {
        public static EventSystem instance;
        public event Action onClick;
        public EventSystem()
        {
            instance = this;
        }

        public void Click()
        {
            onClick?.Invoke();
        }
    }
}
