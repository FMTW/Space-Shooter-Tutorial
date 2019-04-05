using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject hazzard;
    [SerializeField] private GameObject player;
    [SerializeField] private int hazzardCounter;
    [SerializeField] private float startDelay;
    [SerializeField] private float waveDelay;
    [SerializeField] private float spawnDelay;
    [SerializeField] private Vector3 spawnValue;
    [SerializeField] private Quaternion spawnRotation;
    [SerializeField] private TextMesh scoreText;
    [SerializeField] private int score;

    private void Start()
    {
        StartCoroutine(SpawnWave());
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
                Instantiate(hazzard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnDelay);
            }

            yield return new WaitForSeconds(waveDelay);
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int newScore)
    {
        score = newScore;
    }

}
