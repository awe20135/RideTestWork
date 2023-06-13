using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Systems.Control.Strategy.Interfaces
{
    public interface IGasDownJob
    {
        /// <returns>Is need to update</returns>
        bool GasDown(CarObject car);
    }
}
