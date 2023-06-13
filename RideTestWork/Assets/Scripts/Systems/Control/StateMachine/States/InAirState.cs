using Assets.Scripts.Systems.Control.Strategy;
using Assets.Scripts.Systems.Control.Strategy.Jobs.BreakDownJobs;
using Assets.Scripts.Systems.Control.Strategy.Jobs.GasDownJobs;
using UnityEngine;

namespace Assets.Scripts.Systems.Control.StateMachine.States
{
    public class InAirState : State
    {
        public InAirState() { }

        public override void Enter()
        {
            Worker.Instance.GasDownJob = new GasDownInAir();
            Worker.Instance.BreakDownJob = new BreakDownInAir();
        }

        public override void Exit()
        {
            Worker.Instance.ClearJobs();
        }
    }
}
