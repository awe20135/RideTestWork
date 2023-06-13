using Assets.Scripts.Systems.Control.StateMachine.States;
using Assets.Scripts.Systems.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Systems.Control.StateMachine
{
    public class StateMachinePlayer : MonoBehaviour
    {
        private Dictionary<string, State> _states;
        private StateMachine stateMachine;

        private void Start()
        {
            _states = new Dictionary<string, State>()
            {
                {"Idle", new IdleState() },
                {"InAir", new InAirState() },
                {"OnGround", new OnGroundState() },
            };

            stateMachine = new StateMachine();
            stateMachine.Initialize(_states["Idle"]);
        }

        private void InAirStateChange() => stateMachine.ChangeState(_states["InAir"]);
        private void OnGroundStateChange() => stateMachine.ChangeState(_states["OnGround"]);

        private void OnEnable()
        {
            EventSystem.OnChangeStateToAir += InAirStateChange;
            EventSystem.OnChangeStateToGround += OnGroundStateChange;
        }

        private void OnDisable()
        {
            EventSystem.OnChangeStateToAir += InAirStateChange;
            EventSystem.OnChangeStateToGround += OnGroundStateChange;
        }
    }
}
