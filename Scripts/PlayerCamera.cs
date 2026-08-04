using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

public Transform Player;
public Transform CameraPivot;

public float Sensitivity = 1000f;

float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        xRotation += mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        CameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        Player.Rotate(Vector3.up * mouseX);

        Quaternion target = Quaternion.Euler(Mathf.Clamp(xRotation, -60f, 60f), 0f, 0f);
    }
}
