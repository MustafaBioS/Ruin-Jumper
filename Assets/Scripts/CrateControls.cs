using UnityEngine;

public class CrateControls : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 0.5f;
    [SerializeField] AudioSource crateCollect;
    [SerializeField] int crateScore = 100;

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        crateCollect.Play();
        Destroy(gameObject);    
        Score.score += crateScore;
    }
}
