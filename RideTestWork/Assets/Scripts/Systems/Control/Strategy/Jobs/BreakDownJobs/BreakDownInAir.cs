using Assets.Scripts.Systems.Control.Strategy.Interfaces;
using Assets.Scripts.Utility;

namespace Assets.Scripts.Systems.Control.Strategy.Jobs.BreakDownJobs
{
    public class BreakDownInAir : IBreakDownJob
    {
        public bool BreakDown(CarObject car)
        {
            float currentRotation = car.Rigidbody.rotation;
            car.Rigidbody.MoveRotation(currentRotation - car.RotationSpeed);
            return true;
        }
    }
}
