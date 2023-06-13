using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class GroundObjectsController : MonoBehaviour
    { 
        [SerializeField] private int _groundLength;
        [SerializeField] private int _numberGroundSpawnLimit;
        [SerializeField] private int _numberGroundDestroyLimit;
        [SerializeField] private float _spawnDelay; // in seconds
        [SerializeField] private Transform _carTransform;
        [SerializeField] private GameObject _startGroundGameObject;
        [SerializeField] private GameObject _groundPrefab;

        private Queue<GameObject> _groundObjects;
        private GameObject _lastGroundObject;

        // Start is called before the first frame update
        void Start()
        {
            _groundObjects = new Queue<GameObject>();
            _groundObjects.Enqueue(_startGroundGameObject);
            _lastGroundObject = _startGroundGameObject;

            StartCoroutine(GroundControlRoutine());
        }

        private IEnumerator GroundControlRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnDelay);

                float targetFirstGroundDistance = _carTransform.position.x - _groundObjects.Peek().transform.position.x;
                float targetLastGroundDistance = _lastGroundObject.transform.position.x - _carTransform.position.x;

                if (targetFirstGroundDistance > _numberGroundDestroyLimit * _groundLength)
                    GroundDestroy();

                if (targetLastGroundDistance < _numberGroundSpawnLimit * _groundLength && _groundObjects.Count < _numberGroundSpawnLimit)
                    GroundSpawn();
            }
        }

        private void GroundSpawn()
        {
            GameObject spawnedObject = InstantiateGroundObject();
            _groundObjects.Enqueue(spawnedObject);
            _lastGroundObject = spawnedObject;
        }

        private void GroundDestroy()
        {
            GameObject objectToDestroy = _groundObjects.Dequeue();
            Destroy(objectToDestroy);
        }

        private GameObject InstantiateGroundObject()
        {
            GameObject spawnedObject = Instantiate(_groundPrefab, transform);
            spawnedObject.transform.localPosition = new Vector3(x: _lastGroundObject.transform.position.x + _groundLength,
                                                                y: _lastGroundObject.transform.position.y,
                                                                z: _lastGroundObject.transform.position.z);
            return spawnedObject;
        }
    }
}