using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystemTest
{
    public class PlayerController : MonoBehaviour
    {
        PlayerInput playerInput;
        CharacterController characterController;
        Animator animator;

        int isWalkingHash;
        int isRunningHash;

        Vector2 currentMovementInput;
        Vector3 currentMovement;
        Vector3 currentRunMovement;
        bool isMovementPressed;
        bool isRunPressed;
        float rotationFactorPerFrame = 15.0f;
        float runMultiplier = 3.0f;
        private void Awake()
        {
            playerInput = new PlayerInput();
            characterController = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
            isWalkingHash = Animator.StringToHash("isWalking");
            isRunningHash = Animator.StringToHash("isRunning");

            playerInput.CharacterControls.Move.started += onMovementInput;
            playerInput.CharacterControls.Move.canceled += onMovementInput;
            playerInput.CharacterControls.Move.performed += onMovementInput;
            playerInput.CharacterControls.Run.started += onRun;
            playerInput.CharacterControls.Run.canceled += onRun;
        }

        private void onRun(InputAction.CallbackContext context)
        {
            isRunPressed = context.ReadValueAsButton();
        }

        private void onMovementInput(InputAction.CallbackContext context)
        {
            currentMovementInput = context.ReadValue<Vector2>();
            currentMovement = Camera.main.transform.right * currentMovementInput.x + Camera.main.transform.forward * currentMovementInput.y;
            currentMovement.y = 0;
            currentRunMovement = currentMovement * runMultiplier;
            isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
        }
        void handleRotation()
        {
            Vector3 positionToLookAt;
            positionToLookAt.x = currentMovement.x;
            positionToLookAt.y = 0.0f;
            positionToLookAt.z = currentMovement.z;

            Quaternion currentRotation = transform.rotation;

            if (isMovementPressed)
            {
                Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
                transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
            }

        }

        void handleAnimation()
        {
            bool isWalking = animator.GetBool(isWalkingHash);
            bool isRunning = animator.GetBool(isRunningHash);

            if (isMovementPressed && !isWalking)
            {
                animator.SetBool(isWalkingHash, true);
            }
            else if (!isMovementPressed && isWalking)
            {
                animator.SetBool(isWalkingHash, false);
            }

            if ((isMovementPressed && isRunPressed) && !isRunning)
            {
                animator.SetBool(isRunningHash, true);
            }
            else if ((!isMovementPressed || !isRunPressed) && isRunning)
            {
                animator.SetBool(isRunningHash, false);
            }
        }

        void handleGravity()
        {
            if (characterController.isGrounded)
            {
                float groundedGravity = -.05f;
                currentMovement.y = groundedGravity;
                currentRunMovement.y = groundedGravity;
            }else
            {
                float gravity = -9.8f;
                currentMovement.y += gravity;
                currentRunMovement.y += gravity;
            }
        }

        private void Update()
        {
            handleGravity();
            handleRotation();
            handleAnimation();
            if (isRunPressed)
            {
                characterController.Move(currentRunMovement * Time.deltaTime);
            }
            else
            {
                characterController.Move(currentMovement * Time.deltaTime);
            }

        }
        private void OnEnable()
        {
            playerInput.CharacterControls.Enable();
        }

        private void OnDisable()
        {
            playerInput.CharacterControls.Disable();
        }
    }
}