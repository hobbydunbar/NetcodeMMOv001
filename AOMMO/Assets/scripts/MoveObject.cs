using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float rspeed = 1f;
    public float tspeed = 1.0f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, 0, verticalInput) * tspeed * Time.deltaTime;
        transform.Rotate((Vector3.up * horizontalInput * Time.deltaTime)*(rspeed));
    }
}
