using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Systems.Event
{
    public static class EventSystem
    {
        public delegate void CarStateDelegate();

        public static event CarStateDelegate OnChangeStateToAir;
        public static event CarStateDelegate OnChangeStateToGround;

        public static void InvokeOnChangeStateToAir()
        {
            OnChangeStateToAir?.Invoke();
        }

        public static void InvokeOnChangeStateToGround()
        {
            OnChangeStateToGround?.Invoke();
        }
    }
}
