using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class MouvementPerso : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotationSpeed = 5f;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform barrelTransform;
    [SerializeField]
    private Transform bulletParent;
    [SerializeField]
    private float missDistance = 25f;
    [SerializeField]
    private float spread = 1f;

    private CharacterController controller;
    private PlayerInput input;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction shootAction;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();

        cameraTransform = Camera.main.transform;
        moveAction =  input.actions["Mouvement"];
        jumpAction = input.actions["Jump"];
        shootAction = input.actions["Shoot"];

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        shootAction.performed += _ => shootGun();
    }

    private void OnDisable()
    {
        shootAction.performed -= _ => shootGun();

    }

    private void shootGun()
    {

        RaycastHit hit;
        GameObject bullet = GameObject.Instantiate(bulletPrefab, barrelTransform.position, Quaternion.identity, bulletParent);
        BulletController bulletController = bullet.GetComponent<BulletController>();

        if(Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, Mathf.Infinity))
        {

            bulletController.target = hit.point;

            bulletController.hit = true;

        }
        else
        {

            bulletController.target = cameraTransform.position + cameraTransform.forward * missDistance;

            bulletController.hit = false;
        }
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 inputDirection = moveAction.ReadValue<Vector2>();

        Vector3 move = new Vector3(inputDirection.x, 0, inputDirection.y);
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized; 
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        float targetAngles = cameraTransform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, targetAngles, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}