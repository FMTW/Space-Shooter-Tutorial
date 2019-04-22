using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject[] hazzards;
    [SerializeField] private GameObject player;
    [SerializeField] private int hazzardCounter;
    [SerializeField] private float startDelay;
    [SerializeField] private float waveDelay;
    [SerializeField] private float spawnDelay;
    [SerializeField] private Vector3 spawnValue;
    [SerializeField] private Quaternion spawnRotation;
    [SerializeField] private int score;
    [SerializeField] private bool restart;
    [SerializeField] private bool gameover;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI restartText;
    [SerializeField] private TextMeshProUGUI gameoverText;

    private void Start()
    {
        gameover = false;
        restart = false;
        restartText.text = "";
        gameoverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWave());
    }

    private void Update()
    {
        if (restart)
        {
           if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            for (int i = 0; i < hazzardCounter; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), 0, spawnValue.z);
                spawnRotation = Quaternion.identity;
                Instantiate(hazzards[Random.Range(0,hazzards.Length)], spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnDelay);
            }
            
            yield return new WaitForSeconds(waveDelay);

            if (gameover)
            {
                restartText.SetText("Press 'R' to Restart");
                restart = true;
                break;
            }
        }
    }

    void UpdateScore()
    {
        scoreText.SetText("Score: {0}", score);
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }

    public void GameOver()
    {
        gameoverText.SetText("Game Over");
        gameover = true;
    }
}
