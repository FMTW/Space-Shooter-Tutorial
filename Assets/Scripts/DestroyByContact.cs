using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gameController;
    [SerializeField] private int scoreValue = 10;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        if (gameController == null)
            Debug.Log("Cannot find 'GameController' in the scene.");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary") { return; }

        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);

        gameController.AddScore(scoreValue);
    }
}
