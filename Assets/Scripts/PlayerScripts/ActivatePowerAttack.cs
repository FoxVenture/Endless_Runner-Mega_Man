using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivatePowerAttack : MonoBehaviour
{
    public bool PowerAttackActive;
    public Renderer PowerAttackRender;

    void Start()
    {
        PowerAttackActive = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (PowerAttackActive && other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("in collision PA");
            Destroy(other.gameObject);
            PowerAttackActive = false;
            PowerAttackRender.enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (PowerAttackActive && other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("in collision PA");
            Destroy(other.gameObject);
            PowerAttackActive = false;
            PowerAttackRender.enabled = true;
        }
    }
}
