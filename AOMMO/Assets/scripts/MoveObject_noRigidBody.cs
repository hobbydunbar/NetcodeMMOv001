using UnityEngine;

public class MoveObject_CharacterController : MonoBehaviour
{
    public float rspeedkeyboard = 100f;
    public float rspeedmouse = 1000f;
    public float tspeed = 10f;
    public float strafespeed = 10f;
    public float jumpForce = 10f;
    public float jumpSmoothing = 10f;
    private CharacterController characterController;
    private float verticalVelocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * verticalInput * tspeed * Time.deltaTime;

        if (Input.GetMouseButton(1))
        {
            float strafeInput = Input.GetAxis("Horizontal");
            movement += transform.right * strafeInput * strafespeed * Time.deltaTime;

            float mouseX = Input.GetAxis("Mouse X");
            transform.RotateAround(transform.position, transform.up, mouseX * rspeedmouse * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(transform.position, transform.up, horizontalInput * rspeedkeyboard * Time.deltaTime);
        }

        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
        }

        verticalVelocity += Physics.gravity.y * Time.deltaTime;
        movement.y = Mathf.SmoothDamp(movement.y, verticalVelocity, ref verticalVelocity, jumpSmoothing);

        characterController.Move(movement);
    }
}
