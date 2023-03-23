using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    private MapManager mapManager;

    private void Awake()
    {
        mapManager = GameObject.FindObjectOfType(typeof(MapManager)) as MapManager;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            mapManager.MapDesign(gameObject);
        }
    }
}
