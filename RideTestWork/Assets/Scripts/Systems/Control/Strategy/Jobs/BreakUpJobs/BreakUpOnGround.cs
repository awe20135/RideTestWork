using Assets.Scripts.Systems.Control.Strategy.Interfaces;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Systems.Control.Strategy.Jobs.BreakUpJobs
{
    internal class BreakUpOnGround : IBreakUpJob
    {
        public void BreakUp(CarObject car)
        {
            JointMotor2D newMotor = new JointMotor2D { motorSpeed = 0, maxMotorTorque = car.MotorTorque };
            foreach (var wheel in car.Wheels)
            {
                wheel.motor = newMotor;
            }
        }
    }
}
