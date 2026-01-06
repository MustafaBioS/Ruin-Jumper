using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    [SerializeField] AudioSource deathSFX;
    
    void OnTriggerEnter(Collider other)
    {
        Score.score = 0;
        deathSFX.Play();
        SceneManager.LoadScene(3);
        Debug.Log("Test");
    }
}
