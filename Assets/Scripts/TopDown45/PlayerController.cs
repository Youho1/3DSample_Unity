using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown45
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 5.0f;

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
            Direction = Quaternion.Euler(0.0f, -45, 0.0f) * Direction;
            var Velocity = Direction * speed * Time.deltaTime;
            _rb.MovePosition(transform.position + Velocity);
        }
    }
}
