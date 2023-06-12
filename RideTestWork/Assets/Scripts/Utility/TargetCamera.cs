using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RideTestWork.Scripts.Utility
{
    public class TargetCamera : MonoBehaviour
    {
        [SerializeField] private GameObject target;

        private Vector3 _previousTargetPosition;

        private void Start()
        {
            _previousTargetPosition = target.transform.position;
        }

        void Update()
        {
            Vector3 currentTargetPosition = target.transform.position;

            MoveToTarget(currentTargetPosition - _previousTargetPosition);
            _previousTargetPosition = currentTargetPosition;
        }

        private void MoveToTarget(Vector3 targetPosition)
        {
            transform.position += targetPosition;
        }
    }
}