using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public TextMeshProUGUI timerUI;
    float elapsedTime;
    bool gameIsOver;

    float spawnCounter;
    float spawnRate;

    public GameObject enemy;
    GameObject[] spawns;

    private void Update()
    {
        if (gameIsOver)
            return;

        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        spawnCounter -= Time.deltaTime;
        if(spawnCounter < 0)
        {
            spawnCounter = spawnRate;
            spawnEnemy();
        }

        if (minutes == 1)
        {
            spawnRate = 6;
        }

        if(minutes == 2)
        {
            spawnRate = 5;
        }

        if(minutes == 4)
        {
            spawnRate = 4;
        }

        if (minutes == 5)
        {
            spawnRate = 3;
        }

        timerUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void spawnEnemy()
    {
        int spwnLocation = UnityEngine.Random.Range(0, spawns.Length);
        Instantiate(enemy, spawns[spwnLocation].transform.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 7f;
        gameOverScreen.SetActive(false);
        gameIsOver = false;

        spawns = GameObject.FindGameObjectsWithTag("Spawn");
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        gameIsOver = true;
    }

    public void resetScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
