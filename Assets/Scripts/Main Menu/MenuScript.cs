using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject ControlMenu;
    public GameObject MainMenu;

    public MainMenuAudio menuAudio;

    void Start()
    {
        ControlMenu.SetActive(false);
    }

    public void LoadByIndex(int sceneIndex)
    {

        SceneManager.LoadScene(sceneIndex);
        menuAudio.playClickAudio();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ControlsMenu()
    {
        Debug.Log("controls clicked");
        MainMenu.SetActive(false);
        ControlMenu.SetActive(true);
        menuAudio.playClickAudio();
    }

    public void BackToMainMenu()
    {
        MainMenu.SetActive(true);
        ControlMenu.SetActive(false);
        menuAudio.playClickAudio();
    }
}
