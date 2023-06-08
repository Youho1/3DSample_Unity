using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPS1
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform target;
        public float vectorY = 0;
        public float vectorX = 0;
        private float sens = 500f;
        private float min = 0.0f;
        private float max = 360.0f;
        private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            // y : xaxis
            // 右ボタンバージョン
            if (Input.GetMouseButton(1))
            {
                vectorY -= mouseY * sens * Time.deltaTime;
                vectorX += mouseX * sens * Time.deltaTime;

            }

            // 矢印バージョン
            if (Input.GetKey(KeyCode.Z))
            {
                vectorX -= 1 * sens;
            }
            if (Input.GetKey(KeyCode.C))
            {
                vectorX += 1 * sens;
            }
            if (Input.GetKey(KeyCode.H))
            {
                vectorY -= 1 * sens;
            }
            if (Input.GetKey(KeyCode.Y))
            {
                vectorY += 1 * sens;
            }
            vectorY = Mathf.Clamp(vectorY, 20.0f, 90.0f);
            vectorX = Mathf.Repeat(vectorX - min, max - min) + min;
            this.transform.rotation = Quaternion.Euler(vectorY, vectorX, 0.0f);
        }
    }
}