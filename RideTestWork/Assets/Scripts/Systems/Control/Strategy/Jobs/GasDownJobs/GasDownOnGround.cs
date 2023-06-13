using Assets.Scripts.Systems.Control.Strategy.Interfaces;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Systems.Control.Strategy.Jobs.GasDownJobs
{
    internal class GasDownOnGround : IGasDownJob
    {
        public bool GasDown(CarObject car)
        {
            JointMotor2D newMotor = new JointMotor2D { motorSpeed = car.MotorSpeed, maxMotorTorque = car.MotorTorque };
            foreach (var wheel in car.Wheels)
            {
                wheel.motor = newMotor;
            }
            return false;
        }
    }
}
