using UnityEngine;

public class DoctorController1 : MonoBehaviour
{
    public CharacterController controller;

    public float moveSpeed = 5.0f;
    public float turnSpeed = 150.0f; // Degrees per second
    public float gravity = -9.81f;

    private Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        // 1. Get Input
        // Vertical = W/S or Up/Down arrows
        // Horizontal = A/D or Left/Right arrows
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        // 2. Handle Rotation (Left/Right arrows)
        transform.Rotate(0, turnInput * turnSpeed * Time.deltaTime, 0);

        // 3. Handle Forward Movement (Up/Down arrows)
        // transform.forward ensures he moves where he is facing
        Vector3 move = transform.forward * moveInput;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // 4. Apply Gravity
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
