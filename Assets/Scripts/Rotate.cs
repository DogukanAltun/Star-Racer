using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float xValue;
    public float yValue;
    public float zValue;
    void Update()
    {
        transform.Rotate(xValue, yValue, zValue);
    }
}
