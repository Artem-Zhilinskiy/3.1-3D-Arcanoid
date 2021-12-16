﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Arcanoid
{
    public class SphereControls : MonoBehaviour
    {
        //Импорт настроек из GameManager
        //Объявление переменной, чтобы можно было получить доступ в других методах. Надо в инспекторе Unity добавить.
        [SerializeField] private GameManager GameManager;

        [Tooltip("Скорость движения шара")] public int _moveSpeed = 1;

        //1. Первое что нужно сделать при создании скрипта управления в NewInputSystem
        public PlatformControls1 controls;

        //2. Второе, что нужно сделать - инициализировать controls в Awake
        private void Awake()
        {
            controls = new PlatformControls1();
        }

        //3. Активировать в OnEnable ActionMap
        private void OnEnable()
        {
            controls.ActionMap.Enable();

            //Подключить события
            controls.ActionMap.Launch.performed += OnLaunch;
        }

        //4. Дезактивировать в OnDisable
        private void OnDisable()
        {
            controls.ActionMap.Launch.performed -= OnLaunch;
            controls.ActionMap.Disable();
        }

        public void OnLaunch(CallbackContext context)
        {
            StartCoroutine(MoveForward());
        }

        // Start is called before the first frame update
        public void Start()
        {

        }

        private IEnumerator MoveForward()
        {
            while (true)
            {
                transform.position += _moveSpeed * Time.deltaTime * transform.forward;
                yield return null;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("OnCollision");
            
            //Вектор, от которого поворачиваем
            Vector3 _beforeCollision = this.transform.forward;

            //Определение точки контакта
            ContactPoint _contact = collision.contacts[0];

            //Вектор, куда поворачиваем
            Vector3 _afterCollision = Vector3.Reflect(_beforeCollision, _contact.normal);

            //Сам поворот
            Quaternion _rotation = Quaternion.FromToRotation(_beforeCollision, _afterCollision);
            Debug.Log("rotation "+_rotation);

            //Присвоение поворота
            transform.rotation = _rotation;

            //Блок отладки
            Debug.Log("_beforeCollision " + _beforeCollision);
            Debug.Log("_afterCollision " + _afterCollision);
            Debug.Log("_contact.normal " + _contact.normal);
        }
    }
}
