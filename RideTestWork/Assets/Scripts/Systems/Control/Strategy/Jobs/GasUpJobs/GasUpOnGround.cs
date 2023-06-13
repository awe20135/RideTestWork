using Assets.Scripts.Systems.Control.Strategy.Interfaces;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Systems.Control.Strategy.Jobs.GasUpJobs
{
    internal class GasUpOnGround : IGasUpJob
    {
        public void GasUp(CarObject car)
        {
            JointMotor2D newMotor = new JointMotor2D { motorSpeed = 0, maxMotorTorque = car.MotorTorque };
            foreach (var wheel in car.Wheels)
            {
                wheel.motor = newMotor;
            }
        }
    }
}
