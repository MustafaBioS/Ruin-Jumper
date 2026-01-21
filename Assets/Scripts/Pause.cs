using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] AudioSource buttonPress;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject overlay;
    [SerializeField] GameObject pauseMenu;
    
    public void ResumeGame()
    {
        buttonPress.Play();
        overlay.SetActive(false);
        pauseMenu.SetActive(false);
        Player.paused = false;
    }

    public void OpenOptions()
    {
        buttonPress.Play();
        optionsPanel.SetActive(true);
    }

    public void MainMenu()
    {
        buttonPress.Play();
        fadeOut.SetActive(true);
        StartCoroutine(Main());
    }

    public void ExitGame()
    {
        buttonPress.Play();
        Application.Quit();
    }

    public void ExitOptions()
    {
        buttonPress.Play();
        optionsPanel.SetActive(false);
    }

    IEnumerator Main()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
