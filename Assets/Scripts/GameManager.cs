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

        //Определить ворота
        [Header("Ворота"), SerializeField]
        public Transform _gate1;
        public Transform _gate2;

        //Счётчик жизней
        [Header("Счётчик жизней"), SerializeField]
        private int _lifeCounter = 5;

        // Start is called before the first frame update
        void Start()
        {
            RotateObstacles();
            ObstacleEventHandler();
            LifeEventHandler();
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
                    //Увеличение скорость движения шара
                    _sphere.GetComponent<SphereControls>().IncreaseSpeed();
                }
            }
        }

        private void ObstacleEventHandler()
        {
            _sphere.GetComponent<SphereControls>().DesactivateObstacleEvent += DesactivateObstacle;
        }

        //Счёт жизней
        private void LifeCounter()
        {
            _lifeCounter -= 1;
            if (_lifeCounter > 0)
            {
                Debug.Log("Шар упущен. Осталось жизней: " + _lifeCounter);
            }
            else
            {
                Debug.Log("Шар упущен. Осталось жизней:" + _lifeCounter + " Игра окончена.");
                UnityEditor.EditorApplication.isPaused = true;
            }
        }

        private void LifeEventHandler()
        {
            _gate1.GetComponent<GateControls>().SphereLeftEvent += LifeCounter;
            _gate2.GetComponent<GateControls>().SphereLeftEvent += LifeCounter;
        }
    }
}