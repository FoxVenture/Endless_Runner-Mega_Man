using UnityEngine;
using System.Collections;

public class BulletRotator : MonoBehaviour {

    void Update()
    {
        transform.Rotate(new Vector3(90, 10, 70) * (Time.deltaTime * 5));
    }
}
