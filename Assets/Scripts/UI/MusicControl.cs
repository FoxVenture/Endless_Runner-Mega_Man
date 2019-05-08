using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour
{

    public AudioClip MenuMusic;
    public AudioClip GameOverMusic;
    public AudioClip GamePlayMusic;

    private AudioSource MenuSource;
    private AudioSource GameOverSource;
    private AudioSource GamePlaySource;

    void Start ()
    {
        MenuSource = GetComponent<AudioSource>();
        GameOverSource = GetComponent<AudioSource>();
        GamePlaySource = GetComponent<AudioSource>();
    }
	
	public void PlayGameOver()
    {
        GamePlaySource.Stop();
        MenuSource.Stop();
        GameOverSource.Play();
    }

    public void PlayGameMusic()
    {
        GameOverSource.Stop();
        GamePlaySource.Play();
    }
}
