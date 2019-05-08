using UnityEngine;
using System.Collections;

public class FollowingEnemy : MonoBehaviour
{
    public PlayerController controller;
    public GameObject followEnemy;
    bool isActive;

    void Start()
    {

    }

    void Update()
    {
        if(controller.followDistance > 6f && isActive == true)
        {
            followEnemy.SetActive(false);
            isActive = false;
        }
        if(controller.followDistance < 5f && isActive == false)
        {
            followEnemy.SetActive(true);
            isActive = true;
        }
    }
}
