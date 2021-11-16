using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewInputScript : MonoBehaviour
{
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
    }

    //4. Дезактивировать в OnDisable
    private void OnDisable()
    {
        controls.ActionMap.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
