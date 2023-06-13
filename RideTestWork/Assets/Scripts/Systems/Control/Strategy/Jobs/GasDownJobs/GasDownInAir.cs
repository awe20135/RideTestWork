using Assets.Scripts.Systems.Control.Strategy.Interfaces;
using Assets.Scripts.Utility;

namespace Assets.Scripts.Systems.Control.Strategy.Jobs.GasDownJobs
{
    public class GasDownInAir : IGasDownJob
    {
        public bool GasDown(CarObject car)
        {
            float currentRotation = car.Rigidbody.rotation;
            car.Rigidbody.MoveRotation(currentRotation + car.RotationSpeed);
            return true;
        }
    }
}
