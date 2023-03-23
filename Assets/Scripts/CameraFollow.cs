using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 Distance;
    private float ConstantFollow = 1;
    [SerializeField] private float SmoothRate;
    void Start()
    {
        Distance = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 newposition = Vector3.Lerp(transform.position, target.position + Distance, ConstantFollow);
        Vector3 newSmoothposition = Vector3.Lerp(transform.position, target.position + Distance, SmoothRate);
        newposition.x = newSmoothposition.x;
        transform.position = newposition;
    }
}
