using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Systems.Control.Strategy.Interfaces
{
    public interface IBreakDownJob
    { 
        /// <returns>Is need to update</returns>
        bool BreakDown(CarObject car);
    }
}
