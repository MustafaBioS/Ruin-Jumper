using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField] AudioSource buttonPress;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject optionsPanel;

    public void StartGame()
    {
        buttonPress.Play();
        fadeOut.SetActive(true);
        StartCoroutine(PlayGame());  
    }

    public void OpenPanel()
    {
        buttonPress.Play();
        optionsPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        buttonPress.Play();
        optionsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        buttonPress.Play();
        Application.Quit();
    }

    IEnumerator PlayGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }
}
