using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    PlayerController playerController;
    Collider collider;

    [Tooltip("Time between player colliding with world and reloading the level")]
    [SerializeField] float crashTime = 1f;

    [Tooltip("Particle system for when player explodes")]
    [SerializeField] ParticleSystem explosionParticles;
    
    [SerializeField] MeshRenderer playerMeshRenderer;

    private void Start() {
        playerController = this.GetComponent<PlayerController>();
        collider = GetComponent<Collider>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        StartLoseSequence();
    }

    private void StartLoseSequence()
    {
        playerController.enabled = false;
        collider.enabled = false;
        explosionParticles.Play();
        playerMeshRenderer.enabled = false;
        Invoke("ReloadLevel", crashTime);
    }

    private void ReloadLevel()
    {
        playerController.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
