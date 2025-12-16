using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CharacterController controller;
    [SerializeField] GameObject active;
    [SerializeField] Transform cam;

    [Header("Movement")]
    [SerializeField] float speed = 12.5f;
    [SerializeField] float sensitivity = 1000f;
    [SerializeField] float jumpHeight = 2.5f;
    [SerializeField] float gravity = -20f;
    Vector3 velocity;
    [SerializeField] bool grounded;
    [SerializeField] bool jumping;
    Animator animator;

    float RotateX = 0f;
    [SerializeField] float minPitch = -85f;
    [SerializeField] float maxPitch = 85f;

    [Header("Ground Check")]
    [SerializeField] LayerMask groundMask;
    [SerializeField] float checkRadiusMultiplier = 0.9f;
    [SerializeField] float debugSphereDuration = 0.02f;

    void Awake()
    {
        if (controller == null) controller = GetComponent<CharacterController>();
        if (active != null) animator = active.GetComponent<Animator>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        Vector3 worldCenter = transform.TransformPoint(controller.center);
        float halfHeight = controller.height * 0.5f;
        Vector3 feetPosition = worldCenter + Vector3.down * (halfHeight - controller.radius + 0.01f);

        float checkRadius = controller.radius * checkRadiusMultiplier;
        grounded = Physics.CheckSphere(feetPosition, checkRadius, groundMask);

        Debug.DrawRay(feetPosition, Vector3.up * 0.01f, grounded ? Color.green : Color.red, debugSphereDuration);

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.up * (mouseX * sensitivity * Time.deltaTime));
        if (cam != null)
        {
            RotateX -= mouseY * sensitivity * Time.deltaTime;
            RotateX = Mathf.Clamp(RotateX, minPitch, maxPitch);
            cam.localRotation = Quaternion.Euler(RotateX, 0f, 0f);
        }

        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * inputX + transform.forward * inputZ;
        move = move.normalized * speed;

        if (grounded && velocity.y < 0f)
        {
            move *= 0.5f;
            velocity.y = -2f;
            jumping = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && grounded)
        {
            jumping = true;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            StartCoroutine(ResetJump());
        }

        velocity.y += gravity * Time.deltaTime;

        Vector3 total = move + Vector3.up * velocity.y;
        controller.Move(total * Time.deltaTime);

        if (!jumping && animator != null)
        {
            if (Mathf.Abs(inputX) > 0.01f || Mathf.Abs(inputZ) > 0.01f)
                animator.Play("Standard Run");
            else
                animator.Play("Idle");
        }
    }

    IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(0.9f);
        jumping = false;
    }

    void OnDrawGizmosSelected()
    {
        if (controller == null) return;
        Vector3 worldCenter = transform.TransformPoint(controller.center);
        float halfHeight = controller.height * 0.5f;
        Vector3 feetPosition = worldCenter + Vector3.down * (halfHeight - controller.radius + 0.01f);
        Gizmos.color = grounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(feetPosition, controller.radius * checkRadiusMultiplier);
    }
}
