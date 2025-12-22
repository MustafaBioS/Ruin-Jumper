using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject scoreBox;
    public static int score = 0;

    void Update()
    {
        scoreBox.GetComponent<TMPro.TMP_Text>().text = "Score: " + score;    
    }
}
