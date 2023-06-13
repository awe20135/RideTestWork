using UnityEngine;
using UnityEngine.U2D;

namespace Assets.Scripts.Utility
{
    public class GroundShapeChanger : MonoBehaviour
    {
        [SerializeField] private uint _numberOfPoints;
        [SerializeField] private uint _maxHillHeight;
        [SerializeField] private float _hillRounding;

        private void Start()
        {
            SpriteShapeController shape = GetComponent<SpriteShapeController>();
            float _groundLength = shape.spline.GetPosition(1).x - shape.spline.GetPosition(0).x;
            float _distanceBetweenPoints = _groundLength / _numberOfPoints;

            ChangeShape(shape, _distanceBetweenPoints);
        }

        private void ChangeShape(SpriteShapeController shape,  float distanceBetweenPoints)
        {
            float lastPointXPosition = shape.spline.GetPosition(0).x;
            for (int i = 1; i < _numberOfPoints; i++)
            {
                lastPointXPosition += distanceBetweenPoints;
                int splineIndex = i;
                shape.spline.InsertPointAt(splineIndex, new Vector3(x: lastPointXPosition, y: GetNoizeValue(i)));
                shape.spline.SetTangentMode(splineIndex, ShapeTangentMode.Continuous);
                shape.spline.SetLeftTangent(splineIndex, Vector3.left * _hillRounding);
                shape.spline.SetRightTangent(splineIndex, Vector3.right * _hillRounding);
            }
        }

        private float GetNoizeValue(int currentIndex)
        {
            float noizeResult = Mathf.PerlinNoise(currentIndex + Random.Range(0, _numberOfPoints * _maxHillHeight), 0) * _maxHillHeight;
            return (noizeResult > _maxHillHeight ? _maxHillHeight : noizeResult) * (Random.Range(-1, 1) < 0 ? -1 : 1);
        }
    }
}