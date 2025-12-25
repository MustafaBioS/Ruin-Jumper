using System.Collections;
using UnityEngine;

public class CollapseFloor : MonoBehaviour
{
    public float collapseDelay = 0.5f;
    public float destroyAfter = 1f;

    private Rigidbody rb;
    private bool triggered = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();      
    }

    void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("Collided");
            triggered = true;
            StartCoroutine(Collapse());
        }
    }

    IEnumerator Collapse()
    {
        yield return new WaitForSeconds(collapseDelay);

        rb.isKinematic = false;
        rb.useGravity = true;

        Destroy(gameObject, destroyAfter);
        Debug.Log("Destroyed");
    }
}
