using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    PlayerController playerController;

    private void Start() {
        playerController = this.GetComponent<PlayerController>();
    }
    
    private void OnCollisionEnter(Collision other) {
        playerController.enabled = false;
        Invoke("ReloadLevel", 1);

    }
    private void OnTriggerEnter(Collider other) {
        playerController.enabled = false;
        Invoke("ReloadLevel", 1);
    }

    private void ReloadLevel()
    {
        playerController.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
