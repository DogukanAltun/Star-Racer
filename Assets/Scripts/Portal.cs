using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private LevelManager levelManager;
    private PointManager pointManager;
    private int levelstage;
    private int wait = 1;
    [SerializeField] private Animator transition;
    public static Portal instance;


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
        levelstage = PlayerPrefs.GetInt("levelStage", 0);
    }

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType(typeof(LevelManager)) as LevelManager;
        pointManager = GameObject.FindObjectOfType(typeof(PointManager)) as PointManager;

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Portala Girdi");
        levelstage = PlayerPrefs.GetInt("levelStage", levelstage);
        PointManager.instance.IncreasePoint(other);
        StartCoroutine(Transition());
    }

    public IEnumerator Transition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(wait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        levelstage = PlayerPrefs.GetInt("levelStage", levelstage);
        levelstage++;
        PlayerPrefs.SetInt("levelStage", levelstage);
        int Index = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        int NextSceneIndex = Random.Range(0, Index);
        if (levelstage == 3)
        {
            PointManager.instance.CalculatePoints();
            if (pointManager.levelCompleted == true)
            {
                GameFinished();
            }
            else
            {
                TryAgain();
            }
        }
        else
        {
            Debug.Log(levelstage);
            UnityEngine.SceneManagement.SceneManager.LoadScene(NextSceneIndex);
        }
    }
    public void GameFinished()
    {
        PlayerPrefs.SetFloat("PlayerSlider", 0);
        PlayerPrefs.SetFloat("EnemySlider", 0);
        int Index = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        int NextSceneIndex = Random.Range(0, Index);
        Debug.Log("Congrats!");
        PlayerPrefs.SetInt("levelStage", 0);
        PlayerPrefs.SetInt("PlayerScore", 0);
        PlayerPrefs.SetInt("EnemyScore", 0);
        levelManager.NextLevel(true);
        UnityEngine.SceneManagement.SceneManager.LoadScene(NextSceneIndex);
    }
    public void TryAgain()
    {
        PlayerPrefs.SetFloat("PlayerSlider", 0);
        PlayerPrefs.SetFloat("EnemySlider", 0);
        int Index = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        int NextSceneIndex = Random.Range(0, Index);
        Debug.Log("Try Again!");
        PlayerPrefs.SetInt("levelStage", 0);
        PlayerPrefs.SetInt("PlayerScore", 0);
        PlayerPrefs.SetInt("EnemyScore", 0);
        UnityEngine.SceneManagement.SceneManager.LoadScene(NextSceneIndex);
    }
}
