using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rigidBody;
    [SerializeField] private Camera _camera;

    private void Awake() {
        _rigidBody = GetComponent<Rigidbody>();
        HideAndLockCursor();
    }

    private void HideAndLockCursor() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 horizontalDirection = horizontal * _camera.transform.right;
        Vector3 verticalDirection = vertical * _camera.transform.forward;
        verticalDirection.y = 0;
        horizontalDirection.y = 0;

        Vector3 movementDirection = horizontalDirection + verticalDirection;

        _rigidBody.velocity = movementDirection * _speed * Time.fixedDeltaTime;
    }
}
