using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float sens = 500f;
        [SerializeField] private float y_minAngle = 0.0f;
        [SerializeField] private float y_maxAngle = 360f;
        [SerializeField] private float x_minAngle = -90f;
        [SerializeField] private float x_maxAngle = 55.0f;
        public float angleY = 0;
        public float angleX = 0; 
        private void Update() {
            float mouseX = Input.GetAxisRaw("Mouse X");
            float mouseY = Input.GetAxisRaw("Mouse Y");
            
            angleX -= mouseY * sens * Time.deltaTime;
            angleY += mouseX * sens * Time.deltaTime;

            angleY = Mathf.Repeat(angleY - y_minAngle, y_maxAngle - y_minAngle);
            angleX = Mathf.Clamp(angleX, x_minAngle, x_maxAngle);
            this.transform.rotation = Quaternion.Euler(angleX, angleY, 0.0f);
        }
    }

}