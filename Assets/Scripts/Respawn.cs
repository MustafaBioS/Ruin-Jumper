using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Screen());
    }

    IEnumerator Screen()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }
}
