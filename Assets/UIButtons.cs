using UnityEngine;
using System.Collections;

public class UIButtons : MonoBehaviour
{
    public Animator animator;
    public GameObject pauseButton, pausePanel;

    public void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
