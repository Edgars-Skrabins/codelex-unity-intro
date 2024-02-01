using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera m_camera;
    [SerializeField] private float m_playerSpeed;
    [SerializeField] private Rigidbody m_playerRB;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementZ = Input.GetAxisRaw("Vertical");
        Vector3 localMovement = new Vector3(movementX, 0, movementZ);
        // Vector3 worldMovement = transform.TransformDirection(localMovement).normalized;

        m_playerRB.velocity = localMovement * m_playerSpeed;
    }

    private void HandleRotation()
    {
        Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit _hit))
        {
            // Vector3 hitPosition = _hit.point;
            // float rotationAngle = Mathf.Atan2(hitPosition.x, hitPosition.z) * Mathf.Rad2Deg;
            // Quaternion rotation = Quaternion.Euler(0f, rotationAngle, 0f);
            // m_playerRB.rotation = rotation;

            Vector3 hitPosition = _hit.point;
            Vector3 lookPosition = new Vector3(hitPosition.x, transform.position.y, hitPosition.z);
            transform.LookAt(lookPosition);
        }
    }
}
