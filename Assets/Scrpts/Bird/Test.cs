using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("���������");
    }

    private void FixedUpdate()
    {
        Debug.Log("���������� ������!");
    }
    

    private void Update()
    {
        Debug.Log("���������� ��������!");
    }

    private void OnDisable()
    {
        Debug.Log("����������");
    }
}
