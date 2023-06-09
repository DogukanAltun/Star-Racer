using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Level[] serializeObjects;
    private Level Level;
    private int Levelİndex;
    public int levelİndex { get { return Levelİndex; } set { value = Levelİndex; } }
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
        Levelİndex = PlayerPrefs.GetInt("Levelİndex");
    }

    void Start()
    {
        CreateEnemy();
    }


    public void NextLevel(bool isTrue)
    {
        if (isTrue == true)
        {
            Levelİndex++;
            PlayerPrefs.SetInt("Levelİndex", Levelİndex);
        }
        else
        {
            return;
        }
    }

    void CreateEnemy()
    {
        Level = serializeObjects[Levelİndex];
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
