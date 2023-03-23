using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float SpeedForce, TurboSpeedForce, HorizontalSpeedForce;
    [SerializeField] private float SpeedLimit, TurboSpeedLimit , HorizontalSpeedLimit;
    [SerializeField] private float positionYawFactor;
    [SerializeField] private float rollToControl;
    [SerializeField] private int Uplimit;
    private Rigidbody rb;
    [SerializeField] private GameObject[] Turbo;
    [SerializeField] private GameObject MaxTurbo;
    private float Horizontal, Vertical;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        ApplyRotation(Horizontal);
        MoveAhead();
        MoveHorizontal(Horizontal);
        MoveVertical(Vertical);
    }

    void ApplyRotation(float Horizontal)
    {
        float Yaw = Vertical * positionYawFactor;
        float Roll = Horizontal * rollToControl;
        transform.localRotation = Quaternion.Euler(Roll, 270, Yaw);
    }

    void MoveAhead()
    {
        Vector3 velocity = rb.velocity;
        bool AheadMode = Input.GetKey(KeyCode.C);
        bool fastMode = Input.GetKey(KeyCode.X);
        bool slowMode = Input.GetKey(KeyCode.Z);
        Vector3 vectorZ = new Vector3(0, 0, TurboSpeedForce);
        if (AheadMode)
        {
            SetActiveTurbo(true);
            SetActiveMaxTurbo(false);
            if (velocity.z < SpeedLimit)
            {
                rb.AddForce(vectorZ * Time.deltaTime * SpeedForce);
            }
        }
        else if (fastMode)
        {
            SetActiveMaxTurbo(true);
            SetActiveTurbo(true);
            if (velocity.z < TurboSpeedLimit)
            {
                rb.AddForce(vectorZ * Time.deltaTime * TurboSpeedForce);
            }
        }
        else if (slowMode)
        {
            SetActiveTurbo(false);
            SetActiveMaxTurbo(false);
            if (velocity.z > -TurboSpeedForce)
            {
                rb.AddForce(-vectorZ * Time.deltaTime * TurboSpeedForce);
            }
        }
    }
    void MoveHorizontal(float Horizontal)
    {
        Vector3 velocity = rb.velocity;
        Vector3 vectorX = new Vector3(Horizontal * SpeedForce, 0, 0);
        Vector3 vectorXX = new Vector3(HorizontalSpeedLimit, 0, 0);

        if (velocity.x < HorizontalSpeedLimit && velocity.x > -HorizontalSpeedLimit)
        {
            rb.AddForce(vectorX * Time.deltaTime * HorizontalSpeedForce);
        }
        else if (velocity.x > HorizontalSpeedLimit)
        {
            rb.AddForce(-vectorXX * Time.deltaTime * HorizontalSpeedForce);
        }
        else if (velocity.x < -HorizontalSpeedLimit)
        {
            rb.AddForce(vectorXX * Time.deltaTime * HorizontalSpeedForce);
        }
    }

    void MoveVertical(float Vertical)
    {
        Vector3 velocity = rb.velocity;
        Vector3 vectorY = new Vector3(0, Vertical * 10, 0);
        Vector3 vector = new Vector3(0, SpeedForce, 0);
        if (gameObject.transform.position.y < Uplimit)
        {
            if (velocity.y < TurboSpeedForce)
            {
                rb.AddForce(vectorY * Time.deltaTime * TurboSpeedForce);
            }
            else
            {
                rb.AddForce(-vector * Time.deltaTime * 10);
            }
        }
        else
        {
            rb.AddForce(-vector * Time.deltaTime * velocity.y);
            rb.AddForce(-vector * Time.deltaTime * SpeedForce);
        }
    }
    private void SetActiveTurbo(bool isActive)
    {
        foreach (GameObject turbo in Turbo)
        {
            var EmissionMode = turbo.GetComponent<ParticleSystem>().emission;
            EmissionMode.enabled = isActive;
        }
    }
    private void SetActiveMaxTurbo(bool isActive)
    {
        var EmissionTurboMode = MaxTurbo.GetComponent<ParticleSystem>().emission;
        EmissionTurboMode.enabled = isActive;

    }

}
