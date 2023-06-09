using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystemTest
{
    public class CameraController : MonoBehaviour
    {
        public float vectorY = 0;
        public float vectorX = 0;
        private float sens = 500f;
        private float min = 0.0f;
        private float max = 360.0f;
        [SerializeField] Transform Target;
        private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            vectorY -= mouseY * sens * Time.deltaTime;
            vectorX += mouseX * sens * Time.deltaTime;
            vectorY = Mathf.Clamp(vectorY, 20.0f, 90.0f);
            vectorX = Mathf.Repeat(vectorX, max - min) + min;
            transform.rotation = Quaternion.Euler(vectorY, vectorX, 0.0f);
            this.transform.position = Target.transform.position + new Vector3(0.0f, 1.0f, 0.0f);
        }
    }
}