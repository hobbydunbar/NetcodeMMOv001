using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Transform target;
    public float speed = 10f;
    public float zoomSpeed = 10f;
    public float distance = 5f;
    public float rotateSpeed = 100f;

    void LateUpdate()
{
    float scroll = Input.GetAxis("Mouse ScrollWheel");
    distance -= scroll * zoomSpeed;
    distance = Mathf.Clamp(distance, -5f, 50f);

    if (Input.GetMouseButton(0))
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        float h = rotateSpeed * Input.GetAxis("Mouse X");
        float v = rotateSpeed * Input.GetAxis("Mouse Y");

        transform.RotateAround(target.position, transform.up, h * Time.deltaTime);
        transform.RotateAround(target.position, transform.right, -v * Time.deltaTime);
    }
    else if (Input.GetMouseButton(1))
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    else
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    transform.position = target.position - transform.forward * distance;
    transform.LookAt(target);
}

}
