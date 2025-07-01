using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private const float MIN_FOLLOW_Y_OFFSET = 2f;
    private const float MAX_FOLLOW_Y_OFFSET = 12f;

    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    private CinemachineTransposer cinemachineTransposer;
    private Vector3 targetFollowOffset;

    private Vector3 lastMousePosition;
    private bool isPanning = false;
    private bool isRotating = false;

    private void Start()
    {
        cinemachineTransposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        targetFollowOffset = cinemachineTransposer.m_FollowOffset;
    }

    private void Update()
    {
        HandleMousePan();
        HandleMouseRotate();
        HandleZoom();
    }

    private void HandleMousePan()
    {
        // Right mouse button for panning
        if (Input.GetMouseButtonDown(1))
        {
            isPanning = true;
            lastMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isPanning = false;
        }

        if (isPanning)
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            float panSpeed = 0.1f;

            // Move in local XZ plane
            Vector3 move = (-transform.right * delta.x + -transform.forward * delta.y) * panSpeed;
            move.y = 0; // Keep camera level
            transform.position += move;

            lastMousePosition = Input.mousePosition;
        }
    }

    private void HandleMouseRotate()
    {
        // Middle mouse button for rotation (optional)
        if (Input.GetMouseButtonDown(2))
        {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(2))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            float rotationSpeed = 0.3f;
            transform.eulerAngles += new Vector3(0, delta.x * rotationSpeed, 0);
            lastMousePosition = Input.mousePosition;
        }
    }

    private void HandleZoom()
    {
        float zoomIncreaseAmount = 1f;
        float scroll = Input.mouseScrollDelta.y;
        targetFollowOffset.y -= scroll * zoomIncreaseAmount; // Invert for natural feel

        targetFollowOffset.y = Mathf.Clamp(targetFollowOffset.y, MIN_FOLLOW_Y_OFFSET, MAX_FOLLOW_Y_OFFSET);

        float zoomSpeed = 5f;
        cinemachineTransposer.m_FollowOffset =
            Vector3.Lerp(cinemachineTransposer.m_FollowOffset, targetFollowOffset, Time.deltaTime * zoomSpeed);
    }
}