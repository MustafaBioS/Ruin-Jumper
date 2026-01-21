using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCrate : MonoBehaviour
{
    [SerializeField] GameObject playerControl;
    [SerializeField] AudioSource levelSFX;
    [SerializeField] GameObject levelBGM;
    [SerializeField] GameObject fadeOut;
    
    public float collapseDelay = 0.5f;
    public float destroyAfter = 1f;

    public Rigidbody rb;
    private bool triggered = false;
    
    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(Collapse());
        }

        playerControl.GetComponent<Player>().enabled = false;
        playerControl.GetComponent<Animator>().Play("Idle");
        levelBGM.SetActive(false);
        levelSFX.Play();
        fadeOut.SetActive(true);
        SceneManager.LoadScene(3);
    }

    IEnumerator Collapse()
    {
        yield return new WaitForSeconds(collapseDelay);

        rb.isKinematic = false;
        rb.useGravity = true;

        Destroy(gameObject, destroyAfter);
    }
}
