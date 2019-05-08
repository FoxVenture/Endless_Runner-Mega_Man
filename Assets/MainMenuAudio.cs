using UnityEngine;
using System.Collections;

public class MainMenuAudio : MonoBehaviour
{
    public AudioClip MenuMusicAudio;
    public AudioClip ClickAudio;

    private AudioSource MenuMusicSource;
    private AudioSource ClickSource;

    void Start()
    {
        MenuMusicSource = GetComponent<AudioSource>();
        ClickSource = GetComponent<AudioSource>();

        MenuMusicSource.loop = true;
        MenuMusicSource.clip = MenuMusicAudio;
        MenuMusicSource.Play();
    }

    public void LoadByIndex(int sceneIndex)
    {
        StartCoroutine(FadeOut(MenuMusicSource, 2f));
    }

    public void playClickAudio()
    {
        ClickSource.PlayOneShot(ClickAudio, 1F);
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}