using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip GameStartMusic;
    public AudioClip CoinSound;
    public AudioClip ShootSound;
    public AudioClip levelUpSound;
    public AudioClip JumpSound;
    public AudioClip DuckSound;
    public AudioClip GotHitSound;
    public AudioClip WalkingSound;
    public AudioClip PoweredUpSound;
    public AudioClip SpecialAttackSound;
    public AudioClip FallingSound;
    public AudioClip AllrightStartSound;
    public AudioClip ObstacleHitSound;

    private AudioSource ObstacleHitSource;
    private AudioSource AllrightStartSource;
    private AudioSource FallingSource;
    private AudioSource GameStartSource;
    private AudioSource shootSource;
    private AudioSource coinSource;
    private AudioSource levelUpSource;
    private AudioSource JumpSource;
    private AudioSource DuckSource;
    private AudioSource GotHitSource;
    private AudioSource WalkingSource;
    private AudioSource PoweredUpSource;
    private AudioSource SpecialAttackSource;


    void Start ()
    {
        ObstacleHitSource = GetComponent<AudioSource>();
        AllrightStartSource = GetComponent<AudioSource>();
        FallingSource = GetComponent<AudioSource>();
        GameStartSource = GetComponent<AudioSource>();
        coinSource = GetComponent<AudioSource>();
        shootSource = GetComponent<AudioSource>();
        levelUpSource = GetComponent<AudioSource>();
        JumpSource = GetComponent<AudioSource>();
        DuckSource = GetComponent<AudioSource>();
        GotHitSource = GetComponent<AudioSource>();
        WalkingSource = GetComponent<AudioSource>();
        PoweredUpSource = GetComponent<AudioSource>();
        SpecialAttackSource = GetComponent<AudioSource>();

        GameStartSource.Play();
    }
	
	public void PlayShootingSound()
    {
        shootSource.PlayOneShot(ShootSound, 1F);
    }

    public void PlayCoinSound()
    {
        coinSource.PlayOneShot(CoinSound, 1F);
    }

    public void LevelUpSound()
    {
        levelUpSource.PlayOneShot(levelUpSound, 1F);
    }

    public void PlayJumpSound()
    {
        JumpSource.PlayOneShot(JumpSound, 1F);
    }

    public void PlayDuckSound()
    {
        DuckSource.PlayOneShot(DuckSound, 1F);
    }

    public void PlayGotHitSound()
    {
        GotHitSource.PlayOneShot(GotHitSound, 1F);
    }

    public void PlayObstacleSound()
    {
        ObstacleHitSource.PlayOneShot(ObstacleHitSound, 1F);
    }
    
    public void PlayFallingSound()
    {
        FallingSource.PlayOneShot(FallingSound, 1F);
    }

    public void PlayWalkingSound()
    {
        WalkingSource.loop = true;
        WalkingSource.clip = WalkingSound;
        WalkingSource.Play();
    }

    public void StopWalkingSound()
    {
        WalkingSource.Stop();
        WalkingSource.loop = false;
    }

    public void PlayPoweredUpSound()
    {
        PoweredUpSource.PlayOneShot(PoweredUpSound);
    }

    public void PlaySpecialAttackSound()
    {
        SpecialAttackSource.PlayOneShot(SpecialAttackSound, 1F);
    }


}
