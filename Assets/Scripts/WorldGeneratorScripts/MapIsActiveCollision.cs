using UnityEngine;
using System.Collections;

public class MapIsActiveCollision : MonoBehaviour
{
    public MapConnections connection;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            connection.isActive = true;
        }
    }
}