using UnityEngine;
using System.Collections;

public class FireBallCollision : MonoBehaviour
{
    public GameObject fireBall;
    public AudioClip FireBallAudio;
    private AudioSource FireBallSource;

    void Start()
    {
        FireBallSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            FireBallSource.PlayOneShot(FireBallAudio, 1F);
            Destroy(fireBall, 1f);
        }
    }
}
