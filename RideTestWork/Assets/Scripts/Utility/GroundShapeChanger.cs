using UnityEngine;
using UnityEngine.U2D;

namespace RideTestWork.Scripts.Utility
{
    public class GroundShapeChanger : MonoBehaviour
    {
        [SerializeField] private uint _numberOfPoints;
        [SerializeField] private uint _maxHillHeight;
        [SerializeField] private float _hillRounding;

        private void Start()
        {
            SpriteShapeController shape = GetComponent<SpriteShapeController>();
            float _groundLength = shape.spline.GetPosition(2).x - shape.spline.GetPosition(1).x;
            float _distanceBetweenPoints = _groundLength / _numberOfPoints;

            ChangeShape(shape, _distanceBetweenPoints);
        }

        private void ChangeShape(SpriteShapeController shape,  float distanceBetweenPoints)
        {
            float lastPointXPosition = shape.spline.GetPosition(1).x;
            for (int i = 1; i < _numberOfPoints; i++)
            {
                lastPointXPosition += distanceBetweenPoints;
                int splineIndex = i + 1;
                shape.spline.InsertPointAt(splineIndex, new Vector3(x: lastPointXPosition, y: GetNoizeValue(i)));
                shape.spline.SetTangentMode(splineIndex, ShapeTangentMode.Continuous);
                shape.spline.SetLeftTangent(splineIndex, Vector3.left * _hillRounding);
                shape.spline.SetRightTangent(splineIndex, Vector3.right * _hillRounding);
            }
        }

        private float GetNoizeValue(int currentIndex)
        {
            float noizeResult = Mathf.PerlinNoise(currentIndex + Random.Range(0, _numberOfPoints * _maxHillHeight), 0);
            return noizeResult < 0 ? 0 : noizeResult * _maxHillHeight;
        }
    }
}