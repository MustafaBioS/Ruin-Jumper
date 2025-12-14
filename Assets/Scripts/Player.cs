using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CharacterController controller;
    [SerializeField] GameObject active;

    [Header("Movement")]
    [SerializeField] float speed = 6.5f;
    [SerializeField] float sensitivity = 1000;
    [SerializeField] float jumpHeight = 1.2f;
    [SerializeField] float gravity = -20f;
    Vector3 velocity;
    bool grounded;
    bool jumping;
    Animator animator;

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

        grounded = controller.isGrounded;

        if (grounded && velocity.y < 0f)
        {
            velocity.y = 0f;
            jumping = false;
        }

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * sensitivity * Time.deltaTime, 0f);

        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * inputX + transform.forward * inputZ;
        move *= speed;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jumping = true;
            if (animator != null) animator.Play("Jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        Vector3 total = move + Vector3.up * velocity.y;
        controller.Move(total * Time.deltaTime);

        if (!jumping && animator != null)
        {
            if (Mathf.Abs(inputX) > 0.01f || Mathf.Abs(inputZ) > 0.01f)
            {
                animator.Play("Standard Run");
            }
            else
            {
                animator.Play("Idle");
            }
        }
    }
}
