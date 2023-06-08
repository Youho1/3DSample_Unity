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

        Vector2 currentMovementInput;
        Vector3 currentMovement;
        bool isMovementPressed;
        float rotationFactorPerFrame = 15.0f;
        private void Awake()
        {
            playerInput = new PlayerInput();
            characterController = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();

            playerInput.CharacterControls.Move.started += onMovementInput;
            playerInput.CharacterControls.Move.canceled += onMovementInput;
            playerInput.CharacterControls.Move.performed += onMovementInput;
        }

        private void onMovementInput(InputAction.CallbackContext context)
        {
            currentMovementInput = context.ReadValue<Vector2>();
            currentMovement.x = currentMovementInput.x;
            currentMovement.z = currentMovementInput.y;
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
            bool isWalking = animator.GetBool("isWalking");
            bool isRunning = animator.GetBool("isRunning");

            if (isMovementPressed && !isWalking)
            {
                animator.SetBool("isWalking", true);
            }
            else if (!isMovementPressed && isWalking)
            {
                animator.SetBool("isWalking", false);
            }
        }

        private void Update()
        {
            handleRotation();
            handleAnimation();
            //currentMovement = Camera.main.transform.right * currentMovement.x + Camera.main.transform.forward * currentMovement.z;
            //currentMovement.y = 0;
            characterController.Move(currentMovement * Time.deltaTime);
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