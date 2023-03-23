using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Level[] serializeObjects;
    private Level Level;
    private int Level›ndex;
    public int level›ndex { get { return Level›ndex; } set { value = Level›ndex; } }
    private bool TrueOrFalse;
    public static LevelManager instance;

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
        Level›ndex = PlayerPrefs.GetInt("Level›ndex");
    }

    void Start()
    {
        CreateEnemy();
    }


    public void NextLevel(bool isTrue)
    {
        if (isTrue == true)
        {
            Level›ndex++;
            PlayerPrefs.SetInt("Level›ndex", Level›ndex);
        }
        else
        {
            return;
        }
    }

    void CreateEnemy()
    {
        Level = serializeObjects[Level›ndex];
        int currentIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        switch (currentIndex)
        {
            case 0:
                Instantiate(Level.Map1Enemy);
                break;
            case 1:
                Instantiate(Level.Map2Enemy);
                break;
            case 2:
                Instantiate(Level.Map3Enemy);
                break;
        }
    }
}
