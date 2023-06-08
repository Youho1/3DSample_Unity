using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class PlayerController : MonoBehaviour
    {
        public float runSpeed = 5.0f;
        private Vector3 Direction;
        private Rigidbody _rb;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Move();
            var CameraForward = Camera.main.transform.forward;
            CameraForward.y = 0;
            transform.LookAt(transform.position + CameraForward);
        }

        private void Move()
        {
           float horizontalInput = Input.GetAxisRaw("Horizontal");
           float verticalInput = Input.GetAxisRaw("Vertical");
           var inputValue = new Vector2(horizontalInput, verticalInput);
           if (inputValue == Vector2.zero) return;
           var playerEulerAngle = this.transform.eulerAngles;
           Direction.Set(inputValue.x, 0.0f, inputValue.y);
           Direction.Normalize();
           Direction = Quaternion.Euler(0.0f, playerEulerAngle.y, 0.0f) * Direction;
           var Velocity = Direction * runSpeed * Time.deltaTime;
           _rb.MovePosition(transform.position + Velocity);
        }
    }

}