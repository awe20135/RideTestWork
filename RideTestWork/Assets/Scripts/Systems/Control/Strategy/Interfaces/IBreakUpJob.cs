using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Systems.Control.Strategy.Interfaces
{
    public interface IBreakUpJob
    {
        /// <returns>Is need to update</returns>
        void BreakUp(CarObject car);
    }
}
