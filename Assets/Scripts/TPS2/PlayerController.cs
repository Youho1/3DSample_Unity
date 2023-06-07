using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS2
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 5f;
        Vector3 Direction;
        Rigidbody _rb;
        public float rotationSpeed = 600.0f;
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
            if (inputValue == Vector2.zero) return;
            Direction = Camera.main.transform.right * inputValue.x + Camera.main.transform.forward * inputValue.y;
            Direction.y = 0;
            var Velocity = Direction * speed * Time.deltaTime;
            _rb.MovePosition(transform.position + Velocity);
            Quaternion toRotation = Quaternion.LookRotation(Direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}