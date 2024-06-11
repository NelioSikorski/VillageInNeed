using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class InputManager : MonoBehaviour
{
    private PlayerControls _playerControls;
    private AnimatorManager _animatorManager;
    private PlayerLocomotion _playerLocomotion;
    private PlayerManager _playerManager;
    public GameManager gameManager;


    public Vector2 movementInput;
    public Vector2 menuInput;
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float verticalInput;
    public float horizontalInput;
    public float moveAmount;

    public bool b_Input;
    public bool a_Input;
    public bool y_Input;

    public bool pause;


    private PickupItem _pickupItem;
    private InteractableNPC _interactableNPC;
    public float interactionRange = 3f;
    public LayerMask interactableLayer;

    private void Awake()
    {
        _animatorManager = GetComponent<AnimatorManager>();
        _playerLocomotion = GetComponent<PlayerLocomotion>();
        _playerManager = GetComponent<PlayerManager>();
        _pickupItem = GetComponent<PickupItem>();
        _interactableNPC = GetComponent<InteractableNPC>();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        _animatorManager.UpdateAnimatorValues(0, moveAmount, _playerLocomotion.isSprinting);
    }

    private void HandleSprintingInput()
    {
        if (y_Input && moveAmount > 0.5f)
        {
            _playerLocomotion.isSprinting = true;
        }
        else
        {
            _playerLocomotion.isSprinting = false;
        }
    }

    private void HandleActionInput()
    {
        if (a_Input)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactionRange, interactableLayer);

            foreach (Collider col in hitColliders)
            {
                InteractableNPC interactable = col.GetComponent<InteractableNPC>();
                PickupItem item = col.GetComponent<PickupItem>();
                if (interactable)
                {
                    interactable.OnInteract();
                    _interactableNPC = interactable;
                    _playerManager.isInteracting = true;
                    break;
                }
                else if (item)
                {
                    item.OnPickup();
                    Destroy(item.gameObject);
                    break;
                }
            }
        }
        else if (b_Input && _interactableNPC && _playerManager.isInteracting)
        {
            _interactableNPC.EndInteract();
            _playerManager.isInteracting = false;
            _interactableNPC = null;
        }
    }


    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleSprintingInput();
        //HandleJumpingInput
        HandleActionInput();
        HandleUIInput();
    }

    private void HandleUIInput()
    {
        if (pause)
        {
            gameManager.TogglePause();
            if (_playerManager.isInteracting)
            {
                _playerManager.isInteracting = false;
            } else if (!_playerManager.isInteracting)
            {
                _playerManager.isInteracting = true;
            }
        }
        
        //ToDo: 
    }

    private void OnEnable()
    {
        if (_playerControls == null)
        {
            _playerControls = new PlayerControls();
            _playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            _playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

            _playerControls.PlayerActions.Sprint.performed += i => y_Input = true;
            _playerControls.PlayerActions.Sprint.canceled += i => y_Input = false;
            _playerControls.PlayerActions.Interact.performed += i => a_Input = true;
            _playerControls.PlayerActions.Interact.canceled += i => a_Input = false;
            _playerControls.PlayerActions.InteractCancel.performed += i => b_Input = true;
            _playerControls.PlayerActions.InteractCancel.canceled += i => b_Input = false;

            _playerControls.Menu.Pause.performed += i => pause = true;
            _playerControls.Menu.Pause.canceled += i => pause = false;

            _playerControls.Menu.Select.performed += i => menuInput = i.ReadValue<Vector2>();
        }

        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }
}