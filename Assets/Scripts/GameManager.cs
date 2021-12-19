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

        // Start is called before the first frame update
        void Start()
        {
            RotateObstacles();
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
    }
}