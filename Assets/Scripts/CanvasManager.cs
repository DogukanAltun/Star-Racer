using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CanvasManager : MonoBehaviour
{
    private LevelManager levelManager;
    private PointManager pointManager;
    [SerializeField] private Slider Playerslider;
    [SerializeField] private Slider Enemyslider;
    [SerializeField] private TextMeshProUGUI currentLevelText;
    [SerializeField] private TextMeshProUGUI PlayerScore;
    [SerializeField] private TextMeshProUGUI EnemyScore;
    public static CanvasManager instance;


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

    private void Start()
    {
        Playerslider.value = PlayerPrefs.GetFloat("PlayerSlider");
        Enemyslider.value = PlayerPrefs.GetFloat("EnemySlider");
        levelManager = GameObject.FindObjectOfType(typeof(LevelManager)) as LevelManager;
        pointManager = GameObject.FindObjectOfType(typeof(PointManager)) as PointManager;
        StartCoroutine(UpdateBar());
    }

    private void Update()
    {
        currentLevelText.text = "Level: " + levelManager.level›ndex.ToString();
        PlayerScore.text = " Player : " + pointManager.playerScore;
        EnemyScore.text = " Enemy : " + pointManager.enemyScore;
    }

    public IEnumerator UpdateBar()
    {
        float NewPlayerValue = PointManager.instance.playerScore;
        float NewEnemyValue = PointManager.instance.enemyScore;
        if (Playerslider.value != NewPlayerValue)
        {
            for (float i = Playerslider.value; i < NewPlayerValue; i += 50)
            {
                Playerslider.value += 50;
                yield return new WaitForSeconds(0.1f);
            }
            PlayerPrefs.SetFloat("PlayerSlider", Playerslider.value);
        }
        else if (Enemyslider.value != NewEnemyValue)
        {
            for (float i = Enemyslider.value; i < NewEnemyValue; i += 50)
            {
                Enemyslider.value += 50;
                yield return new WaitForSeconds(0.1f);
            }
            PlayerPrefs.SetFloat("EnemySlider", Enemyslider.value);
        }
    }
}
