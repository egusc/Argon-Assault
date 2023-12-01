using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    PlayerController playerController;
    
    [Tooltip("Time between player colliding with world and reloading the level")]
    [SerializeField] float crashTime = 1f;

    private void Start() {
        playerController = this.GetComponent<PlayerController>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        StartLoseSequence();
    }

    private void StartLoseSequence()
    {
        playerController.enabled = false;
        Invoke("ReloadLevel", crashTime);
    }

    private void ReloadLevel()
    {
        playerController.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
