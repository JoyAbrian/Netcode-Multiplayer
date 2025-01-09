using Unity.Netcode;
using UnityEngine;

public class Movement : NetworkBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    [Header("Camera Settings")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float mouseSensitivity = 2f;

    private void Update()
    {
        if (!IsOwner)
        {
            playerCamera.enabled = false;
            playerCamera.GetComponent<AudioListener>().enabled = false;
            return;
        }

        PlayerMove();
        PlayerJump();
        CameraMovement();
    }

    void PlayerMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0, vertical).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.Self);
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void CameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        playerCamera.transform.Rotate(Vector3.left * mouseY * mouseSensitivity);
        transform.Rotate(Vector3.up * mouseX * mouseSensitivity);
    }
}