using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

    bool jump = false;
    public Rigidbody rb;
    //float reach = 2.0f;
    //RaycastHit hit;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        /*
        Vector3 vec = new Vector3(transform.position.x, transform.position.y - 0.7f, transform.position.z);
        Vector3 fwd = rb.transform.TransformDirection(Vector3.forward);
        
        Debug.DrawRay(vec, fwd * reach, Color.red);
        
        if (Physics.Raycast(vec, fwd, reach))
        {
            if (hit.transform.CompareTag("Obstacle"))
            {
                Debug.Log(hit.collider.gameObject.name);
                rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
                //jump = true;
            }
         }
         */

        if (jump)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            jump = false;
        }

    }

    public void setJump()
    {
        jump = true;
    }
}
