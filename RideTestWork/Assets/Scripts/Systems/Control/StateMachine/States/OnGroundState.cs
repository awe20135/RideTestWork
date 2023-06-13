using Assets.Scripts.Systems.Control.Strategy;
using Assets.Scripts.Systems.Control.Strategy.Jobs.BreakDownJobs;
using Assets.Scripts.Systems.Control.Strategy.Jobs.GasDownJobs;
using Assets.Scripts.Systems.Control.Strategy.Jobs.GasUpJobs;
using Assets.Scripts.Systems.Control.Strategy.Jobs.BreakUpJobs;
using UnityEngine;

namespace Assets.Scripts.Systems.Control.StateMachine.States
{
    public class OnGroundState : State
    {
        public OnGroundState() { }

        public override void Enter()
        {
            Worker.Instance.GasDownJob = new GasDownOnGround();
            Worker.Instance.GasUpJob = new GasUpOnGround();
            Worker.Instance.BreakDownJob = new BreakDownOnGround();
            Worker.Instance.BreakUpJob = new BreakUpOnGround();
        }

        public override void Exit()
        {
            Worker.Instance.ClearJobs();
        }
    }
}
