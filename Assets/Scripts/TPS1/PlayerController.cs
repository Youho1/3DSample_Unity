using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS1
{
    public class PlayerController : MonoBehaviour
    {
        public float run = 5f;
        public float walk = 2f;
        Vector3 Direction;
        Rigidbody _rb;
        Vector3 Velocity;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }
        private void FixedUpdate()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            Move(new Vector2(horizontalInput, verticalInput));
        }

        private void Move(Vector2 inputValue)
        {
            Direction.Set(inputValue.x, 0.0f, inputValue.y);
            Direction.Normalize();
            var playerEulerAngelsY = transform.eulerAngles.y;
            Direction = Quaternion.Euler(0.0f, playerEulerAngelsY, 0.0f) * Direction;
            if (inputValue.y < 0)
            {
                Velocity = Direction * walk * Time.deltaTime;
            }
            else
            {
                Velocity = Direction * run * Time.deltaTime;
            }

            _rb.MovePosition(transform.position + Velocity);
            var CameraForward = Camera.main.transform.forward;
            CameraForward.y = 0;
            transform.LookAt(transform.position + CameraForward);
        }
    }

}