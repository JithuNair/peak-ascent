using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float sprintSpeed = 4f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    public Transform cameraTransform;

    private CharacterController controller;
    public StaminaSystem stamina = new StaminaSystem();
    private Vector3 velocity;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        if (cameraTransform == null && Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(h, 0f, v);
        if (input.magnitude > 1f)
            input.Normalize();
        Vector3 move = Quaternion.Euler(0f, cameraTransform.eulerAngles.y, 0f) * input;

        bool wantsSprint = Input.GetKey(KeyCode.LeftShift) && stamina.HasStamina(Time.deltaTime * stamina.regenRate);
        float speed = wantsSprint ? sprintSpeed : walkSpeed;
        controller.Move(move * speed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && controller.isGrounded && stamina.HasStamina(10f))
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            stamina.Drain(10f);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (wantsSprint)
        {
            stamina.Drain(Time.deltaTime * 20f);
        }
        else
        {
            stamina.Regenerate(Time.deltaTime);
        }
    }
}
