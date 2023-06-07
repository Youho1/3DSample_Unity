using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS2
{
    public class CameraController : MonoBehaviour
    {
        public float vectorY = 0;
        public float vectorX = 0;
        private float sens = 5f;
        private float min = 0.0f;
        private float max = 360.0f;
        private void FixedUpdate()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            vectorY -= mouseY * sens;
            vectorX += mouseX * sens * 1.2f;
            vectorY = Mathf.Clamp(vectorY, 20.0f, 90.0f);
            vectorX = Mathf.Repeat(vectorX - min, max - min) + min;
            this.transform.rotation = Quaternion.Euler(vectorY, vectorX, 0.0f);
        }
    }
}