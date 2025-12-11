using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 0.5f;
    [SerializeField] AudioSource gemCollect;

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        gemCollect.Play();
        Destroy(gameObject);
    }
}
