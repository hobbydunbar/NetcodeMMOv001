using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float rspeed = 100f;
    public float tspeed = 10f;
    public float jumpSpeed = 10f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * tspeed * Time.deltaTime, Space.Self);
        transform.RotateAround(transform.position, transform.up, horizontalInput * rspeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpSpeed;
        }
    }
}
