using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public AudioClip GameOverAudio;
    public AudioClip ClickAudio;

    private AudioSource GameOverSource;
    private AudioSource ClickSource;

    void Start()
    {
        GameOverSource = GetComponent<AudioSource>();
        ClickSource = GetComponent<AudioSource>();

        GameOverSource.loop = true;
        GameOverSource.clip = GameOverAudio;
        GameOverSource.Play();
    }

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        ClickSource.PlayOneShot(ClickAudio, 1F);
    }
}
