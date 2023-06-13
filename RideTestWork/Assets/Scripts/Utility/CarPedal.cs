using Assets.Scripts.Systems.Control.Strategy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.Networking.UnityWebRequest;

namespace Assets.Scripts.Utility
{
    public class CarPedal : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public enum PedalType { Break, Gas }

        [SerializeField] private PedalType _pedalType; 
        [SerializeField] private CarObject _carObject; 

        private bool _isJobNeedUpdate = false;

        // Update is called once per frame
        void Update()
        {
            if(_isJobNeedUpdate)
                PedalDown();
        }

        private void OnButtonDown()
        {
            bool? jobResult = PedalDown();          
            if (jobResult.HasValue)
                _isJobNeedUpdate = jobResult.Value;
        }

        private void OnButtonUp()
        {
            _isJobNeedUpdate = false;
            switch (_pedalType)
            {
                case PedalType.Break:
                    Worker.Instance.BreakUp(_carObject);
                    break;
                case PedalType.Gas:
                    Worker.Instance.GasUp(_carObject);
                    break;
            }
        }

        private bool? PedalDown()
        {
            bool? jobResult = null;
            switch (_pedalType)
            {
                case PedalType.Break:
                    jobResult = Worker.Instance.BreakDown(_carObject);
                    break;
                case PedalType.Gas:
                    jobResult = Worker.Instance.GasDown(_carObject);
                    break;
            }
            return jobResult;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnButtonDown();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnButtonUp();
        }
    }
}