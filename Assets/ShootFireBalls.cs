using UnityEngine;
using System.Collections;

public class ShootFireBalls : MonoBehaviour
{
    public GameObject fireBallPrefab;

    public GameObject fireBallSpawn1;
    public GameObject fireBallSpawn2;
    public GameObject fireBallSpawn3;
    public GameObject fireBallSpawn4;
    public GameObject fireBallSpawn5;
    public GameObject fireBallSpawn6;
    public GameObject fireBallSpawn7;
    public GameObject fireBallSpawn8;

    GameObject[] spawnPoints;

    bool stillShooting;

    void Start()
    {
        spawnPoints = new GameObject[8] { fireBallSpawn1, fireBallSpawn2, fireBallSpawn3, fireBallSpawn4, fireBallSpawn5, fireBallSpawn6, fireBallSpawn7, fireBallSpawn8 };
        stillShooting = false;
    }

    void FixedUpdate()
    {
        if (!stillShooting)
        {
            stillShooting = true;
            StartCoroutine(waitForFireBalls());
        }
    }

    public void startShootingFireballs()
    {
        var newFireball = (GameObject)Instantiate(fireBallPrefab, spawnPoints[0].transform.position, spawnPoints[0].transform.rotation);
        
        StartCoroutine(waitBeforeNextBall());
        
    }

    public IEnumerator waitForFireBalls()
    {
        yield return new WaitForSeconds(3.8f);
        startShootingFireballs();
    }

    public IEnumerator waitBeforeNextBall()
    {
        for (int i = 1; i < 8; i++)
        {
            yield return new WaitForSeconds(0.9f);
            var newFireball = (GameObject)Instantiate(fireBallPrefab, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
        }

        stillShooting = false;
    }
}
