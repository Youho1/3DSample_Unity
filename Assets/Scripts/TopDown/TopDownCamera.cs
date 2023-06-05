using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class TopDownCamera : MonoBehaviour
    {
        [SerializeField] Transform targetPos;
        public float CamOffset = 6.0f;
        private void Awake()
        {
            transform.rotation = Quaternion.Euler(90, 0, 0);
        }
        private void Update()
        {
            transform.position = new Vector3(targetPos.position.x, targetPos.position.y + CamOffset, targetPos.position.z);
        }
    }
}

