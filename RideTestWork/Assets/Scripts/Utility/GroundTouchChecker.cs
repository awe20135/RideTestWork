using Assets.Scripts.Systems.Control.Strategy;
using Assets.Scripts.Systems.Event;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Utility
{
    public class GroundTouchChecker : MonoBehaviour
    {
        private static int _collisionCount = 0;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!IsCar(collision))
                return;

            InAirStateSetter.Instance.StopSettingUpAirState();

            _collisionCount++;
            EventSystem.InvokeOnChangeStateToGround();
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (!IsCar(collision))
                return;

            _collisionCount--;

            if (_collisionCount == 0)
                InAirStateSetter.Instance.SetUpAirState();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Head"))
            {
                Worker.Instance.ClearJobs();
                SceneManager.LoadScene(0);
            }

        }

        private bool IsCar(Collision2D collision)
        {
            return collision.gameObject.tag.Equals("Car");
        }
    }
}