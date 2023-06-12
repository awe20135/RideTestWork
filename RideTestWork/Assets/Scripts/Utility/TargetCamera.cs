using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RideTestWork.Scripts.Utility
{
    public class TargetCamera : MonoBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private bool fixedY;

        private Vector3 _previousTargetPosition;

        private void Start()
        {
            _previousTargetPosition = _target.transform.position;
        }

        void Update()
        {
            Vector3 currentTargetPosition = _target.transform.position;

            MoveToTarget(currentTargetPosition - _previousTargetPosition);
            _previousTargetPosition = currentTargetPosition;
        }

        private void MoveToTarget(Vector3 targetPosition)
        {
            if(fixedY)
                targetPosition.y = 0;

            transform.position += targetPosition;
        }
    }
}