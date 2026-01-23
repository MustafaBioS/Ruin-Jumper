using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishCrate : MonoBehaviour
{
    [SerializeField] GameObject playerControl;
    [SerializeField] AudioSource levelSFX;
    [SerializeField] GameObject levelBGM;
    [SerializeField] GameObject winScreen;

    private bool triggered = false;
    
    void OnTriggerEnter(Collider other)
    {

        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            playerControl.GetComponent<Player>().enabled = false;
            playerControl.GetComponent<Animator>().Play("Idle");
            levelBGM.SetActive(false);
            levelSFX.Play();
            winScreen.SetActive(true);
            StartCoroutine(Anim());
        }
    }

    IEnumerator Anim()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(0);
    }
}
