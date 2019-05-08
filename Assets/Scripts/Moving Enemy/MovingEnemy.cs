using UnityEngine;
using System.Collections;

public class MovingEnemy : MonoBehaviour
{

    float delta = 8.0f;
    float speed = 2.0f;
    private Vector3 startPos;
    public GameObject movingEnemy;

    void Start()
    {
        startPos = transform.position;
    }

    void Awake()
    {
        movingEnemy.transform.position = new Vector3(0f, 1f, movingEnemy.transform.position.z);
    }

    void Update()
    {
        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
