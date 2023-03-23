using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private int LevelIndex = 7;
    [SerializeField] private int MapIndex = 0;
    [SerializeField] private int addition;
    [SerializeField] private GameObject PortalMap;
    public static MapManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void MapDesign(GameObject other)
    {
        MapIndex++;
        if (MapIndex < LevelIndex)
        {
            Debug.Log(MapIndex);
            other.gameObject.transform.position += new Vector3(0, 0,addition);
        }
        else if (MapIndex == LevelIndex)
        {
            PortalMap.transform.position = other.gameObject.transform.position + new Vector3(0, 0, addition);
        }
    }

}
