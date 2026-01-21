using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField] AudioSource buttonPress;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject optionsPanel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        buttonPress.Play();
        fadeOut.SetActive(true);
        StartCoroutine(PlayGame());  
    }

    public void OpenPanel()
    {
        optionsPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        optionsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator PlayGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }
}
