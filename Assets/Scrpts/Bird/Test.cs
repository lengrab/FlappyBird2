using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("Включился");
    }

    private void FixedUpdate()
    {
        Debug.Log("Обновилась физика!");
    }
    

    private void Update()
    {
        Debug.Log("Обновилась картинка!");
    }

    private void OnDisable()
    {
        Debug.Log("Выключился");
    }
}
