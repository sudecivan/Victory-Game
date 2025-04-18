using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    [SerializeField]
    private Text enemyKillCountTxt;
    private int enemyKillCount;
    public GameObject FinishScene;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void EnemyKilled()
    {
        enemyKillCount++;
        enemyKillCountTxt.text = "Enemy Killed:" + enemyKillCount;
        FinishGame();
    }
    private void FinishGame()
    {
        if (enemyKillCount == 3)
            FinishScene.SetActive(true);


    }
}
