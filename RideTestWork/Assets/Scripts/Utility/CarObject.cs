using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class CarObject : MonoBehaviour
    {
        public float MotorSpeed { get => _motorSpeed; }
        public float MotorTorque { get => _motorTorque; }
        public float RotationSpeed { get => _rotationSpeed; }
        public float RotationDelay { get => _rotationDelay; }
        public WheelJoint2D[] Wheels { get => _wheels; }
        public Rigidbody2D Rigidbody { get => _rigidbody; }

        [SerializeField] private float _motorSpeed;
        [SerializeField] private float _motorTorque;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _rotationDelay;
        [SerializeField] private WheelJoint2D[] _wheels;

        private Rigidbody2D _rigidbody;

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}