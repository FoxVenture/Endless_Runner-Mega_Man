using UnityEngine;
using System.Collections;

public class CoinMagnet : MonoBehaviour
{
    Rigidbody coinBody;
    public bool inside { get; set; }
    Transform magnet;
    float force = 13f;

    void Start()
    {
        magnet = GameObject.Find("Player").GetComponent<Transform>();
        inside = false;
        coinBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (inside)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, magnet.position, Time.deltaTime * force);
            coinBody.transform.position = Vector3.MoveTowards(transform.position, magnet.position, Time.deltaTime * force);
        }
    }
   
}