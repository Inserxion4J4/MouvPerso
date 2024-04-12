using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchCam : MonoBehaviour
{
    [SerializeField]
    private PlayerInput input;
    [SerializeField]
    private int priorityBoost = 10;
    [SerializeField]
    private Canvas ThirdPersonCanvas;
    [SerializeField]
    private Canvas AimCanvas;

    private InputAction aimAction;

    private CinemachineVirtualCamera virtualCamera;
   

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = input.actions["Aim"];
    }

    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }

    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }

    private void StartAim()
    {
        virtualCamera.Priority += priorityBoost;
        AimCanvas.enabled = true;
        ThirdPersonCanvas.enabled = false;
    }

    private void CancelAim()
    {
        virtualCamera.Priority -= priorityBoost;
        AimCanvas.enabled = false;
        ThirdPersonCanvas.enabled = true;
    }
}
