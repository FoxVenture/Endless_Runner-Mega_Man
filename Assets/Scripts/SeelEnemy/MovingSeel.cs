using UnityEngine;
using System.Collections;

public class MovingSeel : MonoBehaviour
{

    float delta = 8.0f;
    float speed = 1.0f;
    private Vector3 startPos;
    public GameObject movingEnemy;

    void Start()
    {
        startPos = transform.position;
    }

    void Awake()
    {
        movingEnemy.transform.position = new Vector3(0f, 0.5f, movingEnemy.transform.position.z);
    }

    void Update()
    {
        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }

    public IEnumerator MoveToPosition(Vector3 v)
    {
        var t = 0f;

        while (t < 1)
        {
            transform.position = v;
            yield return null;
        }
    }
}
