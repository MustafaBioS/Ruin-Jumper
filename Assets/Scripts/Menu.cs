using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField] AudioSource buttonPress;
    [SerializeField] GameObject fadeOut;

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

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator PlayGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(4);
    }
}
