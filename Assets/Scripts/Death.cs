using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    [SerializeField] AudioSource deathSFX;
    [SerializeField] GameObject levelBGM;
    [SerializeField] GameObject fadeOut;
    
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        levelBGM.SetActive(false);
        deathSFX.Play();
        fadeOut.SetActive(true);
        StartCoroutine(Respawn());
        
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1);
        Score.score = 0;
        SceneManager.LoadScene(3);
    }
}
