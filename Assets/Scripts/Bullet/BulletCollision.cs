using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour
{
    PlayerStats PS;

    void Start()
    {
        GameObject go = GameObject.Find("Player");
        PS = (PlayerStats)go.GetComponent(typeof(PlayerStats));
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            PS.killedEnemy();
            Destroy(this);
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            PS.destroyedObstacle();
            Destroy(this);
        }
    }


}
