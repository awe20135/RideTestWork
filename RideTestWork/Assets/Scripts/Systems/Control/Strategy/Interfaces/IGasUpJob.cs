using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Systems.Control.Strategy.Interfaces
{
    public interface IGasUpJob
    {
        /// <returns>Is need to update</returns>
        void GasUp(CarObject car);
    }
}
