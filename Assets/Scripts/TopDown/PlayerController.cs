using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class PlayerController : MonoBehaviour
    {
        private float speed = 70.0f;
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var Direction = new Vector3(
                Input.GetAxis("Horizontal"),
                0.0f,
                Input.GetAxis("Vertical")
            );
            Direction.Normalize();
            var Velocity = Direction * speed * Time.deltaTime;
            _rb.MovePosition(transform.position + Velocity * Time.deltaTime);
        }

    }

}