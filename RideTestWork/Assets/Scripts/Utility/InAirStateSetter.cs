using Assets.Scripts.Systems.Event;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class InAirStateSetter : MonoBehaviour
    {
        #region Singleton
        private static InAirStateSetter _instance;

        public static InAirStateSetter Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindAnyObjectByType<InAirStateSetter>();
                }

                return _instance;
            }
        }
        #endregion

        [SerializeField] private float _inAirMinTime; // in seconds

        private bool _isCoroutineStarting = false;
        private Coroutine _coroutine;

        public void StopSettingUpAirState()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _isCoroutineStarting = false;
        }

        public void SetUpAirState()
        {
            if (_isCoroutineStarting)
                return;

            _isCoroutineStarting = true;
            _coroutine = StartCoroutine(ToAirStateRoutine());
        }


        private IEnumerator ToAirStateRoutine()
        {
            yield return new WaitForSeconds(_inAirMinTime);
            EventSystem.InvokeOnChangeStateToAir();
        }
    }
}