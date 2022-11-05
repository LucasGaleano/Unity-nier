using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private InputController inputController;
    public Canvas playerCanvas;
    private TextMeshProUGUI playerLifeText;
    public Vector3 location;
    public Vector3 rotation;
    private CharacterController characterController;
    public float speed = 15f;
    public float rotationSmooth;
    public float fireRate;
    private float nextFireAllow;
    private Life life;
    private PlayerInput Input;
    [SerializeField] GameObject shoot;
    [SerializeField] GameObject firepoint;

    // Update is called once per frame

    private void Start()
    {
        Input = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();
        MapInput();
        life = GetComponent<Life>();
        playerLifeText = GameObject.Find("Player Life Text").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {

        characterController.Move(location * speed * Time.deltaTime);

        if(Gamepad.current.rightShoulder.ReadValue() > 0f && Time.time > nextFireAllow)
        {
            nextFireAllow = Time.time + fireRate;
            Instantiate(shoot, firepoint.transform.position, firepoint.transform.rotation);
        }

        UpdateText();

    }

    void UpdateText()
    {
        playerCanvas.transform.position = transform.position;
        playerLifeText.SetText("Life: " + life.points);
    }

    private void MapInput()
    {
        inputController.Player.Move.performed += Move;
        inputController.Player.Move.canceled += context =>
        {
            location = Vector3.zero;
        };

        inputController.Player.Look.performed += Look;
        inputController.Player.Look.canceled += context =>
        {
            rotation = Vector3.zero;
        };
    }

    private void Look(InputAction.CallbackContext context)
    {
        Vector2 rotationInput = context.ReadValue<Vector2>();
        rotation = new Vector3(rotationInput.x, 0, rotationInput.y);
        transform.rotation = SetRotationFromStick(rotation);
    }

    private void Move(InputAction.CallbackContext context)
    {
        Vector2 locationInput = context.ReadValue<Vector2>();
        location = new Vector3(locationInput.x, 0, locationInput.y);
        if (rotation == Vector3.zero)
        {
            transform.rotation = SetRotationFromStick(location);
        }
    }

    private Quaternion SetRotationFromStick(Vector3 rotation)
    {
        if (rotation == Vector3.zero)
        {
            return Quaternion.identity;
        }
        Quaternion orientationTo = Quaternion.LookRotation(rotation);
        return Quaternion.Lerp(transform.rotation, orientationTo, rotationSmooth * Time.deltaTime);
    }

    private void Awake()
    {
        inputController = new InputController();
    }

    private void OnEnable()
    {
        inputController.Enable();
    }

    private void OnDisable()
    {
        inputController.Disable();
        Input.enabled = false;
        Input.actions = null;
    }
}
