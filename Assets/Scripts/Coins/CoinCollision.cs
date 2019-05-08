using UnityEngine;
using System.Collections;

public class CoinCollision : MonoBehaviour
{

    public AudioClip CoinSound;
    private AudioSource coinSource;
    Animator coinAnimation;
    public GameObject animator;
    public GameObject coin;

    void Start ()
    {
        coinSource = GetComponent<AudioSource>();
        coinAnimation = animator.GetComponent<Animator>();
    }
    
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            coinSource.PlayOneShot(CoinSound, 1F);
            coinAnimation.SetTrigger("PlayCoinAnimation");

            //Destroy(coin, 2f);
        }
    }
}
