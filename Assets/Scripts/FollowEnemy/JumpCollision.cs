using UnityEngine;
using System.Collections;

public class JumpCollision : MonoBehaviour
{
    public EnemyAI enemyAI;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            enemyAI.setJump();
            Debug.Log("HEEFT GERAAKT");
        }
    }
}
