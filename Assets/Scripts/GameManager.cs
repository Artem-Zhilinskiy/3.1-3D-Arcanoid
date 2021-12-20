using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcanoid
{
    public class GameManager : MonoBehaviour
    {
        [Tooltip("Ускорение движения платформ"), SerializeField]
        public UnityEngine.ForceMode _platformAcceleration = (ForceMode)1;

        //Здесь заданы препятствия всех уровней
        [Header("Массив препятствий"), SerializeField]
        public Transform[] _obstacles;

        //Задать шар
        [Header("Шар"), SerializeField]
        public Transform _sphere;

        // Start is called before the first frame update
        void Start()
        {
            RotateObstacles();
            EventHandler();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void RotateObstacles()
        {
            foreach (var _obstacle in _obstacles)
            {
                _obstacle.rotation = Random.rotation;
            }
        }
  
        private void DesactivateObstacle (Transform _transform)
        {
            foreach (var _obstacle in _obstacles)
            {
                if (_transform == _obstacle)
                {
                    _transform.gameObject.SetActive(false);
                }
            }
        }

        private void EventHandler()
        {
            _sphere.GetComponent<SphereControls>().DesactivateObstacleEvent += DesactivateObstacle;
        }

        private void TestEvent()
        {
            Debug.Log("Test event");
        }
    }
}