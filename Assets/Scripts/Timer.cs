using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    [SerializeField] GameObject timeBox;
    [SerializeField] int timeLeft = 30;
    [SerializeField] bool takingSecond = false;

    [SerializeField] AudioSource timeUpSFX;
    [SerializeField] GameObject levelBGM;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject timeUp;

    [SerializeField] GameObject playerControl;

    [SerializeField] bool isRespawning = false;

    void Update()
    {
        timeBox.GetComponent<TMPro.TMP_Text>().text = "Time Left: " + timeLeft;
        if (takingSecond == false) 
        {
            StartCoroutine(RemoveSecond());
        }
        if (timeLeft == 0 && isRespawning == false)
        {
            isRespawning = true;
            takingSecond = true;
            timeBox.GetComponent<TMPro.TMP_Text>().enabled = false;
            levelBGM.SetActive(false);
            timeUpSFX.Play();
            fadeOut.SetActive(true);
            timeUp.SetActive(true);
            playerControl.GetComponent<Player>().enabled = false;
            playerControl.GetComponent<Animator>().Play("Idle");
            StartCoroutine(Screen());
        }
    }

    IEnumerator RemoveSecond()
    {
        takingSecond = true;
        yield return new WaitForSeconds(1);
        timeLeft -= 1;
        takingSecond = false;
    }

    IEnumerator Screen()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(4);
    }
}
