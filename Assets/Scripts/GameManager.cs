using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcanoid
{
    public class GameManager : MonoBehaviour
    {
        [Tooltip("Ускорение движения платформ"), SerializeField]
        public UnityEngine.ForceMode _platformAcceleration = (ForceMode)1;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}