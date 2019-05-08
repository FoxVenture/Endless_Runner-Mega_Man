using UnityEngine;
using System.Collections;

public class MagnetCollision : MonoBehaviour
{

    Rigidbody coinBody;
    bool inside;
    Transform magnet;
    float force = 3f;

    void Start()
    {
        magnet = GameObject.Find("Player").GetComponent<Transform>();
        inside = false;
        coinBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inside)
        {
            transform.position = Vector3.MoveTowards(transform.position, magnet.position, Time.deltaTime * force);
            coinBody.transform.position = Vector3.MoveTowards(transform.position, magnet.position, Time.deltaTime * force);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inside = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inside = false;
        }
    }
}
