using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown45
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform Follow;
        private void Update() {
            transform.position = Follow.position;
        }
    }

}
