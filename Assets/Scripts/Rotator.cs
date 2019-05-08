using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    void Awake()
    {
        transform.Rotate(45, 45, 45);
    }

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}