using UnityEngine;

public class WinCrate : MonoBehaviour
{
    [SerializeField] GameObject playerControl;
    [SerializeField] AudioSource levelSFX;
    [SerializeField] GameObject levelBGM;
    [SerializeField] GameObject fadeOut;
    
    
    void OnTriggerEnter(Collider other)
    {
        playerControl.GetComponent<Player>().enabled = false;
        playerControl.GetComponent<Animator>().Play("Idle");
        levelBGM.SetActive(false);
        levelSFX.Play();
        fadeOut.SetActive(true);
    }
}
