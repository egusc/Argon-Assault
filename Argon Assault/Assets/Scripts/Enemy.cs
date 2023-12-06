using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyExplosion;
    GameObject parent;
    [SerializeField] int scoreValue = 15;
    [SerializeField] int hp = 4;

    ScoreBoard scoreBoard;
    
    private void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>();

        if(parent == null)
        {
           parent = GameObject.FindWithTag("SpawnAtRuntime");
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        
        if(hp <= 0)
        {
            KillEnemy();
        }
        
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(enemyExplosion, this.transform.position, Quaternion.identity);
        vfx.transform.parent = parent.transform;
        Destroy(this.gameObject);
    }

    private void ProcessHit()
    {
        scoreBoard.IncreaseScore(scoreValue);
        hp -= 1;
    }
}
