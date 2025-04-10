using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float distance = 5.0f;
    [SerializeField] private float sensitivityX = 5.0f;
    [SerializeField] private float sensitivityY = 3.0f;

    private float minY = 0f;
    private float maxY = 80f;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private bool _isPaused = false;

    private void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationY = angles.y;
        rotationX = angles.x;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        if (_isPaused)
            return;

        rotationY += Input.GetAxis("Mouse X") * sensitivityX;
        rotationX -= Input.GetAxis("Mouse Y") * sensitivityY;
        rotationX = Mathf.Clamp(rotationX, minY, maxY);

        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
        Vector3 position = target.position - (rotation * Vector3.forward * distance);

        transform.rotation = rotation;
        transform.position = position;
    }

    public void PauseCamera()
    {
        _isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UnpauseCamera()
    {
        _isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
