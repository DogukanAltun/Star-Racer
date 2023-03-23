using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    private int PlayerScore;
    private int EnemyScore;
    private GameManager sceneManager;
    private bool LevelCompleted;
    public bool levelCompleted { get { return LevelCompleted; } set { value = LevelCompleted; } }
    public int playerScore { get { return PlayerScore; } set { value = PlayerScore; } }
    public int enemyScore { get { return EnemyScore; } set { value = EnemyScore; } }
    public static PointManager instance;


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
        PlayerScore = PlayerPrefs.GetInt("PlayerScore", PlayerScore);
        EnemyScore = PlayerPrefs.GetInt("EnemyScore", EnemyScore);
    }

    public void IncreasePoint(Collider gameObject)
    {
        PlayerScore = PlayerPrefs.GetInt("PlayerScore", PlayerScore);
        PlayerPrefs.GetInt("EnemyScore", EnemyScore);
        Debug.Log(PlayerScore);
        if (gameObject.gameObject.tag == "Player")
        {
            PlayerScore += 500;
            PlayerPrefs.SetInt("PlayerScore", PlayerScore);
        }
        else
        {
            EnemyScore += 500;
            PlayerPrefs.SetInt("EnemyScore", EnemyScore);
        }
    }

    public void CalculatePoints()
    {
        PlayerScore = PlayerPrefs.GetInt("PlayerScore");
        EnemyScore = PlayerPrefs.GetInt("EnemyScore");
        if (PlayerScore > EnemyScore)
        {
            LevelCompleted = true;
        }
        else
        {
            LevelCompleted = false;
        }
    }
}
