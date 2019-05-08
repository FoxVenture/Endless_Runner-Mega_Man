using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour
{
    public Animator animator;

    public void shootAnimation()
    {
        animator.SetTrigger("playerShoot");
    }

    public void jumpAnimation()
    {
        animator.SetTrigger("playerJump");
    }

    public void dieAnimation()
    {
        animator.SetTrigger("Die");
    }
}
