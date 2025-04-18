using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject[] enemies;

    private void Start()
    {
        gameOverScreen.SetActive(false);
    }

    private void Update()
    {
        CheckEnemies();
    }

    private void CheckEnemies()
    {
        bool allEnemiesDefeated = true;

        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf)
            {
                allEnemiesDefeated = false;
                break;
            }
        }

        if (allEnemiesDefeated)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}






